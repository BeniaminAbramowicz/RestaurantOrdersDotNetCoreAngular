using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestaurantOrdersAPI.Data;
using RestaurantOrdersAPI.Models;
using RestaurantOrdersAPI.Models.Enums;
using System.Threading.Tasks;

namespace RestaurantOrdersAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IRestaurantRepository<Meal> _mealRepo;
        private readonly IRestaurantRepository<Table> _tableRepo;
        private readonly IRestaurantRepository<Order> _orderRepo;
        public RestaurantController(IConfiguration config, IRestaurantRepository<Meal> mealRepo, IRestaurantRepository<Table> tableRepo, IRestaurantRepository<Order> orderRepo)
        {
            _orderRepo = orderRepo;
            _tableRepo = tableRepo;
            _mealRepo = mealRepo;
            _config = config;
        }

        [HttpGet("meals")]
        public async Task<IActionResult> GetMeals()
        {
            var mealsList = await _mealRepo.GetAll();

            return Ok(mealsList);
        } 

        [HttpGet("tables")]
        public async Task<IActionResult> GetTables()
        {
            var tablesList = await _tableRepo.GetAll();

            return Ok(tablesList);
        }

    }
}