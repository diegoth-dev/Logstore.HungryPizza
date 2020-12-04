using Logstore.HungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Logstore.HungryPizza.Infrastructure.Database
{
    public interface IAppDbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}