using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrdersAPI.Data
{
    public interface IRestaurantRepository
    {
         Task<T> Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<IEnumerable<T>> GetAll<T>() where T: class;
         Task<T> GetFirstOrDefault<T>(int id) where T: class;
    }
}