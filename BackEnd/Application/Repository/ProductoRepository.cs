using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly NikeDbContext _context;

    public ProductoRepository(NikeDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        var categorias = await _context.Productos
        .Include(p => p.Categoria)
        .ToListAsync();

        return categorias;
    }
}