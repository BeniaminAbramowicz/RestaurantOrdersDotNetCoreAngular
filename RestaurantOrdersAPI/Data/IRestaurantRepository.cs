using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantOrdersAPI.Data
{
    public interface IRestaurantRepository<T>
    {
         Task<T> Add(T entity);
         void Delete(int id);
         Task<IEnumerable<T>> GetAll();
         Task<T> GetFirstOrDefault(int id);
    }
}