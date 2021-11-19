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
                .LogTo(Console.WriteLine, LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}