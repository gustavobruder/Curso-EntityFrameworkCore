using System;
using System.Linq;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoEFCore.Aulas.Data
{
    public class ApplicationContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(x => x.AddConsole());

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string server = "localhost";
            const string port = "1433";
            const string user = "SA";
            const string password = "Curso#Entity";
            const string database = "CursoEFCore";
            var connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging() // exibir os valores dos parametros gerados em querys (conteudo sensivel)
                .UseSqlServer(
                    connectionString,
                    serverBuilder => serverBuilder.EnableRetryOnFailure(
                        maxRetryCount: 2,
                        maxRetryDelay: TimeSpan.FromSeconds(5),
                        errorNumbersToAdd: null
                    ).MigrationsHistoryTable("_migrations_history")
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
            MapearPropriedadesSemConfiguracao(modelBuilder);
        }

        // Dica: caso haja propriedas sem configuração
        private void MapearPropriedadesSemConfiguracao(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var properties = entity.GetProperties();
                var propertiesWithoutConfig = properties
                    .Where(p => p.Name == p.GetDefaultColumnBaseName());

                if (propertiesWithoutConfig.Any())
                {
                    Console.WriteLine("Its is missing some column names configurations...");
                }
            }
        }
    }
}