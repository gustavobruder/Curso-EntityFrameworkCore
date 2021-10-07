using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;

namespace CursoEFCore.Aulas.Operacoes
{
    public class Atualizar
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.Find(2);
            cliente.Nome = "Cliente alterado 2";

            // Atualizar todos as colunas da tabela
            // db.Clientes.Update(cliente);

            db.SaveChanges();
        }

        public static void ExecutarComFindPrevio()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.Find(2);

            var clienteDesconectado = new
            {
                Nome = "Nome ComFindPrevio",
                Telefone = "47999556677"
            };

            db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado);
            db.SaveChanges();
        }

        public static void ExecutarSemFindPrevio()
        {
            using var db = new ApplicationContext();

            var cliente = new Cliente
            {
                Id = 2 // pk da tabela
            };

            var clienteDesconectado = new
            {
                Nome = "Nome SemFindPrevio",
                Telefone = "47999554433"
            };

            db.Attach(cliente);
            db.Entry(cliente).CurrentValues.SetValues(clienteDesconectado);

            db.SaveChanges();
        }
    }
}