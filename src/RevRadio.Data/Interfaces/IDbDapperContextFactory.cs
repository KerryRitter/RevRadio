using System.Data.SqlClient;

namespace RevRadio.Data.Interfaces
{
    public interface IDbDapperContextFactory
    {
        SqlConnection Create();
    }
}