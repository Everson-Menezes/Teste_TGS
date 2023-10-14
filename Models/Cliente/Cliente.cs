using System.Collections.Generic;

namespace Teste_TGS.Models
{
    public class Cliente
    {
        public int Id { get; set; }// Poderia usar como chave de identificação unica o tipo guid
        public string Nome { get; set; }
        public string Email { get; set; }
        public byte[] LogoTipo { get; set; }
        public List<Logradouro> Logradouros { get; set; }
    }
}