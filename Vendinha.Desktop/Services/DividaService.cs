using System.Net.Http.Json;
using Vendinha.Desktop.Models;

namespace Vendinha.Desktop.Services
{
    public class DividaService : ApiService
    {
        // GET api/clientes/{clienteId}/dividas
        public async Task<List<Divida>> Listar(int clienteId)
        {
            var dividas = await http.GetFromJsonAsync<List<Divida>>($"api/clientes/{clienteId}/dividas");
            return dividas ?? new List<Divida>();
        }

        // POST api/clientes/{clienteId}/dividas. Devolve a mensagem de erro, ou null se deu certo
        public async Task<string?> Cadastrar(int clienteId, decimal valor)
        {
            // tipo anônimo (Aula 5) vira o JSON { "valor": 50.00 }
            var resposta = await http.PostAsJsonAsync($"api/clientes/{clienteId}/dividas", new { valor });
            return await LerErro(resposta);
        }

        // PATCH api/clientes/{clienteId}/dividas/{dividaId}/pagar
        public async Task<string?> Pagar(int clienteId, int dividaId)
        {
            var resposta = await http.PatchAsync($"api/clientes/{clienteId}/dividas/{dividaId}/pagar", null);
            return await LerErro(resposta);
        }
    }
}
