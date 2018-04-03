using Dapper;
using SampleFormGenerator.DAL.Tools;
using SampleFormGenerator.Model.Contracts;
using SampleFormGenerator.Model.Entities;

using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SampleFormGenerator.DAL.Repositories
{
    public class ParameterTypesRepository : IRepository<TblParameterTypes>
    {
        private IConnection _connection;
        public ParameterTypesRepository(IConnection connection)
        {
            _connection = connection;
            Db = _connection.CreateDbConnection();
        }
        public IDbConnection Db { get; set; }
        public void injectConnection(IDbConnection connection)
        {
            Db = connection;
        }
        public string TableName => "TblParameterTypes";

        public async Task<bool> DeleteAsync(TblParameterTypes model)
        {
            var result = await Db.ExecuteAsync($"DELETE FROM {TableName} WHERE Id = @Id", new { model.Id });
            return result > 0;
        }

        public async Task<TblParameterTypes> GetAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryFirstAsync<TblParameterTypes>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblParameterTypes> SaveAsync(TblParameterTypes model)
        {
            var insertQuery = $"INSERT INTO {TableName}(Title,RegexValidator,RegexValidatorMessage,EditorType,ViewerType) VALUES(@Title,@RegexValidator,@RegexValidatorMessage,@EditorType,@ViewerType);SELECT SCOPE_IDENTITY()";
            var id = await Db.ExecuteScalarAsync<int>(insertQuery, model);
            model.Id = id;
            return model;
        }

        public async Task<IEnumerable<TblParameterTypes>> SelectAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryAsync<TblParameterTypes>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblParameterTypes> UpdateAsync(TblParameterTypes model)
        {
            var updateQuery = $"UPDATE {TableName} SET Title=@Title,RegexValidator=@RegexValidator,RegexValidatorMessage=@RegexValidatorMessage,EditorType=@EditorType,ViewerType=@ViewerType WHERE Id = @Id";
            var result = await Db.ExecuteScalarAsync<int>(updateQuery, model);
            return model;
        }
    }
}
