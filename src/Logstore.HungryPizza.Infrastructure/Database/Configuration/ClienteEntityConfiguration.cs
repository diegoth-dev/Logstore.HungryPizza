using Logstore.HungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logstore.HungryPizza.Infrastructure.Database.Configuration
{
    public class ClienteEntityConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.Property(e => e.Nome)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.Telefone)
                    .HasMaxLength(12)
                    .IsUnicode(false);

            builder.HasOne(d => d.Endereco)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK_Cliente_Endereco_Id");
        }
    }
}