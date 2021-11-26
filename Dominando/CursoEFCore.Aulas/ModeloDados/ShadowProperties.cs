using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.ModeloDados
{
    public class ShadowProperties : SetupHelper
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var departamento = new Departamento
            {
                Descricao = "Descricao departemento",
            };

            db.Departamentos.Add(departamento);
            db.Entry(departamento).Property("ultima_atualizacao").CurrentValue = DateTime.Now;
            db.SaveChanges();

            var departamentos = db.Departamentos
                .Where(d => EF.Property<DateTime>(d, "ultima_atualizacao") < DateTime.Now)
                .ToArray();
        }
    }
}