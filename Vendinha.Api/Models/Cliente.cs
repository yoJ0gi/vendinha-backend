namespace Vendinha.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
        public List<Divida> Dividas { get; set; } = new List<Divida>();

        public int Idade
        {
            get
            {
                var idade = DateTime.Today.Year - DataNascimento.Year;
                if (DateTime.Today < DataNascimento.AddYears(idade))
                    idade--;
                return idade;
            }
        }

        public decimal TotalDividas
        {
            get { return Dividas.Where(d => !d.Paga).Sum(d => d.Valor); }
        }

        public bool TemDividaEmAberto()
        {
            return Dividas.Any(d => !d.Paga);
        }

        public Divida? BuscarDividaEmAberto()
        {
            return Dividas.FirstOrDefault(d => !d.Paga);
        }
    }
}
