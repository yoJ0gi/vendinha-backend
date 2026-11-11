using System.Net.Http.Json;
using Vendinha.Desktop.Models;

namespace Vendinha.Desktop.Services
{
    public class ClienteService : ApiService
    {
        // GET api/clientes?nome=&pagina=1
        public async Task<PaginaClientes> Listar(string? nome = null, int pagina = 1)
        {
            var url = $"api/clientes?pagina={pagina}";
            if (!string.IsNullOrWhiteSpace(nome))
                url += $"&nome={Uri.EscapeDataString(nome)}";

            var resultado = await http.GetFromJsonAsync<PaginaClientes>(url);
            return resultado ?? new PaginaClientes();
        }

        // GET api/clientes/{id}
        public async Task<Cliente?> Buscar(int id)
        {
            return await http.GetFromJsonAsync<Cliente>($"api/clientes/{id}");
        }

        // POST api/clientes. Devolve a mensagem de erro, ou null se deu certo
        public async Task<string?> Cadastrar(Cliente cliente)
        {
            var resposta = await http.PostAsJsonAsync("api/clientes", cliente);
            return await LerErro(resposta);
        }

        // PUT api/clientes/{id}. Devolve a mensagem de erro, ou null se deu certo
        public async Task<string?> Atualizar(Cliente cliente)
        {
            var resposta = await http.PutAsJsonAsync($"api/clientes/{cliente.Id}", cliente);
            return await LerErro(resposta);
        }
    }
}
