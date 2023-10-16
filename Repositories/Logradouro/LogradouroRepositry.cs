using Dapper;
using Teste_TGS.Interfaces;
using Teste_TGS.Models;

namespace Teste_TGS.Repositories
{

    public class LogradouroRepositry : ILogradouroRepository
    {
        private readonly IDapperContext _context;

        public LogradouroRepositry(IDapperContext context)
        {
            _context = context;
        }

        public IEnumerable<Logradouro> GetLogradouroByClienteId(int id)
        {

            var query = $"SELECT * FROM TB_Logradouro WHERE ClienteId = {id}";
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Logradouro>(query).ToList();

            }
        }
        public Logradouro GetLogradouroById(int id, int clienteId)
        {
            using (var connection = _context.CreateConnection())
            {
                return connection.Query<Logradouro>("SELECT * FROM TB_Logradouros WHERE Id = @Id AND ClienteId = @ClienteId", new { Id = id, ClienteId = clienteId }).FirstOrDefault();
            }
        }

        public void CreateLogradouro(Logradouro logradouro)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "INSERT INTO TB_Logradouros (Rua, Bairro, Cidade, Estado, Pais, Cep, ClienteId) VALUES (@Rua, @Bairro, @Cidade, @Estado, @Pais, @Cep, @ClienteId)";
                connection.Execute(sql, logradouro);
            }
        }

        public void UpdateLogradouro(Logradouro logradouro)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "UPDATE TB_Logradouros SET Rua = @Rua, Bairro = @Bairro, Cidade = @Cidade, Estado = @Estado, Pais = @Pais, Cep = @Cep WHERE Id = @Id AND ClienteId = @ClienteId";
                connection.Execute(sql, logradouro);
            }
        }

        public void DeleteLogradouro(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string sql = "DELETE FROM TB_Logradouros WHERE Id = @Id"; connection.Execute(sql, new { Id = id });
            }
        }
    }

}