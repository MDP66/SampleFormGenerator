using Dapper;
using SampleFormGenerator.DAL.Tools;
using SampleFormGenerator.Model.Contracts;
using SampleFormGenerator.Model.Entities;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SampleFormGenerator.DAL.Repositories
{
    public class FormValuesRepository : IRepository<TblFormValues>
    {
        private IConnection _connection;
        public FormValuesRepository(IConnection connection)
        {
            _connection = connection;
            Db = _connection.CreateDbConnection();
        }
        public IDbConnection Db { get; set; }
        public void injectConnection(IDbConnection connection)
        {
            Db = connection;
        }
        public string TableName => "TblFormValues";

        public async Task<bool> DeleteAsync(TblFormValues model)
        {
            var result = await Db.ExecuteAsync($"DELETE FROM {TableName} WHERE Id = @Id", new { model.Id });
            return result > 0;
        }

        public async Task<TblFormValues> GetAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryFirstAsync<TblFormValues>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblFormValues> SaveAsync(TblFormValues model)
        {
            var insertQuery = $"INSERT INTO {TableName}(Id_FormInfoParamater,Id_FormData,Value,IsValidationPassed) VALUES(@Id_FormInfoParamater,@Id_FormData,@Value,@IsValidationPassed);SELECT SCOPE_IDENTITY()";
            var id = await Db.ExecuteScalarAsync<int>(insertQuery, model);
            model.Id = id;
            return model;
        }

        public async Task<IEnumerable<TblFormValues>> SelectAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryAsync<TblFormValues>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblFormValues> UpdateAsync(TblFormValues model)
        {
            var updateQuery = $"UPDATE {TableName} SET Id_FormInfoParamater=@Id_FormInfoParamater,Id_FormData=@Id_FormData,Value=@Value,IsValidationPassed=@IsValidationPassed WHERE Id = @Id";
            var result = await Db.ExecuteScalarAsync<int>(updateQuery, model);
            return model;
        }
    }
}
