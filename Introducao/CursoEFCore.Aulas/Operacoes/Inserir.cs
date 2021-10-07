using System;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using CursoEFCore.Aulas.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Operacoes
{
    public class Inserir
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

            using var db = new ApplicationContext();

            /* Formas de inserir registros */
            db.Entry(produto).State = EntityState.Added;
            db.Add(produto);
            db.Produtos.Add(produto);        // melhor forma
            db.Set<Produto>().Add(produto);  // melhor forma

            var qtdRegistrosInseridos = db.SaveChanges();
            Console.WriteLine($"Saving changes... {qtdRegistrosInseridos} rows affected");
        }
    }
}