using System.Data;

namespace SampleFormGenerator.Model.Contracts
{
    public interface IConnection
    {
        IDbConnection CreateDbConnection();
    }
}
