using System.Data.Common;

namespace UserTaskManagement.Common.Abstractions
{
    public interface IDbConnectionFactory
    {
        DbConnection GetConnection();
    }
}
