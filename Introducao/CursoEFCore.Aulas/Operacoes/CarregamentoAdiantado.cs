using System;
using System.Collections.Generic;
using System.Linq;
using CursoEFCore.Aulas.Data;
using CursoEFCore.Aulas.Domain;
using CursoEFCore.Aulas.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Operacoes
{
    public class CarregamentoAdiantado
    {
        public static void Executar()
        {
            CadastrarPedido();

            using var db = new ApplicationContext();

            var pedidos = db.Pedidos
                .Include(p => p.Itens)
                .ThenInclude(i => i.Pedido)
                .ToList();

            Console.WriteLine($"{pedidos.Count} results found");
        }

        private static void CadastrarPedido()
        {
            using var db = new ApplicationContext();

            var cliente = db.Clientes.First();
            var produto = db.Produtos.First();

            var pedido = new Pedido
            {
                ClienteId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now,
                TipoFrete = TipoFrete.SemFrete,
                Status = StatusPedido.Analise,
                Observacao = "Pedido muito loko",
                Itens = new List<PedidoItem>
                {
                    new PedidoItem
                    {
                        ProdutoId = produto.Id,
                        Quantidade = 1,
                        Valor = 10,
                        Desconto = 0
                    }
                },
            };
            db.Pedidos.Add(pedido);
            db.SaveChanges();
        }
    }
}