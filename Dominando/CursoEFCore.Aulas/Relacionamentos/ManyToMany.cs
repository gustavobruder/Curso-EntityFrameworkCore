using System;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Relacionamentos
{
    public class ManyToMany : SetupHelper
    {
        public static void Executar()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var ator1 = new Ator {Nome = "Gustavo"};
                var ator2 = new Ator {Nome = "Felipe"};
                var ator3 = new Ator {Nome = "Gabriel"};

                var filme1 = new Filme {Descricao = "A volta dos que não foram"};
                var filme2 = new Filme {Descricao = "As longas tranças de um careca"};
                var filme3 = new Filme {Descricao = "Poeira em alto mar"};
                
                ator1.Filmes.Add(filme1);
                ator1.Filmes.Add(filme2);

                ator2.Filmes.Add(filme1);

                filme3.Atores.Add(ator1);
                filme3.Atores.Add(ator2);
                filme3.Atores.Add(ator3);

                db.AddRange(ator1, ator2, filme3);
                db.SaveChanges();
            }

            using (var db = new ApplicationContext())
            {
                foreach (var ator in db.Atores.Include(a => a.Filmes))
                {
                    Console.WriteLine($"Ator: {ator.Nome}");

                    foreach (var filme in ator.Filmes)
                    {
                        Console.WriteLine($"\tFilme: {filme.Descricao}");
                    }
                }
            }
        }
    }
}