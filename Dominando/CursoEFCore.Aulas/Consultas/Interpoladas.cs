using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Consultas
{
    public class Interpoladas : SetupHelper
    {
        public static void Consultar()
        {
            using var db = new ApplicationContext();
            InserirDados(db);

            const int id = 1;
            var departamentos = db.Departamentos
                .FromSqlInterpolated($"SELECT * FROM departamentos WHERE id > {id}")
                .ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Departamento: {departamento.Descricao}");
            }
        }
    }
}