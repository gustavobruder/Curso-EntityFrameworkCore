using System;
using System.Collections.Generic;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class AtorConfiguration : IEntityTypeConfiguration<Ator>
    {
        public void Configure(EntityTypeBuilder<Ator> builder)
        {
            builder.ToTable("atores");

            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("id").IsRequired();
            builder.Property(a => a.Nome).HasColumnName("nome").IsRequired();

            // configuration da tabela 'atores_filmes' - v1
            /*builder
                .HasMany(a => a.Filmes)
                .WithMany(a => a.Atores)
                .UsingEntity(a => a.ToTable("atores_filmes"));*/

            builder
                .HasMany(a => a.Filmes)
                .WithMany(a => a.Atores)
                .UsingEntity<Dictionary<string, object>>(
                    joinEntityName: "atores_filmes",
                    configureRight: x => x.HasOne<Filme>().WithMany().HasForeignKey("filme_id"),
                    configureLeft: x => x.HasOne<Ator>().WithMany().HasForeignKey("ator_id"),
                    configureJoinEntityType: x =>
                    {
                        // coluna adicional
                        x.Property<DateTime>("cadastrado_em").HasDefaultValueSql("GETDATE()");
                    }
                );
        }
    }
}