using Logstore.HungryPizza.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logstore.HungryPizza.Infrastructure.Database.Configuration
{
    public class EnderecoEntityConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Endereco");

            builder.Property(e => e.Bairro)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Cep)
                .HasMaxLength(9)
                .IsUnicode(false);

            builder.Property(e => e.Complemento)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Logradouro)
                .HasMaxLength(150)
                .IsUnicode(false);

            builder.Property(e => e.Municipio)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Numero)
                .HasMaxLength(5)
                .IsUnicode(false);
        }
    }
}