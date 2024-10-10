using Dapper;
using System.Data;
using WebIdentityApi.Contacts;
using WebIdentityApi.Data;

namespace WebIdentityApi.Services
{
    public class UserRepository : IUserRepository
    {

        private readonly DapperContext _dbConnection;

        public UserRepository(DapperContext dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void CreateUser(string username, string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            using (var con_d = _dbConnection.CreateConnection())
            {
                string sql = "INSERT INTO Users (Email, PasswordHash) VALUES (@Username, @PasswordHash)";
                con_d.Execute(sql, new { Username = username, PasswordHash = hashedPassword });
            }
        }

        public string ValidateUser(string username)
        {
            string storedHash = "";
            using (var con_d = _dbConnection.CreateConnection())
            {
                string sql = "SELECT PasswordHash FROM Users WHERE Email = @Username";
                storedHash = con_d.QuerySingleOrDefault<string>(sql, new { Username = username });
            }
            return storedHash;
        }
    }
}
