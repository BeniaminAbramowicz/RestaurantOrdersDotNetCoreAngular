namespace RestaurantOrdersAPI.Models
{
    public class Meal : IRestaurantObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; } 
    }
}