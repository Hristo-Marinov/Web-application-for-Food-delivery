using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FoodEx.Data.Entity.Context;
using Microsoft.Extensions.Configuration;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // Configure your DbContext here
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=FoodEx;Trusted_Connection=True;MultipleActiveResultSets=true" // TODO: Replace with your actual connection string
            ));
    })
    .Build();

// Automatically apply migrations on startup
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

Console.WriteLine("Database migration completed successfully.");
