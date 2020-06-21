namespace RestaurantOrdersAPI.Models
{
    public class OrderItem : IRestaurantObject
    {
        public int Id { get; set; }
        public Meal Meal { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}