using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("pedido");

        builder.Property(c => c.IdUsuarioFk)
        .IsRequired()
        .HasColumnType("int");         

        builder.Property(c => c.FechaPedido)
        .IsRequired();

        builder.HasOne(c => c.User)
        .WithMany(c => c.Pedidos)
        .HasForeignKey(c => c.IdUsuarioFk);
    }
}