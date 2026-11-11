namespace Vendinha.Desktop.Models
{
    // Resposta da listagem de clientes: os 10 clientes da página e os dados da paginação
    public class PaginaClientes
    {
        public int Pagina { get; set; }
        public int TamanhoPagina { get; set; }
        public int TotalRegistros { get; set; }
        public int TotalPaginas { get; set; }
        public List<Cliente> Itens { get; set; } = new List<Cliente>();
    }
}
