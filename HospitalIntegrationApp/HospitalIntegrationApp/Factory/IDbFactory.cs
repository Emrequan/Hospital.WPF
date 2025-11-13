using System.Data;


namespace HospitalIntegrationApp.Factory
{
    public interface IDbFactory
    {
        IDbConnection CreateConnection();
        IDbCommand CreateCommand(string query, IDbConnection connection);
    }
}