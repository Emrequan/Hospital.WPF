using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;


namespace HospitalIntegrationApp.Factory
{
    public class MasterDbFactory : IDbFactory
    {
        public IDbConnection CreateConnection()
        {
            var cs = ConfigurationManager.ConnectionStrings["Master"].ConnectionString;
            return new MySqlConnection(cs);
        }

        public IDbCommand CreateCommand(string query, IDbConnection connection)
        {
            return new MySqlCommand(query, (MySqlConnection)connection);
        }
    }
}









