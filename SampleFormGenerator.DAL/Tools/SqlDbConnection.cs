using SampleFormGenerator.Model.Contracts;
using System.Data;

namespace SampleFormGenerator.DAL.Tools
{
    public class SqlDbConnection : IConnection
    {
        public IDbConnection CreateDbConnection()
        {
            var connectionString = GetConnectionString();
            return new System.Data.SqlClient.SqlConnection(connectionString);
        }

        private string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString;
        }
    }
}
