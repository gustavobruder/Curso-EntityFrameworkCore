using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;

namespace CursoEFCore.Aulas.Transacoes
{
    public class TransacaoRollback : SetupHelper
    {
        public static void Executar()
        {
            CadastrarLivro();

            using (var db = new ApplicationContext())
            {
                var transacao = db.Database.BeginTransaction();

                try
                {
                    var livro = db.Livros.First(x => x.Id == 1);
                    livro.Autor = "Rafael Almeida";
                    db.SaveChanges();

                    db.Livros.Add(new Livro
                    {
                        Titulo = "Dominando o Entity Framework Core",
                        Autor = "Rafael Almeida".PadRight(16, '*')
                    });
                    db.SaveChanges();

                    transacao.Commit();
                }
                catch (Exception e)
                {
                    transacao.Rollback();
                }
            }
        }

        private static void CadastrarLivro()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                db.Livros.Add(new Livro
                {
                    Titulo = "Introdução ao Entity Framework Core",
                    Autor = "Gustavo Bruder"
                });
                db.SaveChanges();
            }
        }
    }
}