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
            builder.Property(c => c.Id).HasColumnName("id").IsRequired();
            builder.Property(c => c.Nome).HasColumnName("nome").IsRequired();
            builder.Property(c => c.Telefone).HasColumnName("telefone").HasColumnType("VARCHAR(15)");

            builder.OwnsOne(c => c.Endereco, ownedBuilder =>
            {
                // Caso queira separar em outra tabela
                // ownedBuilder.ToTable("enderecos");

                ownedBuilder.Property(e => e.Logradouro).HasColumnName("logradouro");
                ownedBuilder.Property(e => e.Bairro).HasColumnName("bairro");
                ownedBuilder.Property(e => e.Cidade).HasColumnName("cidade");
                ownedBuilder.Property(e => e.Estado).HasColumnName("estado");
            });
        }
    }
}