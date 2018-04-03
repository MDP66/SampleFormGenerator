using Dapper;
using SampleFormGenerator.DAL.Tools;
using SampleFormGenerator.Model.Contracts;
using SampleFormGenerator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFormGenerator.DAL.Repositories
{
   public  class FormInfosRepository : IRepository<TblFormInfos>
    {
        private IConnection _connection;
        public FormInfosRepository(IConnection connection)
        {
            _connection = connection;
        }
        public IDbConnection Db => _connection.CreateDbConnection();
        public string TableName => "TblFormInfos";

        public async Task<bool> DeleteAsync(TblFormInfos model)
        {
            var result = await Db.ExecuteAsync($"DELETE FROM {TableName} WHERE Id = @Id", new { model.Id });
            return result > 0;
        }

        public async Task<TblFormInfos> GetAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryFirstAsync<TblFormInfos>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblFormInfos> SaveAsync(TblFormInfos model)
        {
            var insertQuery = $"INSERT INTO {TableName}(Title) VALUES(@Title);SELECT SCOPE_IDENTITY()";
            var id = await Db.ExecuteScalarAsync<int>(insertQuery, model);
            model.Id = id;
            return model;
        }

        public async Task<IEnumerable<TblFormInfos>> SelectAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryAsync<TblFormInfos>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblFormInfos> UpdateAsync(TblFormInfos model)
        {
            var updateQuery = $"UPDATE {TableName} SET Title = @Title WHERE Id = @Id";
            var result = await Db.ExecuteScalarAsync<int>(updateQuery, model);
            return model;
        }
    }
}
