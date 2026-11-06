using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vendinha.Api.Data;
using Vendinha.Api.Models;

namespace Vendinha.Api.Controllers
{
    [ApiController]
    [Route("api/clientes/{clienteId}/dividas")]
    public class DividasController : ControllerBase
    {
        private readonly VendinhaContext _context;

        public DividasController(VendinhaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar(int clienteId)
        {
            if (!_context.Clientes.Any(c => c.Id == clienteId))
                return NotFound("Cliente não encontrado.");

            var dividas = _context.Dividas
                .Where(d => d.ClienteId == clienteId)
                .AsEnumerable() // o SQLite não ordena decimal/data no banco, então ordena em memória
                .OrderByDescending(d => d.DataCriacao);

            return Ok(dividas);
        }

        [HttpPost]
        public IActionResult Criar(int clienteId, DividaRequest request)
        {
            var cliente = _context.Clientes
                .Include(c => c.Dividas)
                .FirstOrDefault(c => c.Id == clienteId);

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            if (request.Valor <= 0)
                return BadRequest("O valor da dívida deve ser maior que zero.");

            if (cliente.TemDividaEmAberto())
                return Conflict("O cliente já possui uma dívida em aberto.");

            var divida = new Divida
            {
                ClienteId = clienteId,
                Valor = request.Valor,
                Paga = false,
                DataCriacao = DateTime.Now
            };

            _context.Dividas.Add(divida);
            _context.SaveChanges();

            return Created($"api/clientes/{clienteId}/dividas", divida);
        }

        [HttpPatch("{dividaId}/pagar")]
        public IActionResult Pagar(int clienteId, int dividaId)
        {
            // Filtra também pelo cliente para não pagar a dívida de outra pessoa
            var divida = _context.Dividas
                .FirstOrDefault(d => d.Id == dividaId && d.ClienteId == clienteId);

            if (divida == null)
                return NotFound("Dívida não encontrada para este cliente.");

            if (divida.Paga)
                return Conflict("Esta dívida já está paga.");

            divida.MarcarComoPaga();
            _context.SaveChanges();

            return Ok(divida);
        }
    }
}
