namespace RestaurantElectronic.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public bool isPositive { get; set; }
        public string ReviewText { get; set; }
    }
}