using System.ComponentModel.DataAnnotations;

namespace SmartCoffeeMachine.Server.Models
{
    public class CoffeeCup
    {
        [Key]
        public int CoffeeId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
