using System;
using System.Linq;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.TiposCarregamento
{
    public class Eager : SetupLoader
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            InserirDados(db);

            var departamentos = db.Departamentos.Include(d => d.Funcionarios);

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