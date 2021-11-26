using System;
using CursoEFCore.Aulas.Conversores;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class ConversorConfiguration : IEntityTypeConfiguration<Conversor>
    {
        public void Configure(EntityTypeBuilder<Conversor> builder)
        {
            builder.ToTable("conversores");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).HasColumnName("id").IsRequired();
            builder.Property(c => c.Ativo).HasColumnName("ativo");
            builder.Property(c => c.Excluido).HasColumnName("excluido");
            builder.Property(c => c.Versao).HasColumnName("versao");
            builder.Property(c => c.EnderecoIp).HasColumnName("endereco_ip");
            builder.Property(c => c.Status).HasColumnName("status");

            // Aula sobre 'Conversao de valores'
            var conversao1 = new ValueConverter<Versao, string>(v => v.ToString(), v => (Versao) Enum.Parse(typeof(Versao), v));
            var conversao2 = new EnumToStringConverter<Versao>();
            var conversao3 = new ConversorCustomizado();

            builder
                .Property(c => c.Status)
                .HasConversion(conversao3) // v5

                /*
                .HasConversion(conversao2) // v4
                .HasConversion(conversao1) // v3
                .HasConversion(v => v.ToString(), v => (Versao) Enum.Parse(typeof(Versao), v))  // v2
                .HasConversion<string>() // v1
                */
                ;
        }
    }
}