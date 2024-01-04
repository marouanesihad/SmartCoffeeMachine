namespace SmartCoffeeMachine.Server.Models
{
    public enum State
    {
        Okay = 0,
        Alert = 1
    }
    public struct CoffeeCreationOptions
    {
        public int NumEspressoShots { get; set; }
        public bool AddMilk { get; set; }
    }
    public interface ICoffeeMachine
    {
        bool IsOn { get; }
        bool IsMakingCoffee { get; }
        State WaterLevelState { get; }
        State BeanFeedState { get; }
        State WasteCoffeeState { get; }
        State WaterTrayState { get; }
        Task TurnOnAsync();
        Task TurnOffAsync();
        Task MakeCoffeeAsync(CoffeeCreationOptions options);
    }
}
