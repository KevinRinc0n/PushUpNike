namespace Domain.Interfaces;

public interface IUnitOfWork
{
    ICategoria Categorias {get;}
    IProducto Productos {get;}
    IUserRol RolesUsuarios { get; }
    IUser Usuarios { get; }
    IRol Roles { get; }
    IPedido Pedidos { get; }
    IDetallePedido DetallesPedidos { get; }


    Task<int> SaveAsync();
}