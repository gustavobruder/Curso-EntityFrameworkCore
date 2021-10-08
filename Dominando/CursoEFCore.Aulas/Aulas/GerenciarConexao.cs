using System;
using System.Diagnostics;
using System.Linq;
using CursoEFCore.Aulas.Data;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Aulas
{
    public class GerenciarConexao
    {
        public static void Gerenciar()
        {
            using var db = new ApplicationContext();

            // warmup
            db.Departamentos.AsNoTracking().Any();

            _count = 0;
            ManageConnectionState(false);
            _count = 0;
            ManageConnectionState(true);
        }

        private static int _count;

        private static void ManageConnectionState(bool gerenciarConexao)
        {
            using var db = new ApplicationContext();
            var watch = Stopwatch.StartNew();

            var conexao = db.Database.GetDbConnection();
            conexao.StateChange += (_, _) => ++_count;

            if (gerenciarConexao)
            {
                conexao.Open();
            }

            for (var i = 0; i < 200; i++)
            {
                db.Departamentos.AsNoTracking().Any();
            }

            watch.Stop();
            var mensagem = $"Tempo: {watch.Elapsed}, Abri conexao: {gerenciarConexao}, Contador: {_count}";
            Console.WriteLine(mensagem);
        }
    }
}