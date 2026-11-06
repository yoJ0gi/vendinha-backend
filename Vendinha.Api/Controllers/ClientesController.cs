using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vendinha.Api.Data;
using Vendinha.Api.Models;
using Vendinha.Api.Utils;

namespace Vendinha.Api.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClientesController : ControllerBase
    {
        private readonly VendinhaContext _context;

        public ClientesController(VendinhaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Listar(string? nome = null, int pagina = 1)
        {
            if (pagina < 1)
                return BadRequest("A página deve ser maior ou igual a 1.");

            const int tamanhoPagina = 10;

            // Busca por nome (texto contido) e traz as dívidas junto. O ToList() executa a consulta no banco; o restante é feito em memória, pois TotalDividas é calculado no C# e não existe como coluna.
            var consulta = _context.Clientes
                .Include(c => c.Dividas)
                .Where(c => nome == null || c.NomeCompleto.Contains(nome))
                .ToList();

            var itens = consulta
                .OrderByDescending(c => c.TotalDividas) // quem mais deve primeiro
                .ThenBy(c => c.NomeCompleto)            // desempate por nome
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
                totalRegistros = consulta.Count,
                totalPaginas = (int)Math.Ceiling(consulta.Count / (double)tamanhoPagina),
                itens
            });
        }

        [HttpGet("{id}")]
        public IActionResult Buscar(int id)
        {
            var cliente = _context.Clientes
                .Include(c => c.Dividas)
                .FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Criar(ClienteRequest request)
        {
            var erro = Validar(request);
            if (erro != null)
                return BadRequest(erro);

            var cpf = ValidadorCpf.SomenteNumeros(request.Cpf!);

            if (_context.Clientes.Any(c => c.Cpf == cpf))
                return Conflict("Já existe um cliente cadastrado com este CPF.");

            var cliente = new Cliente
            {
                NomeCompleto = request.NomeCompleto!.Trim(),
                Cpf = cpf,
                DataNascimento = request.DataNascimento!.Value,
                Email = string.IsNullOrWhiteSpace(request.Email) ? null : request.Email.Trim()
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Buscar), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, ClienteRequest request)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            var erro = Validar(request);
            if (erro != null)
                return BadRequest(erro);

            var cpf = ValidadorCpf.SomenteNumeros(request.Cpf!);

            // Ignora o próprio cliente na checagem de CPF duplicado
            if (_context.Clientes.Any(c => c.Cpf == cpf && c.Id != id))
                return Conflict("Já existe um cliente cadastrado com este CPF.");

            cliente.NomeCompleto = request.NomeCompleto!.Trim();
            cliente.Cpf = cpf;
            cliente.DataNascimento = request.DataNascimento!.Value;
            cliente.Email = string.IsNullOrWhiteSpace(request.Email) ? null : request.Email.Trim();

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id, bool confirmar = false)
        {
            var cliente = _context.Clientes
                .Include(c => c.Dividas)
                .FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            var dividaEmAberto = cliente.BuscarDividaEmAberto();

            // Com dívida em aberto e sem confirmação, não exclui: pede confirmação
            if (dividaEmAberto != null && !confirmar)
            {
                return Conflict(new
                {
                    mensagem = "Tem certeza que deseja excluir o cliente, pois ele tem dívidas em aberto?",
                    dividaEmAberto = new
                    {
                        dividaEmAberto.Valor,
                        dividaEmAberto.DataCriacao
                    }
                });
            }

            _context.Clientes.Remove(cliente); // as dívidas saem junto (cascade)
            _context.SaveChanges();

            return NoContent();
        }

        // Devolve a mensagem de erro, ou null se estiver tudo certo
        private static string? Validar(ClienteRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.NomeCompleto))
                return "O nome completo é obrigatório.";

            if (string.IsNullOrWhiteSpace(request.Cpf) || !ValidadorCpf.EhValido(request.Cpf))
                return "CPF inválido.";

            if (request.DataNascimento == null)
                return "A data de nascimento é obrigatória.";

            if (request.DataNascimento.Value.Date > DateTime.Today)
                return "A data de nascimento não pode ser no futuro.";

            if (!string.IsNullOrWhiteSpace(request.Email) && !EmailValido(request.Email))
                return "E-mail em formato inválido.";

            return null;
        }

        private static bool EmailValido(string email)
        {
            try
            {
                var endereco = new MailAddress(email.Trim());
                return endereco.Address == email.Trim() && endereco.Host.Contains('.');
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
