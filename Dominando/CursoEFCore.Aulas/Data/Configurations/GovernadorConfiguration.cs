using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class GovernadorConfiguration : IEntityTypeConfiguration<Governador>
    {
        public void Configure(EntityTypeBuilder<Governador> builder)
        {
            builder.ToTable("governadores");

            builder.HasKey(g => g.Id);
            builder.Property(g => g.Id).HasColumnName("id").IsRequired();
            builder.Property(g => g.Nome).HasColumnName("nome").IsRequired();
            builder.Property(g => g.Idade).HasColumnName("idade");
            builder.Property(g => g.Partido).HasColumnName("partido");
        }
    }
}