namespace SmartCoffeeMachine.Server.Models
{
    public interface ICoffeeCupRepository
    {
        public IQueryable<CoffeeCup> CoffeeCups { get; }

        public void AddCoffeeCup(CoffeeCup Cup);
    }
}
