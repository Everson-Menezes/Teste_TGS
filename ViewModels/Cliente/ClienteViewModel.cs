using System.Collections.Generic;

namespace Teste_TGS.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }// Poderia usar como chave de identificação unica o tipo guid
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Logotipo { get; set; }
        // public List<Logradouro> Logradouro { get; set; }
    }
}