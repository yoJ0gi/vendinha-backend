namespace Vendinha.Desktop.Services
{
    // Classe base dos services: guarda o endereço da API e o HttpClient.
    // ClienteService e DividaService herdam dela, assim o endereço fica em um lugar só.
    public class ApiService
    {
        // Mesma porta do perfil "http" em Vendinha.Api/Properties/launchSettings.json
        protected readonly HttpClient http = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5089/")
        };

        // Quando a API recusa (400, 404, 409), ela devolve a mensagem de erro em texto
        protected static async Task<string?> LerErro(HttpResponseMessage resposta)
        {
            if (resposta.IsSuccessStatusCode)
                return null;

            return await resposta.Content.ReadAsStringAsync();
        }
    }
}
