using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Consultas
{
    public class SplitQuery : SetupHelper
    {
        public static void Consultar()
        {
            using var db = new ApplicationContext();
            InserirDados(db);

            var departamentos = db.Departamentos
                .Include(d => d.Funcionarios)
                .Where(d => d.Id < 3)
                .AsSplitQuery()
                .ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Departamento: {departamento.Descricao}");
            }
        }
    }
}