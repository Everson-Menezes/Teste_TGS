using System.Data;

namespace Teste_TGS.Interfaces
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}