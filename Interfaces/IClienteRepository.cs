using Teste_TGS.Models;

namespace Teste_TGS.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int id);
        void CreateCliente(Cliente _Cliente);
        void UpdateCliente(Cliente _Cliente);
        void DeleteCliente(int id);
        IEnumerable<Logradouro> GetAllLogradouros(int id);

    }
}
