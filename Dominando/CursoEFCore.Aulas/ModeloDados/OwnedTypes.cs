using System;
using System.Linq;
using System.Text.Json;
using CursoEFCore.Aulas.Common;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.ModeloDados
{
    public class OwnedTypes : SetupHelper
    {
        public static void Executar()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var cliente = new Cliente
            {
                Nome = "Cliente legal",
                Telefone = "(47) 99988-7766",
                Endereco = new Endereco
                {
                    Bairro = "Centro",
                    Cidade = "Blumenau",
                },
            };

            db.Clientes.Add(cliente);
            db.SaveChanges();

            var clientes = db.Clientes.AsNoTracking().ToList();
            var options = new JsonSerializerOptions {WriteIndented = true};

            clientes.ForEach(c =>
            {
                var json = JsonSerializer.Serialize(c, options);
                Console.WriteLine(json);
            });
        }
    }
}