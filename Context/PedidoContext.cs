using Microsoft.EntityFrameworkCore;
using WebPedido.Models;

namespace WebPedido.Context
{
    public class PedidoContext :DbContext
    {
        public PedidoContext(DbContextOptions<PedidoContext> options) : base(options)
        {

        }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemPedido>()
                .Property(p => p.PrecoUnitario)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<ItemPedido>()
                .Property(p => p.PrecoUnitario)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");
        }



    }
}
