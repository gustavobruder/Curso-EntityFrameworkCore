using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class FuncionarioConfiguration : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("funcionarios");

            builder.HasKey(f => f.Id);
            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(f => f.Nome).HasColumnName("nome").HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(f => f.CPF).HasColumnName("cpf").HasColumnType("CHAR(11)").IsRequired();
            builder.Property(f => f.DepartamentoId).HasColumnName("departamento_id").IsRequired();

            builder
                .HasOne(f => f.Departamento)
                .WithMany(d => d.Funcionarios)
                .HasForeignKey(f => f.DepartamentoId);
        }
    }
}