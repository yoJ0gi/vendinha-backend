namespace Vendinha.Api.Models
{
    // Dados que o usuário envia para criar ou atualizar um cliente.
    // Idade e TotalDividas não entram aqui porque são calculados.
    public class ClienteRequest
    {
        public string? NomeCompleto { get; set; }
        public string? Cpf { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? Email { get; set; }
    }
}
