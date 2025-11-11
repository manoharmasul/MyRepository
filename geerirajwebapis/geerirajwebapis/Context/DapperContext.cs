using System.Data;
using System.Data.SqlClient;

namespace geerirajwebapis.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("sqlconnection");
        }
        public IDbConnection CreateConnection() =>
                 new SqlConnection(_connectionstring);
    }
}
