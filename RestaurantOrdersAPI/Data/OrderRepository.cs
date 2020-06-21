using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using RestaurantOrdersAPI.Data.DataHelpers;
using RestaurantOrdersAPI.Models;

namespace RestaurantOrdersAPI.Data
{
    public class OrderRepository : IRestaurantRepository<Order>
    {
        private readonly IConfiguration _config;

        public OrderRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Order> Add(Order entity)
        {

            throw new System.NotImplementedException();
        }

        public async void Delete(int id)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                await connection.ExecuteAsync(SqlQueriesFactory.DeleteOrder(), new { Id = id });
            }
        }

        public async Task<IEnumerable<Order>> GetAll()
        {
            IEnumerable<Order> ordersList;

            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                ordersList = await connection.QueryAsync<Order>(SqlQueriesFactory.GetAllOrders());
            }

            return ordersList;
        }

        public async Task<Order> GetFirstOrDefault(int id)
        {
            Order order;

            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                order = await connection.QueryFirstOrDefaultAsync<Order>(SqlQueriesFactory.GetOrder(), new { Id = id });
            }

            return order;
        }

        public async void DeleteOrderItem(int id)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                await connection.ExecuteAsync(SqlQueriesFactory.DeleteOrderItem(), new { Id = id });
            }
        }
    }
}