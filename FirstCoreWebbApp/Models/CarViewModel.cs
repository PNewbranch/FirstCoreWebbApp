using System.ComponentModel.DataAnnotations;  //Lägg till denna

namespace FirstCoreWebbApp.Models  //Stod då Controllers här eftersom den skapades från controllers... ändra till Models
{
    public class CarViewModel
    {
        [Required]
        public string Brand { get; set; }
        public string ModelName { get; set; }
    }
}