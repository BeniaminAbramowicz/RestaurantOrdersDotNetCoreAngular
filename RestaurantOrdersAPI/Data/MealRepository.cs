using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using RestaurantOrdersAPI.Data.DataHelpers;
using RestaurantOrdersAPI.Models;

namespace RestaurantOrdersAPI.Data
{
    public class MealRepository : IRestaurantRepository<Meal>
    {
        private readonly IConfiguration _config;

        public MealRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Meal> Add(Meal entity)
        {
            Meal insertedMeal;

            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    insertedMeal = await connection.QueryFirstOrDefaultAsync<Meal>(SqlQueriesFactory.AddMeal(), entity);
                    await transaction.CommitAsync();
                }
            }

            return insertedMeal;
        }

        public async void Delete(int id)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                await connection.ExecuteAsync(SqlQueriesFactory.DeleteMeal(), new { Id = id });
            }
        }

        public async Task<IEnumerable<Meal>> GetAll()
        {
            IEnumerable<Meal> mealsList;

            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                mealsList = await connection.QueryAsync<Meal>(SqlQueriesFactory.GetAllMeals());
            }

            return mealsList;
        }

        public async Task<Meal> GetFirstOrDefault(int id)
        {
            Meal meal;

            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                meal = await connection.QueryFirstOrDefaultAsync<Meal>(SqlQueriesFactory.GetMeal(), new { Id = id });
            }

            return meal;
        }
    }
}