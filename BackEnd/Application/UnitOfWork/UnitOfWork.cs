using Application.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NikeDbContext _context;

        private ICategoria _categorias;
        private IDetallePedido _detallePedidos;
        private IPedido _pedidos;
        private IProducto _productos;
        private IUser _usuarios;
        private IRol _roles;
        private IUserRol _rolesUsuarios;
        

        public UnitOfWork(NikeDbContext context)
        {
            _context = context;
        }
        
        public ICategoria Categorias
        {
            get{
                if(_categorias == null)
                {
                    _categorias = new CategoriaRepository(_context);
                }
                return _categorias;
            }
        }

        public IDetallePedido DetallesPedidos
        {
            get{
                if(_detallePedidos == null)
                {
                    _detallePedidos = new DetallePedidoRepository(_context);
                }
                return _detallePedidos;
            }
        }

        public IPedido Pedidos
        {
            get{
                if(_pedidos == null)
                {
                    _pedidos = new PedidoRepository(_context);
                }
                return _pedidos;
            }
        }

        public IProducto Productos
        {
            get{
                if(_productos == null)
                {
                    _productos = new ProductoRepository(_context);
                }
                return _productos;
            }
        }

        public IUser Usuarios
        {
            get{
                if(_usuarios == null)
                {
                    _usuarios = new UserRepository(_context);
                }
                return _usuarios;
            }
        }

        public IRol Roles
        {
            get{
                if(_roles == null)
                {
                    _roles = new RolRepository(_context);
                }
                return _roles;
            }
        }

        public IUserRol RolesUsuarios
        {
            get{
                if(_rolesUsuarios == null)
                {
                    _rolesUsuarios = new UserRolRepository(_context);
                }
                return _rolesUsuarios;
            }
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}