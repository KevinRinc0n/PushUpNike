using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class DetallePedidoConfiguration : IEntityTypeConfiguration<DetallePedido>
{
    public void Configure(EntityTypeBuilder<DetallePedido> builder)
    {
        builder.ToTable("detallePedido");

        builder.Property(c => c.IdProductoFk)
        .IsRequired()
        .HasColumnType("int");         

        builder.Property(c => c.IdPedidoFk)
        .IsRequired()
        .HasColumnType("int");     

        builder.Property(c => c.Cantidad)
        .IsRequired()
        .HasColumnType("int");     

        builder.Property(c => c.SubTotal)
        .IsRequired()
        .HasColumnType("double");     

        builder.HasOne(c => c.Pedido)
        .WithMany(c => c.DetallePedidos)
        .HasForeignKey(c => c.IdPedidoFk);
    }
}