using Logstore.HungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logstore.HungryPizza.Infrastructure.Database.Configuration
{
    public class ProdutoEntityConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.Property(e => e.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.VlUnitario).HasColumnType("decimal(18, 2)");
        }
    }
}