namespace Vendinha.Desktop.Models
{
    // Resposta 409 da exclusão: herda a Mensagem de RespostaErro e acrescenta a dívida em aberto
    public class ConfirmacaoExclusao : RespostaErro
    {
        public Divida? DividaEmAberto { get; set; }
    }
}
