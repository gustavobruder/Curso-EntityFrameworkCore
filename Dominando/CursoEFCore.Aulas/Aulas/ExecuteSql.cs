using System;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Aulas
{
    public class ExecuteSql
    {
        public static void ExecutarComando()
        {
            using var db = new ApplicationContext();

            // Primeira opção
            using (var cmd = db.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "SELECT 1";
                cmd.ExecuteNonQuery();
            }
            var descricao = "DescricaoTop";

            // Segunda opção
            db.Database.ExecuteSqlRaw("UPDATE departamentos SET descricao = {0} WHERE id = 1", descricao);

            // Terceira opção
            db.Database.ExecuteSqlInterpolated($"UPDATE departamentos SET descricao = {descricao} WHERE id = 1");
        }

        public static void SqlInjection()
        {
            using var db = new ApplicationContext();

            db.Departamentos.AddRange(
                new Departamento
                {
                    Descricao = "Departamento 1",
                },
                new Departamento
                {
                    Descricao = "Departamento 2",
                }
            );
            db.SaveChanges();

            // Errado! Risco de SqlInjection
            var descricaoFalha = "Teste ' or 1='1";
            db.Database.ExecuteSqlRaw($"UPDATE departamentos SET descricao = 'AtaqueSqlInjection' WHERE descricao = '{descricaoFalha}'");

            foreach (var departamento in db.Departamentos.AsNoTracking())
            {
                Console.WriteLine($"Id: {departamento.Id}, Descricao: {departamento.Descricao}");
            }
        }
    }
}