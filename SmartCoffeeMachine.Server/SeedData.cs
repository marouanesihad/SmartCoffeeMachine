using Microsoft.EntityFrameworkCore;
using SmartCoffeeMachine.Server.Models;

namespace SmartCoffeeMachine.Server
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app) //IApplicationBuilder interface used to register middleware components to handle HTTP Requests, provides access to the application’s services, including the Entity Framewore Core database context service
        {
            CoffeeMachineDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CoffeeMachineDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.CoffeeMachineStatus.Any())
            {
                context.CoffeeMachineStatus.Add(new CoffeeMachine());
                context.SaveChanges();
            }
        }
    }
}
