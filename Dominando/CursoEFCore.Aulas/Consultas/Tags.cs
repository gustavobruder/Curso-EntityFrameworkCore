using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Consultas
{
    public class Tags : SetupHelper
    {
        public static void Consultar()
        {
            using var db = new ApplicationContext();
            InserirDados(db);

            var departamentos = db.Departamentos
                .TagWith("Comentario enviado junto com a consulta")
                .TagWith("Outro comentario adicionado")
                .ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Departamento: {departamento.Descricao}");
            }
        }
    }
}