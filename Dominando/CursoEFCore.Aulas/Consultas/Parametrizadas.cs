using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Consultas
{
    public class Parametrizadas : SetupHelper
    {
        public static void Consultar()
        {
            using var db = new ApplicationContext();
            InserirDados(db);

            const int id = 0;
            var departamentos = db.Departamentos
                .FromSqlRaw("SELECT * FROM departamentos WHERE id > {0}", id) // sql 'raw'
                .Where(d => !d.Excluido) // sql 'linq'
                .ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Departamento: {departamento.Descricao}");
            }
        }
    }
}