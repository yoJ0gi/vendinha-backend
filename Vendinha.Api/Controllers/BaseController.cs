using Microsoft.AspNetCore.Mvc;
using Vendinha.Api.Services;

namespace Vendinha.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        // Transforma o Resultado de erro em 400, 404 ou 409, sempre no formato { "mensagem": "..." }
        protected IActionResult RespostaDeErro(Resultado resultado)
        {
            var corpo = new { mensagem = resultado.Mensagem };

            switch (resultado.Tipo)
            {
                case TipoResultado.NaoEncontrado:
                    return NotFound(corpo);
                case TipoResultado.Conflito:
                    return Conflict(corpo);
                default:
                    return BadRequest(corpo);
            }
        }
    }
}
