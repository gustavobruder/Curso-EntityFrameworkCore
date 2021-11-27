using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Relacionamentos
{
    public class OneToMany : SetupHelper
    {
        public static void Executar()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var estado = new Estado
                {
                    Nome = "Sao Paulo",
                    Governador = new Governador {Nome = "Gustavo Bruder"},
                };

                estado.Cidades.Add(new Cidade{Nome = "Uberlandia"});
                db.Estados.Add(estado);
                db.SaveChanges();                
            }

            using (var db = new ApplicationContext())
            {
                var estados = db.Estados.ToList();
                estados[0].Cidades.Add(new Cidade{Nome = "Laranjeiras"});

                db.SaveChanges();

                foreach (var estado in db.Estados.Include(e => e.Cidades).AsNoTracking())
                {
                    Console.WriteLine($"Estado {estado.Nome}, Governador: {estado.Governador.Nome}");

                    foreach (var cidade in estado.Cidades)
                    {
                        Console.WriteLine($"\tCidade: {cidade.Nome}");
                    }
                }
            }
        }
    }
}