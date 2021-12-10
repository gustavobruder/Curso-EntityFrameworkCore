using System;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoEFCore.Aulas.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Conversor> Conversores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Governador> Governadores { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Ator> Atores { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string server = "localhost";
            const string port = "1433";
            const string user = "SA";
            const string password = "Curso#Entity";
            const string database = "CursoEFCore";
            var connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

            optionsBuilder
                .UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information)
                // .UseLazyLoadingProxies() // habilitar carregamento lento (lazy)
                ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            // Filtro global de consulta
            // modelBuilder.Entity<Departamento>().HasQueryFilter(d => !d.Excluido);

            // Aula sobre 'Collations' - Filtro global para todos os campos 
            // 'CI' -> Case Insensitive (A | a | B | b)
            // 'AI' -> Accent Insensitive (â | ã | õ )
            // modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");

            // Aula sobre 'Collations' - Filtro para um campo especifico
            // modelBuilder.Entity<Departamento>().Property(d => d.Descricao).UseCollation("SQL_Latin1_General_CP1_CS_AS");

            // Aula sobre 'Sequences'
            modelBuilder
                .HasSequence<int>("MinhaSequencia", "sequencias")
                .StartsAt(1)
                .IncrementsBy(2)
                .HasMin(1)
                .HasMax(10)
                .IsCyclic() // reiniciar o valor da sequencia quando chegar no maximo
                ;

            modelBuilder.Entity<Departamento>().Property(d => d.Id).HasDefaultValueSql("NEXT VALUE FOR sequencias.MinhaSequencia");
        }
    }
}