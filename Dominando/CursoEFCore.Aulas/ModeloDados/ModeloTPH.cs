using System;
using System.Linq;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.ModeloDados
{
    // modelo 'tabela por hierarquia'
    public class ModeloTPH : SetupHelper
    {
        public static void Executar()
        {
            using (var db = new ApplicationContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var pessoa = new Pessoa {Nome = "Fulano de Tal"};
                var instrutor = new Instrutor {Nome = "Rafael Almeida", Desde = DateTime.Now, Tecnologia = ".NET"};
                var aluno = new Aluno {Nome = "Gustavo Bruder", Idade = 18, DataContrato = DateTime.Now.AddDays(-1)};

                db.AddRange(pessoa, instrutor, aluno);
                db.SaveChanges();
            }

            using (var db = new ApplicationContext())
            {
                var pessoas = db.Pessoas.AsNoTracking().ToArray();
                var instrutores = db.Instrutores.AsNoTracking().ToArray();
                var alunos = db.Alunos.AsNoTracking().ToArray();

                Console.WriteLine("Pessoas **********");
                foreach (var pessoa in pessoas)
                {
                    Console.WriteLine($"Id: {pessoa.Id} - {pessoa.Nome}");
                }

                Console.WriteLine("Instrutores **********");
                foreach (var instrutor in instrutores)
                {
                    Console.WriteLine($"Id: {instrutor.Id} - {instrutor.Nome}, Tecnologia: {instrutor.Tecnologia}, Desde: {instrutor.Desde}");
                }

                Console.WriteLine("Alunos **********");
                foreach (var aluno in alunos)
                {
                    Console.WriteLine($"Id: {aluno.Id} - {aluno.Nome}, Idade: {aluno.Idade}, Data de Contrato: {aluno.DataContrato}");
                }
            }
        }
    }
}