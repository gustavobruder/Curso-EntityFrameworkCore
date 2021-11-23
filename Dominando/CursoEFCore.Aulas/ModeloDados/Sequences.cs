using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;

namespace CursoEFCore.Aulas.ModeloDados
{
    public class Sequences : SetupHelper
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            InserirDados(db);
        }
    }
}