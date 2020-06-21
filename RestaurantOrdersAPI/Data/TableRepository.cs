using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Dapper;
using RestaurantOrdersAPI.Data.DataHelpers;
using RestaurantOrdersAPI.Models;

namespace RestaurantOrdersAPI.Data
{
    public class TableRepository : IRestaurantRepository<Table>
    {
        private readonly IConfiguration _config;

        public TableRepository(IConfiguration config)
        {
            _config = config;
        }

        public async Task<Table> Add(Table entity)
        {
            Table insertedTable;

            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                await connection.OpenAsync();

                using (var transaction = await connection.BeginTransactionAsync())
                {
                    insertedTable = await connection.QueryFirstOrDefaultAsync<Table>(SqlQueriesFactory.AddTable(), entity);
                    await transaction.CommitAsync();
                }
            }

            return insertedTable;
        }

        public async void Delete(int id)
        {
            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                await connection.ExecuteAsync(SqlQueriesFactory.DeleteTable(), new { Id = id });
            }
        }

        public async Task<IEnumerable<Table>> GetAll()
        {
            IEnumerable<Table> tablesList;

            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                tablesList = await connection.QueryAsync<Table>(SqlQueriesFactory.GetAllTables());
            }

            return tablesList;
        }

        public async Task<Table> GetFirstOrDefault(int id)
        {
            Table table;

            using (var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                table = await connection.QueryFirstOrDefaultAsync<Table>(SqlQueriesFactory.GetTable(), new { Id = id });
            }

            return table;
        }
    }
}