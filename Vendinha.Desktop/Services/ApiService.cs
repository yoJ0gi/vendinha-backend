using System.Net.Http.Json;
using Vendinha.Desktop.Models;

namespace Vendinha.Desktop.Services
{
    // Classe base de ClienteService e DividaService: o endereço da API fica em um lugar só
    public class ApiService
    {
        // Mesma porta do perfil "http" em Vendinha.Api/Properties/launchSettings.json
        protected readonly HttpClient http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5089/")
        };

        // Quando a API recusa (400, 404, 409), ela devolve { "mensagem": "..." }
        protected static async Task<string?> LerErro(HttpResponseMessage resposta)
        {
            if (resposta.IsSuccessStatusCode)
                return null;

            try
            {
                var erro = await resposta.Content.ReadFromJsonAsync<RespostaErro>();
                if (erro != null && !string.IsNullOrWhiteSpace(erro.Mensagem))
                    return erro.Mensagem;
            }
            catch
            {
                // a resposta não veio no formato { "mensagem": "..." }
            }

            return "A API recusou a operação. Confira os dados informados.";
        }
    }
}
