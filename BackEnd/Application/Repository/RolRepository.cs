using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly NikeDbContext _context;

    public RolRepository(NikeDbContext context) : base(context)
    {
        _context = context;
    }

}