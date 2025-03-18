using FoodEx.Entity.Context;
using FoodEx.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
        sqlOptions.MigrationsAssembly("FoodEx")));

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

var app = builder.Build();

// Enforce HTTPS in production
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redirect HTTP to HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Custom routes
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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

// Run the application
app.Run();
