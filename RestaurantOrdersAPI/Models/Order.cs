using System.Collections.Generic;

namespace RestaurantOrdersAPI.Models
{
    public class Order : IRestaurantObject
    {
        public int Id { get; set; }
        public double TotalPrice { get; set; }
        public Table Table { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}