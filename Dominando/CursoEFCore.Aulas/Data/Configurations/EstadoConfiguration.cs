using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.ToTable("estados");

            builder.HasKey(e => e.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Nome).HasColumnName("nome").HasColumnType("VARCHAR(80)").IsRequired();

            // Aula sobre 'Propagacao de Dados'
            builder.HasData(
                new Estado {Id = 1, Nome = "Santa Catarina"},
                new Estado {Id = 2, Nome = "Parana"},
                new Estado {Id = 3, Nome = "Rio Grande do Sul"}
            );
        }
    }
}