using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using RestaurantOrdersAPI.DTOs;
using System.Data.SqlClient;
using Dapper;
using RestaurantOrdersAPI.Models;

namespace RestaurantOrdersAPI.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _config;

        public AuthRepository(IConfiguration config)
        {
            _config = config;
        }
        
        public async void Login(UserForLoginDto userForLoginDto)
        {
            using(var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {

            }
        }

        public async void Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            using(var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                await connection.ExecuteAsync("INSERT INTO Users (username, name, surname, is_active, password_hash, password_salt) VALUES (@Username, @Name, @Surname, @IsActive, @PasswordHash, @PasswordSalt)", user);
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            using(var connection = new SqlConnection(_config.GetConnectionString("RestaurantAPI")))
            {
                if(await connection.QueryFirstOrDefaultAsync<User>("SELECT username FROM Users WHERE username = @Username", new {Username = username}) == null)
                {
                    return false;
                } else
                {
                    return true;
                }
            }
        }
    }
}