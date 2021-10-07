using System;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using CursoEFCore.Aulas.ValueObject;

namespace CursoEFCore.Aulas.Operacoes
{
    public class InserirVarios
    {
        public static void Executar()
        {
            var produto = new Produto
            {
                CodigoBarras = "1234567891234",
                Descricao = "Descricao produto",
                Valor = 10m,
                TipoProduto = TipoProduto.Revenda,
                Ativo = true
            };
            var cliente = new Cliente
            {
                Nome = "Gustavo Bruder",
                Telefone = "47999887766",
                CEP = "99999000",
                Estado = "SC",
                Cidade = "Xanxerê",
            };
            var clientes = new[]
            {
                new Cliente
                {
                    Nome = "Cliente 1",
                    Telefone = "47999887766",
                    CEP = "99999000",
                    Estado = "SC",
                    Cidade = "Xanxerê",
                },
                new Cliente
                {
                    Nome = "Cliente 2",
                    Telefone = "47999887766",
                    CEP = "99999000",
                    Estado = "SC",
                    Cidade = "Xanxerê",
                }
            };

            using var db = new ApplicationContext();

            db.AddRange(produto, cliente);
            db.Clientes.AddRange(clientes);

            var qtdRegistrosInseridos = db.SaveChanges();
            Console.WriteLine($"Saving changes... {qtdRegistrosInseridos} rows affected");
        }
    }
}