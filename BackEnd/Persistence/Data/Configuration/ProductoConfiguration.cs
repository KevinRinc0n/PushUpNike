using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;

public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
        builder.ToTable("producto");

        builder.Property(c => c.IdProducto)
        .IsRequired()
        .HasMaxLength(50);     

        builder.HasIndex(c => c.IdProducto).IsUnique();   
 
        builder.Property(c => c.Titulo)
        .IsRequired()
        .HasMaxLength(50); 

        builder.Property(c => c.Imagen)
        .IsRequired()
        .HasMaxLength(50);  

        builder.Property(c => c.IdCategoriaFk)
        .HasColumnType("int");  

        builder.Property(c => c.Precio)
        .IsRequired()
        .HasColumnType("double");

        builder.HasOne(c => c.Categoria)
        .WithMany(c => c.Productos)
        .HasForeignKey(c => c.IdCategoriaFk);

        builder.HasData(
            new Producto { Id = 1, IdProducto = "abrigo-01", Titulo = "Abrigo 01", Imagen = "./img/abrigos/01.jpg", IdCategoriaFk = 1, Precio = 1000 },
            new Producto { Id = 2, IdProducto = "abrigo-02", Titulo = "Abrigo 02", Imagen = "./img/abrigos/02.jpg", IdCategoriaFk = 1, Precio = 1000 },
            new Producto { Id = 3, IdProducto = "abrigo-03", Titulo = "Abrigo 03", Imagen = "./img/abrigos/03.jpg", IdCategoriaFk = 1, Precio = 1000 },
            new Producto { Id = 4, IdProducto = "abrigo-04", Titulo = "Abrigo 04", Imagen = "./img/abrigos/04.jpg", IdCategoriaFk = 1, Precio = 1000 },
            new Producto { Id = 5, IdProducto = "abrigo-05", Titulo = "Abrigo 05", Imagen = "./img/abrigos/05.jpg", IdCategoriaFk = 1, Precio = 1000 },
            new Producto { Id = 6, IdProducto = "camiseta-01", Titulo = "Camiseta 01", Imagen = "./img/camisetas/01.jpg", IdCategoriaFk = 2, Precio = 1000 },
            new Producto { Id = 7, IdProducto = "camiseta-02", Titulo = "Camiseta 02", Imagen = "./img/camisetas/02.jpg", IdCategoriaFk = 2, Precio = 1000 },
            new Producto { Id = 8, IdProducto = "camiseta-03", Titulo = "Camiseta 03", Imagen = "./img/camisetas/03.jpg", IdCategoriaFk = 2, Precio = 1000 },
            new Producto { Id = 9, IdProducto = "camiseta-04", Titulo = "Camiseta 04", Imagen = "./img/camisetas/04.jpg", IdCategoriaFk = 2, Precio = 1000 },
            new Producto { Id = 10, IdProducto = "camiseta-05", Titulo = "Camiseta 05", Imagen = "./img/camisetas/05.jpg", IdCategoriaFk = 2, Precio = 1000 },
            new Producto { Id = 11, IdProducto = "camiseta-06", Titulo = "Camiseta 06", Imagen = "./img/camisetas/06.jpg", IdCategoriaFk = 2, Precio = 1000 },
            new Producto { Id = 12, IdProducto = "camiseta-07", Titulo = "Camiseta 07", Imagen = "./img/camisetas/07.jpg", IdCategoriaFk = 2, Precio = 1000 },
            new Producto { Id = 13, IdProducto = "camiseta-08", Titulo = "Camiseta 08", Imagen = "./img/camisetas/08.jpg", IdCategoriaFk = 2, Precio = 1000 },
            new Producto { Id = 14, IdProducto = "pantalon-01", Titulo = "Pantalón 01", Imagen = "./img/pantalones/01.jpg", IdCategoriaFk = 3, Precio = 1000 },
            new Producto { Id = 15, IdProducto = "pantalon-02", Titulo = "Pantalón 02", Imagen = "./img/pantalones/02.jpg", IdCategoriaFk = 3, Precio = 1000 },
            new Producto { Id = 16, IdProducto = "pantalon-03", Titulo = "Pantalón 03", Imagen = "./img/pantalones/03.jpg", IdCategoriaFk = 3, Precio = 1000 },
            new Producto { Id = 17, IdProducto = "pantalon-04", Titulo = "Pantalón 04", Imagen = "./img/pantalones/04.jpg", IdCategoriaFk = 3, Precio = 1000 },
            new Producto { Id = 18, IdProducto = "pantalon-05", Titulo = "Pantalón 05", Imagen = "./img/pantalones/05.jpg", IdCategoriaFk = 3, Precio = 1000 }
        );
    }
}