namespace Vendinha.Api.Models
{
    public class Divida
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Valor { get; set; }
        public bool Paga { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime? DataPagamento { get; set; }

        public void MarcarComoPaga()
        {
            Paga = true;
            DataPagamento = DateTime.Now;
        }
    }
}
