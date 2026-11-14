using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Vendinha.Api.Data;
using Vendinha.Api.Models;
using Vendinha.Api.Utils;

namespace Vendinha.Api.Services
{
    public class ClienteService
    {
        private readonly VendinhaContext _context;

        public ClienteService(VendinhaContext context)
        {
            _context = context;
        }

        public List<Cliente> Listar(string? nome)
        {
            var busca = nome?.ToLower();

            // Filtra depois do ToList() porque o lower() do SQLite não converte acentos ("Álvaro") e o ToLower() do C# converte
            return _context.Clientes
                .Include(c => c.Dividas)
                .ToList()
                .Where(c => busca == null || c.NomeCompleto.ToLower().Contains(busca))
                .OrderByDescending(c => c.TotalDividas) // quem mais deve primeiro
                .ThenBy(c => c.NomeCompleto)
                .ToList();
        }

        public Cliente? Buscar(int id)
        {
            return _context.Clientes
                .Include(c => c.Dividas)
                .FirstOrDefault(c => c.Id == id);
        }

        // O cliente criado sai pelo parâmetro out (PDF de Parâmetros)
        public Resultado Criar(ClienteRequest request, out Cliente? cliente)
        {
            cliente = null;

            var erro = Validar(request);
            if (erro != null)
                return new Resultado(TipoResultado.Invalido, erro);

            var cpf = ValidadorCpf.SomenteNumeros(request.Cpf!);

            if (_context.Clientes.Any(c => c.Cpf == cpf))
                return new Resultado(TipoResultado.Conflito, "Já existe um cliente cadastrado com este CPF.");

            cliente = new Cliente
            {
                NomeCompleto = request.NomeCompleto!.Trim(),
                Cpf = cpf,
                DataNascimento = request.DataNascimento!.Value,
                Email = string.IsNullOrWhiteSpace(request.Email) ? null : request.Email.Trim()
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            return Resultado.Sucesso();
        }

        public Resultado Atualizar(int id, ClienteRequest request)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);
            if (cliente == null)
                return new Resultado(TipoResultado.NaoEncontrado, "Cliente não encontrado.");

            var erro = Validar(request);
            if (erro != null)
                return new Resultado(TipoResultado.Invalido, erro);

            var cpf = ValidadorCpf.SomenteNumeros(request.Cpf!);

            // Ignora o próprio cliente na checagem de CPF duplicado
            if (_context.Clientes.Any(c => c.Cpf == cpf && c.Id != id))
                return new Resultado(TipoResultado.Conflito, "Já existe um cliente cadastrado com este CPF.");

            cliente.NomeCompleto = request.NomeCompleto!.Trim();
            cliente.Cpf = cpf;
            cliente.DataNascimento = request.DataNascimento!.Value;
            cliente.Email = string.IsNullOrWhiteSpace(request.Email) ? null : request.Email.Trim();

            _context.SaveChanges();

            return Resultado.Sucesso();
        }

        // Com dívida em aberto e sem confirmação não exclui: devolve Conflito e a dívida sai pelo out
        public Resultado Excluir(int id, bool confirmar, out Divida? dividaEmAberto)
        {
            dividaEmAberto = null;

            var cliente = Buscar(id);
            if (cliente == null)
                return new Resultado(TipoResultado.NaoEncontrado, "Cliente não encontrado.");

            dividaEmAberto = cliente.BuscarDividaEmAberto();

            if (dividaEmAberto != null && !confirmar)
                return new Resultado(TipoResultado.Conflito,
                    "Tem certeza que deseja excluir o cliente, pois ele tem dívidas em aberto?");

            _context.Clientes.Remove(cliente); // as dívidas saem junto (cascade)
            _context.SaveChanges();

            return Resultado.Sucesso();
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

            // Limite para evitar datas digitadas erradas (ex.: 1900 no lugar de 2000)
            if (request.DataNascimento.Value.Date < DateTime.Today.AddYears(-100))
                return "A data de nascimento não pode ser de mais de 100 anos atrás.";

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
