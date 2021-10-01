using CursoEFCore.Aulas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoEFCore.Aulas.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
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
        }
    }
}