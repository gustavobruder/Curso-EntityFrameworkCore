using System;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.ModeloDados
{
    public class PropagacaoDados : SetupHelper
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var script = db.Database.GenerateCreateScript();
            Console.WriteLine(script);
        }
    }
}