using System;
using CursoEFCore.Aulas.Aulas;
using CursoEFCore.Aulas.Consultas;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.ModeloDados;
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

            Console.WriteLine("Aulas sobre 'Consultas'");
            // FiltroGlobal.Configurar();
            // FiltroGlobal.Ignorar();
            // Projecao.Projetar();
            // Parametrizadas.Consultar();
            // Interpoladas.Consultar();
            // Tags.Consultar();
            // SplitQuery.Consultar();

            Console.WriteLine("Aulas sobre 'Modelos de Dados'");
            // Collations.Executar();
            // Sequences.Executar();
            // PropagacaoDados.Executar();
            // ShadowProperties.Executar();
            // OwnedTypes.Executar();
            // RelacionamentoOneToOne.Executar();
        }
    }
}