using Teste_TGS.Models;

namespace Teste_TGS.Interfaces
{
    public interface ILogradouroRepository
    {
        IEnumerable<Logradouro> GetLogradouroByClienteId(int id);
        Logradouro GetLogradouroById(int id, int clienteId);

        void CreateLogradouro(Logradouro _Logradouro);
        void UpdateLogradouro(Logradouro _Logradouro);
        void DeleteLogradouro(int id);
    }
}