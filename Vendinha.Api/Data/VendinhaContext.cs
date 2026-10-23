using Microsoft.EntityFrameworkCore;
using Vendinha.Api.Models;

namespace Vendinha.Api.Data
{
    
    public class VendinhaContext : DbContext
    {
        public VendinhaContext(DbContextOptions<VendinhaContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Divida> Dividas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(cliente =>
            {
                cliente.Property(c => c.NomeCompleto).HasMaxLength(150).IsRequired();
                cliente.Property(c => c.Cpf).HasMaxLength(11).IsRequired();
                cliente.Property(c => c.Email).HasMaxLength(150);

            
                cliente.HasIndex(c => c.Cpf).IsUnique();

                cliente.HasMany(c => c.Dividas)
                    .WithOne()
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Divida>(divida =>
            {
                divida.Property(d => d.Valor).HasPrecision(10, 2);
            });
        }
    }
}
