using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data;

public partial class NikeDbContext : DbContext
{
    public NikeDbContext()
    {
    }

    public NikeDbContext(DbContextOptions<NikeDbContext> options) : base(options)
    {
    }
    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public DbSet<User> Usuarios { get; set; }

    public DbSet<Rol> Roles { get; set; }
    
    public DbSet<UserRol> RolesUsuarios { get; set; }

    public DbSet<DetallePedido> DetallesPedidos { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}