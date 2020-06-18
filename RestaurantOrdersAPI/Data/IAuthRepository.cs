using System.Threading.Tasks;
using RestaurantOrdersAPI.Models;
using RestaurantOrdersAPI.DTOs;

namespace RestaurantOrdersAPI.Data
{
    public interface IAuthRepository
    {
         void Register(User user, string password);
         Task<User> Login(UserForLoginDto userForLoginDto);
         Task<bool> UserExists(string username);
    }
}