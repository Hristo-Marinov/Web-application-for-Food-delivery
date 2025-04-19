
using FoodEx.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FoodEx.Services;
using FoodEx.Data.Entity.Context;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string is null or empty. Please check appsettings.json.");
}

Console.WriteLine($"Using Connection String: {connectionString}");

// Configure the database context with Identity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString, sqlOptions =>
        sqlOptions.MigrationsAssembly("FoodEx.Data")));

// Configure Identity (Users + Roles)
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

// Secure Cookie Authentication Configuration
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true; // Secure against XSS
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Enforce HTTPS
    options.Cookie.SameSite = SameSiteMode.Strict; // Prevents cross-origin cookie issues
    options.LoginPath = "/User/Login";
    options.AccessDeniedPath = "/User/AccessDenied";
});

// Enforce Antiforgery Cookies for HTTPS
builder.Services.AddAntiforgery(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
});

// Add MVC and Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IFoodService, FoodService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IPlaceService, PlaceService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IDeliveryService, DeliveryService>();

var app = builder.Build();

// Enforce HTTPS in production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Exception");
    //app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    app.UseHsts();
}

// Redirect HTTP to HTTPS
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
