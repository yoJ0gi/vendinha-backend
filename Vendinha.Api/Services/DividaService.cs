using Microsoft.EntityFrameworkCore;
using Vendinha.Api.Data;
using Vendinha.Api.Models;

namespace Vendinha.Api.Services
{
    public class DividaService
    {
        private readonly VendinhaContext _context;

        public DividaService(VendinhaContext context)
        {
            _context = context;
        }

        // Devolve null se o cliente não existir
        public List<Divida>? Listar(int clienteId)
        {
            if (!_context.Clientes.Any(c => c.Id == clienteId))
                return null;

            return _context.Dividas
                .Where(d => d.ClienteId == clienteId)
                .AsEnumerable() // o SQLite não ordena decimal/data no banco, então ordena em memória
                .OrderByDescending(d => d.DataCriacao)
                .ToList();
        }

        public Resultado Criar(int clienteId, decimal valor, out Divida? divida)
        {
            divida = null;

            var cliente = _context.Clientes
                .Include(c => c.Dividas)
                .FirstOrDefault(c => c.Id == clienteId);

            if (cliente == null)
                return new Resultado(TipoResultado.NaoEncontrado, "Cliente não encontrado.");

            if (valor <= 0)
                return new Resultado(TipoResultado.Invalido, "O valor da dívida deve ser maior que zero.");

            // Regra: um cliente só pode ter uma dívida em aberto
            if (cliente.TemDividaEmAberto())
                return new Resultado(TipoResultado.Conflito, "O cliente já possui uma dívida em aberto.");

            divida = new Divida
            {
                ClienteId = clienteId,
                Valor = valor,
                Paga = false,
                DataCriacao = DateTime.Now
            };

            _context.Dividas.Add(divida);
            _context.SaveChanges();

            return Resultado.Sucesso();
        }

        public Resultado Pagar(int clienteId, int dividaId, out Divida? divida)
        {
            // Filtra também pelo cliente para não pagar a dívida de outra pessoa
            divida = _context.Dividas
                .FirstOrDefault(d => d.Id == dividaId && d.ClienteId == clienteId);

            if (divida == null)
                return new Resultado(TipoResultado.NaoEncontrado, "Dívida não encontrada para este cliente.");

            if (divida.Paga)
                return new Resultado(TipoResultado.Conflito, "Esta dívida já está paga.");

            divida.MarcarComoPaga();
            _context.SaveChanges();

            return Resultado.Sucesso();
        }
    }
}
