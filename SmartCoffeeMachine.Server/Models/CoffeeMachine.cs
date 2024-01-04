using System.ComponentModel.DataAnnotations;

namespace SmartCoffeeMachine.Server.Models
{
    public class CoffeeMachine
    {
        [Key]
        public long? CoffeeMachineID { get; set; }
        public bool IsOn { get; private set; }
        public bool IsMakingCoffee { get; private set; }
        public State WaterLevelState { get; private set; }
        public State BeanFeedState { get; private set; }
        public State WasteCoffeeState { get; private set; }
        public State WaterTrayState { get; private set; }
        private bool IsInAlertState => WaterLevelState == State.Alert
        || BeanFeedState == State.Alert
        || WasteCoffeeState == State.Alert
        || WaterTrayState == State.Alert;

        private readonly Random _randomStateGenerator;
        public CoffeeMachine()
        {
            _randomStateGenerator = new Random();
        }
        public async Task TurnOnAsync()
        {
            if (IsOn)
                throw new InvalidOperationException("Invalid state");
            // Generate sample state for testing
            WaterLevelState = GetRandomState();
            BeanFeedState = GetRandomState();
            WasteCoffeeState = GetRandomState();
            WaterTrayState = GetRandomState();
            // [Machine turned on]
            IsOn = true;
        }
        public async Task TurnOffAsync()
        {
            if (!IsOn || IsMakingCoffee)
                throw new InvalidOperationException("Invalid state");
            // [Machine turned off]
            IsOn = false;
        }
        public async Task MakeCoffeeAsync(CoffeeCreationOptions options)
        {
            if (!IsOn || IsMakingCoffee || IsInAlertState)
                throw new InvalidOperationException("Invalid state");
            IsMakingCoffee = true;
            // [Make the coffee]
            Thread.Sleep(10000);
            IsMakingCoffee = false;
        }
        // Randomly create a state for testing. This can be replaced as required.
        private State GetRandomState() => _randomStateGenerator.Next(1, 10)
        == 5 ? State.Alert : State.Okay;
    }

}

