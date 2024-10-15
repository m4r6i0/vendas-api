using Microsoft.EntityFrameworkCore;
using VendasAPI.Domain.Entities;

namespace VendasAPI.Data
{
    public class VendasDbContext : DbContext
    {
        public VendasDbContext(DbContextOptions<VendasDbContext> options) : base(options) { }

        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ItemVenda> ItensVenda { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);

            // Configuração das tabelas Venda e ItemVenda
            modelBuilder.Entity<Venda>().ToTable("Venda");
            modelBuilder.Entity<ItemVenda>().ToTable("ItemVenda");

           
        }
    }
}
