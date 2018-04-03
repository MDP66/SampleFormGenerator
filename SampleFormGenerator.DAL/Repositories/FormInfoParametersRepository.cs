using Dapper;
using SampleFormGenerator.DAL.Tools;
using SampleFormGenerator.Model.Contracts;
using SampleFormGenerator.Model.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SampleFormGenerator.DAL.Repositories
{
    public class FormInfoParametersRepository : IRepository<TblFormInfoParameters>
    {
        private IConnection _connection;
        public FormInfoParametersRepository(IConnection connection)
        {
            _connection = connection;
        }
        public IDbConnection Db => _connection.CreateDbConnection();
        public string TableName => "TblFormInfoParameters";

        public async Task<bool> DeleteAsync(TblFormInfoParameters model)
        {
            var result = await Db.ExecuteAsync($"DELETE FROM {TableName} WHERE Id = @Id", new { model.Id });
            return result > 0;
        }

        public async Task<TblFormInfoParameters> GetAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryFirstAsync<TblFormInfoParameters>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblFormInfoParameters> SaveAsync(TblFormInfoParameters model)
        {
            var insertQuery = $"INSERT INTO {TableName}(Id_FormInfo,Id_ParameterTypes,ParamterTitle,IsMandotory,ParameterOrder) VALUES(@Id_FormInfo,@Id_ParameterTypes,@ParamterTitle,@IsMandotory,@ParameterOrder);SELECT SCOPE_IDENTITY()";
            var id = await Db.ExecuteScalarAsync<int>(insertQuery, model);
            model.Id = id;
            return model;
        }

        public async Task<IEnumerable<TblFormInfoParameters>> SelectAsync(string where, object conditionValues = null)
        {
            where = where.PrepareWhereCondition();
            return await Db.QueryAsync<TblFormInfoParameters>($"SELECT * FROM {TableName} WHERE {where}", conditionValues);
        }

        public async Task<TblFormInfoParameters> UpdateAsync(TblFormInfoParameters model)
        {
            var updateQuery = $@"UPDATE {TableName}    
                                SET 
                                     [Id_FormInfo] = @Id_FormInfo
                                    ,[Id_ParameterTypes] = @Id_ParameterTypes
                                    ,[ParamterTitle] = @ParamterTitle
                                    ,[IsMandotory] = @IsMandotory
                                    ,[ParameterOrder] = @ParameterOrder
                                 WHERE 
                                    Id = @Id";
            var result = await Db.ExecuteScalarAsync<int>(updateQuery, model);
            return model;
        }
    }
}
