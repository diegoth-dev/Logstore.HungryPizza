using Logstore.HungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logstore.HungryPizza.Infrastructure.Database.Configuration
{
    public class PedidoItemEntityConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItem");

            builder.Property(e => e.VlUnitario).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Pedido)
                .WithMany(p => p.PedidoItems)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK_PedidoItem_Pedido_Id");

            builder.HasOne(d => d.Produto)
                .WithMany(p => p.PedidoItems)
                .HasForeignKey(d => d.IdProduto)
                .HasConstraintName("FK_PedidoItem_Produto_Id");
        }
    }
}