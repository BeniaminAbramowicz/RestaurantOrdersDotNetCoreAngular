using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrdersAPI.Data
{
    public class RestaurantRepository : IRestaurantRepository
    {
        public async Task<T> Add<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public async void Delete<T>(T entity) where T : class
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            throw new System.NotImplementedException();
        }

        public async Task<T> GetFirstOrDefault<T>(int id) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}