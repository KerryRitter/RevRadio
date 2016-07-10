using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RevRadio.Data.Interfaces;

namespace RevRadio.Data
{
    public class DbDapperContextFactory : IDbDapperContextFactory
    {
        private readonly string _connectionString;

        public DbDapperContextFactory(IConfiguration configuration)
        {
            _connectionString = configuration["Data:DefaultConnection"];
        }

        public SqlConnection Create()
        {
            return new SqlConnection(_connectionString);
        } 
    }
}
