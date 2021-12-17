using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            // modelo 'tabela por hierarquia'
            /*
            builder
                .ToTable("pessoas")
                .HasDiscriminator<int>("tipo_pessoa")
                .HasValue<Pessoa>(3)
                .HasValue<Instrutor>(6)
                .HasValue<Aluno>(99)
                ;
            */

            // modelo 'tabela por tipo'
            builder.ToTable("pessoas");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id").IsRequired();
            builder.Property(p => p.Nome).HasColumnName("nome").IsRequired();
        }
    }

    public class InstrutorConfiguration : IEntityTypeConfiguration<Instrutor>
    {
        public void Configure(EntityTypeBuilder<Instrutor> builder)
        {
            // modelo 'tabela por tipo'
            builder.ToTable("instrutores");

            builder.Property(i => i.Desde).HasColumnName("desde");
            builder.Property(i => i.Tecnologia).HasColumnName("tecnologia");
        }
    }

    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            // modelo 'tabela por tipo'
            builder.ToTable("alunos");

            builder.Property(a => a.Idade).HasColumnName("idade");
            builder.Property(a => a.DataContrato).HasColumnName("data_contrato");
        }
    }
}