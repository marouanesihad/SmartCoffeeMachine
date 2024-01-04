using Microsoft.EntityFrameworkCore;

namespace SmartCoffeeMachine.Server.Models
{
    public class CoffeeMachineDbContext : DbContext
    {
        public CoffeeMachineDbContext(DbContextOptions<CoffeeMachineDbContext> options)
            : base(options) { }

        public DbSet<CoffeeMachine> CoffeeMachineStatus => Set<CoffeeMachine>();
        public DbSet<CoffeeCup> CoffeeCups => Set<CoffeeCup>();
    }
}
