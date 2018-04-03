using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

using Dapper;

using SampleFormGenerator.DAL.Tools;
using SampleFormGenerator.Model.Contracts;
using SampleFormGenerator.Model.Entities;

namespace SampleFormGenerator.DAL.Repositories
{
    public class FormDataRepository : IRepository<TblFormData>
    {
        private IConnection _connection;
        public FormDataRepository(IConnection connection)
        {
            _connection = connection;
        }
        public IDbConnection Db => _connection.CreateDbConnection();
        public string TableName => "TblFormData";

        public async Task<bool> DeleteAsync(TblFormData model)
        {
            var result = await Db.ExecuteAsync($"DELETE FROM {TableName} WHERE Id = @Id", new { model.Id });
            return result > 0;
        }

        public async Task<TblFormData> GetAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryFirstAsync<TblFormData>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblFormData> SaveAsync(TblFormData model)
        {
            var insertQuery = $"INSERT INTO {TableName}(Date,Id_FormInfo) VALUES(@Date,@Id_FormInfo);SELECT SCOPE_IDENTITY()";
            var id = await Db.ExecuteScalarAsync<int>(insertQuery, model);
            model.Id = id;
            return model;
        }

        public async Task<IEnumerable<TblFormData>> SelectAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryAsync<TblFormData>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblFormData> UpdateAsync(TblFormData model)
        {
            var updateQuery = $"UPDATE {TableName} SET Date = @Date , Id_FormInfo = @Id_FormInfo WHERE Id = @Id";
            var result = await Db.ExecuteScalarAsync<int>(updateQuery, model);
            return model;
        }
    }
}
