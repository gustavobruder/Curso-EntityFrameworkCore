using System;
using System.Linq;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Operacoes;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello Entity Framework Core!");

            using var db = new ApplicationContext();

            // - Validar migrações pendentes (não aplicadas)
            var existeMigracoesPendentes = db.Database.GetPendingMigrations().Any();
            if (existeMigracoesPendentes)
            {
                /*
                // - Aplicar as migrações ao iniciar a solução.
                // - Não indicado para ambiente de produção, apenas para desenvolvimento

                db.Database.Migrate();
                */
            }
            else
            {
                Console.WriteLine("Application starting up...");

                Inserir.Executar();
                InserirVarios.Executar();
                Consultar.Executar();
                Atualizar.Executar();
                Remover.Executar();
                CarregamentoAdiantado.Executar();
            }
        }
    }
}