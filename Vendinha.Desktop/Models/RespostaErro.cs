namespace Vendinha.Desktop.Models
{
    // Formato que a API usa em todas as respostas de erro: { "mensagem": "..." }
    public class RespostaErro
    {
        public string Mensagem { get; set; } = string.Empty;
    }
}
