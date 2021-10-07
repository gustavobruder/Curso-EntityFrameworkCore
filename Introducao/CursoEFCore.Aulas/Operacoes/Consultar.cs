using System;
using System.Linq;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Operacoes
{
    public class Consultar
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();

            /* Formas de consulta (Sintaxe X Métodos Linq) */
            var consultaPorSintaxe = (from c in db.Clientes where c.Id > 0 select c).ToList();
            var consultaPorLinq = db.Clientes.Where(c => c.Id > 0).ToList();

            // Apenas método FIND!
            // busca primeiro em memória, se não encontrar busca no banco
            var cliente1 = db.Clientes.Find(2);

            // busca diretamente no banco, sem vasculhar na memória
            var cliente2 = db.Clientes.FirstOrDefault(c => c.Id == 2);
        }

        public static void ExecutarComTracking()
        {
            using var db = new ApplicationContext();

            Console.WriteLine("Searching with tracking...");
            var consultaComTracking = db.Clientes.Where(c => c.Id > 0).ToList();

            foreach (var cliente in consultaComTracking)
            {
                Console.WriteLine($"Searching for: {cliente.Id}");
                db.Clientes.Find(cliente.Id);
            }
        }

        public static void ExecutarSemTracking()
        {
            using var db = new ApplicationContext();

            Console.WriteLine("Searching without tracking...");
            var consultaSemTracking = db.Clientes.AsNoTracking().Where(c => c.Id > 0).ToList();

            foreach (var cliente in consultaSemTracking)
            {
                Console.WriteLine($"Searching for: {cliente.Id}");
                db.Clientes.Find(cliente.Id);
            }
        }
    }
}