using CursoEFCore.Aulas.Data;

namespace CursoEFCore.Aulas.Aulas
{
    public class Ensure
    {
        public static void EnsureCreated()
        {
            using var db = new ApplicationContext();

            // Cria o setup do banco de dados completamente
            db.Database.EnsureCreated();
        }

        public static void EnsureDeleted()
        {
            using var db = new ApplicationContext();

            // Excluir o banco de dados por inteiro se ele existir
            db.Database.EnsureDeleted();
        }
    }
}