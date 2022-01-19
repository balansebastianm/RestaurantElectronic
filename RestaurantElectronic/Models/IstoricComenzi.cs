using System.ComponentModel.DataAnnotations;

namespace RestaurantElectronic.Models
{
    public class IstoricComenzi
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public float TotalPrice { get; set; }

    }
}