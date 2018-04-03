using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFormGenerator.Model.Contracts
{
    public interface IRepository<T> where T:IEntity
    {
        T Save(T model);
        T Update(T model);
        T Delete(T model);
        T Get(string where,object conditionValues = null);
        List<T> Select(string where, object conditionValues = null);
    }
}
