using System.ComponentModel;

namespace Teste_TGS.ViewModels
{
    public class LogoTipoViewModel
    {
        public int ID_Imagem { get; set; }
        [DisplayName("Título da Imagem")]
        public string Titulo { get; set; }
        public IFormFile Arquivo { get; set; }
        public string? TipoArquivo { get; set; }
        public string? CaminhoArquivo { get; set; }
        [DisplayName("Imagem")]
        public string imagemString { get; set; }
        public string Mensagem { get; set; }
    }
}