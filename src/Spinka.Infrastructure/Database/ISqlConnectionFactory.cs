using System.Data;

namespace Spinka.Infrastructure.Database
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}