using System;
using CursoEFCore.Aulas.Aulas;
using CursoEFCore.Aulas.Data;

namespace CursoEFCore.Aulas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework Core!");

            using var db = new ApplicationContext();

            /* Aulas */
            // Ensure.EnsureDeleted();
            // Ensure.EnsureCreated();
            // HealthCheck.DatabaseHealthCheck();
            // GerenciarConexao.Gerenciar();
            // ExecuteSql.ExecutarComando();
            // ExecuteSql.SqlInjection();
        }
    }
}