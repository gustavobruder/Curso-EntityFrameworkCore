using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;

namespace CursoEFCore.Aulas.TiposCarregamento
{
    public class LazyLoad : SetupHelper
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            InserirDados(db);

            // desabilitar o lazy loading manualmente
            // db.ChangeTracker.LazyLoadingEnabled = false;

            var departamentos = db.Departamentos.ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine($"Departamento: {departamento.Descricao}");

                if (departamento.Funcionarios?.Any() ?? false)
                {
                    foreach (var funcionario in departamento.Funcionarios)
                    {
                        Console.WriteLine($"\tFuncionario: {funcionario.Nome}");
                    }
                }
                else
                {
                    Console.WriteLine("\tNenhum funcionario encontrado!");
                }
            }
        }
    }
}