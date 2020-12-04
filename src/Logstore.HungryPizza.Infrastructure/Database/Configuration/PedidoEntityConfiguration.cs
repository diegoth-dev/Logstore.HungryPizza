using Logstore.HungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logstore.HungryPizza.Infrastructure.Database.Configuration
{
    public class PedidoEntityConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.Property(e => e.DtPedido).HasColumnType("datetime");

            builder.Property(e => e.VlTotal).HasColumnType("decimal(18, 2)");

            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK_Pedido_Cliente_Id");

            builder.HasOne(d => d.Endereco)
                .WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEndereco)
                .HasConstraintName("FK_Pedido_Endereco_Id");
        }
    }
}