using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;

namespace CursoEFCore.Aulas.Consultas
{
    public class Projecao : SetupHelper
    {
        public static void Projetar()
        {
            using var db = new ApplicationContext();
            InserirDados(db);

            var departamentos = db.Departamentos
                .Where(d => d.Id > 0)
                .Select(d => new
                {
                    Descricao = d.Descricao,
                    Funcionarios = d.Funcionarios.Select(f => f.Nome)
                })
                .ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Departamento: {departamento.Descricao}");

                foreach (var funcionario in departamento.Funcionarios)
                {
                    Console.WriteLine($"\tNome: {funcionario}");
                }
            }
        }
    }
}