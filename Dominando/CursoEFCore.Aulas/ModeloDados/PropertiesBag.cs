using System;
using System.Collections.Generic;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.ModeloDados
{
    public class PropertiesBag : SetupHelper
    {
        public static void Executar()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var configuracao = new Dictionary<string, object>
                {
                    ["chave"] = "SenhaDoBancoDeDados",
                    ["valor"] = Guid.NewGuid().ToString(),
                };

                db.Configuracoes.AddRange(configuracao);
                db.SaveChanges();
            }

            using (var db = new ApplicationContext())
            {
                var configuracoes = db.Configuracoes
                    .AsNoTracking()
                    .Where(x => x["chave"] == "SenhaDoBancoDeDados")
                    .ToArray();

                foreach (var configuracao in configuracoes)
                {
                    Console.WriteLine($"Chave: {configuracao["chave"]} - Valor: {configuracao["valor"]}");
                }
            }
        }
    }
}