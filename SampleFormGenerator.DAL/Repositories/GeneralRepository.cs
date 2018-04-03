using SampleFormGenerator.Model.Contracts;

using Dapper;

using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SampleFormGenerator.DAL.Repositories
{
   public  class GeneralRepository 
    {
        private IConnection _connection;
        public GeneralRepository(IConnection connection)
        {
            _connection = connection;
            Db = _connection.CreateDbConnection();
        }
        public IDbConnection Db { get; set; }
        public void injectConnection(IDbConnection connection)
        {
            Db = connection;
        }
        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object conditiontions = null)
        {
            return await Db.QueryAsync<T>(query, conditiontions);
        }

        public async Task<T> QueryFirstAsync<T>(string query, object conditiontions = null)
        {
            return await Db.QueryFirstAsync<T>(query, conditiontions);
        }

        public async Task<T> ExecuteAsync<T>(string query,object conditions = null)
        {
            return await Db.ExecuteScalarAsync<T>(query, conditions);
        }
    }
}
