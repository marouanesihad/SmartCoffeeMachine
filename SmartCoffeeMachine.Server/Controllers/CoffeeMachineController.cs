using Microsoft.AspNetCore.Mvc;
using SmartCoffeeMachine.Server.Models;

namespace SmartCoffeeMachine.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeMachineController : ControllerBase
    {
        private ICoffeeMachineRepository repository;
        private readonly ILogger<CoffeeMachineController> _logger;

        public CoffeeMachineController(ICoffeeMachineRepository repo, ILogger<CoffeeMachineController> logger)
        {
            repository = repo;
            _logger = logger;
        }

        [HttpGet(Name = "GetCoffeeMachineStatus")]
        public IEnumerable<CoffeeMachine> Get() => repository.CoffeeMachineStatus.ToArray();

        [HttpPost(Name = "TurnOnOffCoffeMachine")]
        public async void PostTurnOnOffCoffeeMachine()
        {
            CoffeeMachine? status = repository.CoffeeMachineStatus.FirstOrDefault();
            if(status != null)
            {
                if (!status.IsOn)
                    await status.TurnOnAsync();
                else
                    await status.TurnOffAsync();

                repository.SaveStatus(status);
            }
        }        
    }
}
