using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SampleFormGenerator.Model.Contracts
{
    public interface IRepository<T> where T : IEntity
    {
        IDbConnection Db { get; }
        string TableName { get; }
        Task<T> SaveAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<bool> DeleteAsync(T model);
        Task<T> GetAsync(string where, object conditionValues = null);
        Task<IEnumerable<T>> SelectAsync(string where, object conditionValues = null);
    }
}
