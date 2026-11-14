using Microsoft.AspNetCore.Mvc;
using Vendinha.Api.Models;
using Vendinha.Api.Services;

namespace Vendinha.Api.Controllers
{
    [ApiController]
    [Route("api/clientes/{clienteId}/dividas")]
    public class DividasController : BaseController
    {
        private readonly DividaService _service;

        public DividasController(DividaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Listar(int clienteId)
        {
            var dividas = _service.Listar(clienteId);

            if (dividas == null)
                return NotFound(new { mensagem = "Cliente não encontrado." });

            return Ok(dividas);
        }

        [HttpPost]
        public IActionResult Criar(int clienteId, DividaRequest request)
        {
            var resultado = _service.Criar(clienteId, request.Valor, out var divida);
            if (!resultado.DeuCerto)
                return RespostaDeErro(resultado);

            return Created($"api/clientes/{clienteId}/dividas", divida);
        }

        [HttpPatch("{dividaId}/pagar")]
        public IActionResult Pagar(int clienteId, int dividaId)
        {
            var resultado = _service.Pagar(clienteId, dividaId, out var divida);
            if (!resultado.DeuCerto)
                return RespostaDeErro(resultado);

            return Ok(divida);
        }
    }
}
