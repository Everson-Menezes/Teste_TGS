using System.Collections.Generic;

namespace Teste_TGS.Models
{
    public class Logradouro
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public long Cep { get; set; }
    }
}