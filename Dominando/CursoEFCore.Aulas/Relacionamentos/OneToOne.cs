using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Relacionamentos
{
    public class OneToOne : SetupHelper
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var estado = new Estado
            {
                Nome = "Sao Paulo",
                Governador = new Governador {Nome = "Gustavo Bruder"},
            };

            db.Estados.Add(estado);
            db.SaveChanges();

            var estados = db.Estados.AsNoTracking().ToList();

            estados.ForEach(e =>
            {
                Console.WriteLine($"Estado: {e.Nome}, Governador: {e.Governador.Nome}");
            });
        }
    }
}