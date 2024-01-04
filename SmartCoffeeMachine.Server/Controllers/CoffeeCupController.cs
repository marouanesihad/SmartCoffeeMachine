using Microsoft.AspNetCore.Mvc;
using SmartCoffeeMachine.Server.Models;

namespace SmartCoffeeMachine.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoffeeCupController : ControllerBase
    {
        private ICoffeeCupRepository repositroy;
        private readonly ILogger<CoffeeMachineController> _logger;

        public CoffeeCupController (ICoffeeCupRepository repo, ILogger<CoffeeMachineController> logger)
        {
            repositroy = repo;
            _logger = logger;
        }

        [HttpGet(Name = "GetAllCoffeeCups")]
        public IEnumerable<CoffeeCup> Get() => repositroy.CoffeeCups.ToArray();
        
        [HttpPost(Name ="AddCoffeeCup")]
        public void AddCoffeeCup(CoffeeCup coffee)
        {
            repositroy.AddCoffeeCup(coffee);
        } 

    }
}
