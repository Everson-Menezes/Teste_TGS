using Dapper;
using Teste_TGS.Interfaces;
using Teste_TGS.Models;

namespace Teste_TGS.Repositories
{

    public class ClienteRepository : IClienteRepository
    {
        private readonly IDapperContext _context;

        public ClienteRepository(IDapperContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAllClientes()
        {

            var query = "SELECT * FROM TB_Clientes";
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Cliente>(query).ToList();

            }
        }

        public Cliente GetClienteById(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Cliente>("SELECT * FROM TB_Clientes WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void CreateCliente(Cliente cliente)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "INSERT INTO TB_Clientes (Nome, Email, Logotipo, Logradouro) VALUES (@Nome, @Email, @Logotipo, @Logradouro)";
                connection.Execute(sql, cliente);
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "UPDATE TB_Clientes SET Nome = @Nome, Email = @Email, Logotipo = @Logotipo, Logradouro = @Logradouro WHERE Id = @Id";
                connection.Execute(sql, cliente);
            }
        }

        public void DeleteCliente(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM TB_Clientes WHERE Id = @Id"; connection.Execute(sql, new { Id = id });
            }
        }
    }

}