using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.ToTable("departamentos");

            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(d => d.Descricao).HasColumnName("descricao").HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(d => d.Ativo).HasColumnName("ativo").HasColumnType("VARCHAR(80)");

            builder
                .HasMany(d => d.Funcionarios)
                .WithOne(f => f.Departamento)
                .OnDelete(DeleteBehavior.Cascade);

            // Aula sobre indices
            /*
            builder
                .HasIndex(d => d.Descricao)
                .HasDatabaseName("ix_indice_simples")
                .IsUnique();
            */

            // Aula sobre indices
            builder
                .HasIndex(d => new {d.Descricao, d.Ativo})
                .HasDatabaseName("ix_indice_composto")
                .HasFilter("descricao IS NOT NULL")
                .HasFillFactor(80)
                .IsUnique();
        }
    }
}