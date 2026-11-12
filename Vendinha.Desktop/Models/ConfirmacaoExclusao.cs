namespace Vendinha.Desktop.Models
{
    // Resposta da API (409) quando o cliente a excluir tem dívida em aberto
    public class ConfirmacaoExclusao
    {
        public string Mensagem { get; set; } = string.Empty;
        public Divida? DividaEmAberto { get; set; }
    }
}
