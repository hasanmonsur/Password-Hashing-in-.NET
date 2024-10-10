using Microsoft.Data.SqlClient;
using System.Data;

namespace WebIdentityApi.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            // Fetch the connection string from the configuration
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Method to get the SQL Server connection
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}
