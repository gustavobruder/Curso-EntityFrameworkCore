using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(c => c.Telefone).HasColumnType("CHAR(11)");
            builder.Property(c => c.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(c => c.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(c => c.Cidade).HasMaxLength(60).IsRequired();
            builder.Property(c => c.Email).HasColumnType("VARCHAR(80)");

            builder.HasIndex(c => c.Telefone).HasDatabaseName("ix_cliente_telefone");
        }
    }
}