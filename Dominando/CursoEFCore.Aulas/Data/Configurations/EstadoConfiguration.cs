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
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.Nome).HasColumnName("nome").HasColumnType("VARCHAR(80)").IsRequired();

            builder
                .HasOne(e => e.Governador)
                .WithOne(g => g.Estado)
                .HasForeignKey<Governador>(g => g.EstadoId);

            builder
                .HasMany(e => e.Cidades)
                .WithOne(c => c.Estado)
                .HasForeignKey(c => c.EstadoId)
                .IsRequired(false); // tornar o relacionamento opcional

            // Aula sobre 'Relacionamento One to One'
            builder.Navigation(e => e.Governador).AutoInclude();

            // Aula sobre 'Propagacao de Dados'
            /*
            builder.HasData(
                new Estado {Id = 1, Nome = "Santa Catarina"},
                new Estado {Id = 2, Nome = "Parana"},
                new Estado {Id = 3, Nome = "Rio Grande do Sul"}
            );
            */
        }
    }
}