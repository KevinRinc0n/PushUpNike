using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("categoria");

        builder.Property(c => c.Nombre)
        .IsRequired()
        .HasMaxLength(50);          

        builder.HasData(
            new Categoria { Id = 1, Nombre = "Abrigos" },
            new Categoria { Id = 2, Nombre = "Camisetas" },
            new Categoria { Id = 3, Nombre = "Pantalones" }
        );
    }
}