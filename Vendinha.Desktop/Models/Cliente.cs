namespace Vendinha.Desktop.Models
{
    // Mesmo formato do cliente que a API devolve em JSON
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string? Email { get; set; }

        // Calculados pela API: aqui só são lidos
        public int Idade { get; set; }
        public decimal TotalDividas { get; set; }

        // CPF com pontos e traço para mostrar na tela (a API guarda só os números)
        public string CpfFormatado
        {
            get
            {
                if (Cpf.Length != 11)
                    return Cpf;
                return $"{Cpf.Substring(0, 3)}.{Cpf.Substring(3, 3)}.{Cpf.Substring(6, 3)}-{Cpf.Substring(9, 2)}";
            }
        }
    }
}
