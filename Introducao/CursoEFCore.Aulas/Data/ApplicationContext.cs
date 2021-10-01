using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEFCore.Aulas.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("connection-string-fake");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(builder =>
            {
                builder.ToTable("clientes");

                builder.HasKey(c => c.Id);
                builder.Property(c => c.Nome).HasColumnType("VARCHAR(80)").IsRequired();
                builder.Property(c => c.Telefone).HasColumnType("CHAR(11)");
                builder.Property(c => c.CEP).HasColumnType("CHAR(8)").IsRequired();
                builder.Property(c => c.Estado).HasColumnType("CHAR(2)").IsRequired();
                builder.Property(c => c.Cidade).HasMaxLength(60).IsRequired();

                builder.HasIndex(c => c.Telefone).HasDatabaseName("ix_cliente_telefone");
            });

            modelBuilder.Entity<Produto>(builder =>
            {
                builder.ToTable("produtos");

                builder.HasKey(p => p.Id);
                builder.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
                builder.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
                builder.Property(p => p.Valor).IsRequired();
                builder.Property(p => p.TipoProduto).HasConversion<string>();
            });

            modelBuilder.Entity<Pedido>(builder =>
            {
                builder.ToTable("pedidos");

                builder.HasKey(p => p.Id);
                builder.Property(p => p.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                builder.Property(p => p.Status).HasConversion<string>();
                builder.Property(p => p.TipoFrete).HasConversion<string>();
                builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

                builder
                    .HasMany(pedido => pedido.Itens)
                    .WithOne(pedidoItem => pedidoItem.Pedido)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PedidoItem>(builder =>
            {
                builder.ToTable("pedidos_itens");

                builder.HasKey(p => p.Id);
                builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired();
                builder.Property(p => p.Valor).IsRequired();
                builder.Property(p => p.Desconto).IsRequired();
            });
        }
    }
}