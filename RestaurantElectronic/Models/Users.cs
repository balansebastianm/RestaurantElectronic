using System.ComponentModel.DataAnnotations;

namespace RestaurantElectronic.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Invalid reservation id.")]
        public int ReservationId { get; set; }
        [Required(ErrorMessage = "Invalid name.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Invalid reservation date.")]
        public DateTime ReservationDate { get; set; }

        Users()
        {

        }


    }


}