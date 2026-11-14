using Microsoft.AspNetCore.Mvc;
using Vendinha.Api.Models;
using Vendinha.Api.Services;

namespace Vendinha.Api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : BaseController
    {
        private readonly ClienteService _service;

        public ClientesController(ClienteService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Listar(string? nome = null, int pagina = 1)
        {
            if (pagina < 1)
                return BadRequest(new { mensagem = "A página deve ser maior ou igual a 1." });

            const int tamanhoPagina = 10;

            // O service já devolve filtrado e ordenado; aqui só separa a página
            var clientes = _service.Listar(nome);

            var itens = clientes
                .Skip((pagina - 1) * tamanhoPagina)
                .Take(tamanhoPagina)
                .Select(c => new
                {
                    c.Id,
                    c.NomeCompleto,
                    c.Cpf,
                    c.Email,
                    c.DataNascimento,
                    c.Idade,
                    c.TotalDividas
                });

            return Ok(new
            {
                pagina,
                tamanhoPagina,
                totalRegistros = clientes.Count,
                totalPaginas = (int)Math.Ceiling(clientes.Count / (double)tamanhoPagina),
                itens
            });
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var cliente = _service.Buscar(id);

            if (cliente == null)
                return NotFound(new { mensagem = "Cliente não encontrado." });

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Criar(ClienteRequest request)
        {
            var resultado = _service.Criar(request, out var cliente);
            if (!resultado.DeuCerto)
                return RespostaDeErro(resultado);

            return CreatedAtAction(nameof(Buscar), new { id = cliente!.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, ClienteRequest request)
        {
            var resultado = _service.Atualizar(id, request);
            if (!resultado.DeuCerto)
                return RespostaDeErro(resultado);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id, bool confirmar = false)
        {
            var resultado = _service.Excluir(id, confirmar, out var dividaEmAberto);

            // Com dívida em aberto e sem confirmação: pergunta e mostra a dívida
            if (resultado.Tipo == TipoResultado.Conflito && dividaEmAberto != null)
            {
                return Conflict(new
                {
                    mensagem = resultado.Mensagem,
                    dividaEmAberto = new
                    {
                        dividaEmAberto.Valor,
                        dividaEmAberto.DataCriacao
                    }
                });
            }

            if (!resultado.DeuCerto)
                return RespostaDeErro(resultado);

            return NoContent();
        }
    }
}
