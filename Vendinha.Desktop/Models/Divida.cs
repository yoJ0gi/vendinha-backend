namespace Vendinha.Desktop.Models
{
    public class Divida
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public bool Paga { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataPagamento { get; set; }

        // Texto pronto para mostrar na tela
        public string Situacao
        {
            get { return Paga ? "Paga" : "Em aberto"; }
        }
    }
}
