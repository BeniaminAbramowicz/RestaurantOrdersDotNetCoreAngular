using System.Threading.Tasks;
using RestaurantOrdersAPI.DTOs;
using RestaurantOrdersAPI.Models;

namespace RestaurantOrdersAPI.Data
{
    public interface IAuthRepository
    {
         void Register(UserForRegisterDto userForRegisterDto);
         void Login(UserForLoginDto userForLoginDto);
         Task<bool> UserExists(string username);
    }
}