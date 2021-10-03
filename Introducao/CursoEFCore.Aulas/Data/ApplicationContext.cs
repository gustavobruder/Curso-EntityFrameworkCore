using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string server = "localhost";
            const string port = "1433";
            const string user = "SA";
            const string password = "Curso#Entity";
            const string database = "CursoEFCore";
            var connectionString = $"Server={server}, {port};Initial Catalog={database};User ID={user};Password={password}";

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}