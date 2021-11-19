﻿using System;
using CursoEFCore.Aulas.Aulas;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.TiposCarregamento;

namespace CursoEFCore.Aulas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework Core!");

            using var db = new ApplicationContext();

            /* Aulas */

            Console.WriteLine("Aulas sobre 'Database' e 'Conexões'");
            // Ensure.EnsureDeleted();
            // Ensure.EnsureCreated();
            // HealthCheck.DatabaseHealthCheck();
            // GerenciarConexao.Gerenciar();
            // ExecuteSql.ExecutarComando();
            // ExecuteSql.SqlInjection();

            Console.WriteLine("Aulas sobre 'Tipos de Carregamento'");
            // Eager.Executar();
            // Explicitly.Executar();
            // LazyLoad.Executar();
        }
    }
}