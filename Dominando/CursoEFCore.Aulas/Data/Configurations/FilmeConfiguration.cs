using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class FilmeConfiguration : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("filmes");

            builder.HasKey(f => f.Id);
            builder.Property(f => f.Id).HasColumnName("id").IsRequired();
            builder.Property(f => f.Descricao).HasColumnName("descriaco").IsRequired();
        }
    }
}