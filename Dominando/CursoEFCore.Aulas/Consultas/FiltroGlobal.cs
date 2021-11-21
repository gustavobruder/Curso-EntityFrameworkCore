using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Consultas
{
    public class FiltroGlobal : SetupHelper
    {
        public static void Configurar()
        {
            using var db = new ApplicationContext();
            InserirDados(db);

            var departamentos = db.Departamentos.Where(d => d.Id > 0).ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Departamento: {departamento.Descricao} - Excluido: {departamento.Excluido}");
            }
        }

        public static void Ignorar()
        {
            using var db = new ApplicationContext();
            InserirDados(db);

            var departamentos = db.Departamentos.IgnoreQueryFilters().Where(d => d.Id > 0).ToList();

            foreach (var departamento in departamentos)
            {
                Console.WriteLine($"Departamento: {departamento.Descricao} - Excluido: {departamento.Excluido}");
            }
        }
    }
}