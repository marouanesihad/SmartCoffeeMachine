namespace SmartCoffeeMachine.Server.Models
{
    public interface ICoffeeMachineRepository
    {
        public IQueryable<CoffeeMachine> CoffeeMachineStatus { get; }
        public void SaveStatus(CoffeeMachine status);
    }
}
