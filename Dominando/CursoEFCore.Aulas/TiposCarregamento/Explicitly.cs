using System;
using System.Linq;
using CursoEFCore.Aulas.Data;

namespace CursoEFCore.Aulas.TiposCarregamento
{
    public class Explicitly : SetupLoader
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            InserirDados(db);

            var departamentos = db.Departamentos.ToList();

            foreach (var departamento in departamentos)
            {
                if (departamento.Id == 2)
                {
                    // Carrega a propriedade de navegacao informada
                    // db.Entry(departamento).Collection(d => d.Funcionarios).Load();

                    // Carrega a propriedade de navegacao informada podendo realizar operacoes em cima
                    db.Entry(departamento).Collection(d => d.Funcionarios).Query().Where(f => f.Id > 2).ToList();
                }

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