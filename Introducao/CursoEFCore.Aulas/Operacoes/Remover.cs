using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Operacoes
{
    public class Remover
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.Find(2);

            /* Formas de deletar registros */
            // db.Entry(cliente).State = EntityState.Deleted;
            // db.Remove(cliente);
            db.Clientes.Remove(cliente);

            db.SaveChanges();
        }
    }
}