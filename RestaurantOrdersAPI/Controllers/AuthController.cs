using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersAPI.DTOs;

namespace RestaurantOrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public async Task<IActionResult> RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            return Ok();
        }
    }
}