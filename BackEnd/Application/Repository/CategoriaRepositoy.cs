using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class CategoriaRepository : GenericRepository<Categoria>, ICategoria
{
    private readonly NikeDbContext _context;

    public CategoriaRepository(NikeDbContext context) : base(context)
    {
        _context = context;
    }

}