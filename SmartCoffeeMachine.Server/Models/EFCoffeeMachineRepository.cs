namespace SmartCoffeeMachine.Server.Models
{
    public class EFCoffeeMachineRepository : ICoffeeMachineRepository
    {
        private CoffeeMachineDbContext context;

        public EFCoffeeMachineRepository(CoffeeMachineDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<CoffeeMachine> CoffeeMachineStatus => context.CoffeeMachineStatus;

        public void SaveStatus(CoffeeMachine status)
        {
            context.CoffeeMachineStatus.Update(status);
            context.SaveChanges();
        }
    }
}
