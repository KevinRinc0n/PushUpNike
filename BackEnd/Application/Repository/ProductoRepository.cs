using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly NikeDbContext _context;

    public ProductoRepository(NikeDbContext context) : base(context)
    {
        _context = context;
    }

}