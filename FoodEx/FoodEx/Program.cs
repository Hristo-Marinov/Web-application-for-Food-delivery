using FoodEx.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FoodEx.Services;
using FoodEx.Data.Entity.Context;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string is null or empty. Please check appsettings.json.");
}

Console.WriteLine($"Using Connection String: {connectionString}");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
        sqlOptions.MigrationsAssembly("FoodEx.Data")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.SlidingExpiration = true;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
    options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
.AddCookie()
.AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    googleOptions.SignInScheme = IdentityConstants.ExternalScheme;
});

builder.Services.AddAntiforgery(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();
builder.Services.AddScoped<AdminService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Exception");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseExceptionHandler("/Error/Exception");

app.MapControllerRoute(
    name: "restaurant",
    pattern: "Places/Place",
    defaults: new { controller = "Place", action = "Place" });

app.MapControllerRoute(
    name: "foodDetails",
    pattern: "Food/FoodDetails/{id}",
    defaults: new { controller = "Food", action = "FoodDetails" });

app.MapControllerRoute(
    name: "account",
    pattern: "User/{action}",
    defaults: new { controller = "Account" });

app.MapControllerRoute(
    name: "cart",
    pattern: "Cart/{action=Index}/{id?}",
    defaults: new { controller = "Cart" });

app.MapControllerRoute(
    name: "orders",
    pattern: "Orders/{action=Index}/{id?}",
    defaults: new { controller = "Orders" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "orders_user",
    pattern: "orders/user/{action=Index}/{id?}",
    defaults: new { controller = "Orders", action = "Index" });

app.MapControllerRoute(
    name: "orders_restaurant",
    pattern: "orders/restaurant/{action=RestaurantPanel}/{id?}",
    defaults: new { controller = "Orders", action = "RestaurantPanel" });

app.MapControllerRoute(
    name: "orders_delivery",
    pattern: "orders/delivery/{action=DeliveryPanel}/{id?}",
    defaults: new { controller = "Orders", action = "DeliveryPanel" });

app.MapControllerRoute(
    name: "restaurant_myfoods",
    pattern: "Restaurant/MyFoods",
    defaults: new { controller = "Restaurant", action = "MyFoods" });

app.MapControllerRoute(
    name: "restaurantCreate",
    pattern: "Restaurant/Create",
    defaults: new { controller = "Restaurant", action = "Create" });

app.MapControllerRoute(
    name: "restaurantAddFood",
    pattern: "Restaurant/AddFood",
    defaults: new { controller = "Restaurant", action = "AddFood" });

app.MapControllerRoute(
    name: "restaurantDeleteFood",
    pattern: "Restaurant/DeleteFood/{id?}",
    defaults: new { controller = "Restaurant", action = "DeleteFood" });

app.MapControllerRoute(
    name: "adminPanel",
    pattern: "Admin/Panel",
    defaults: new { controller = "Admin", action = "AdminPanel" });

app.MapRazorPages();

app.Run();
