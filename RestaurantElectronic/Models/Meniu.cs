using System.ComponentModel.DataAnnotations;

namespace RestaurantElectronic.Models
{
    public class Meniu
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Invalid name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Invalid description.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Invalid price.")]
        public float Price { get; set; }
        [Required(ErrorMessage = "Invalid weight.")]
        public int Weight { get; set; }
    }
}