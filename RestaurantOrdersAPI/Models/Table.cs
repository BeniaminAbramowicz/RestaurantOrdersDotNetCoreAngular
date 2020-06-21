namespace RestaurantOrdersAPI.Models
{
    public class Table : IRestaurantObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}