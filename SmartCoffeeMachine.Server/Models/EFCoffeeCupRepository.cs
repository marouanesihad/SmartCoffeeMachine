namespace SmartCoffeeMachine.Server.Models
{
    public class EFCoffeeCupRepository : ICoffeeCupRepository
    {
        private CoffeeMachineDbContext context;

        public EFCoffeeCupRepository(CoffeeMachineDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<CoffeeCup> CoffeeCups => context.CoffeeCups;

        public void AddCoffeeCup (CoffeeCup Cup)
        {
            context.CoffeeCups.Add(Cup);
            context.SaveChanges();
        }
    }
}
