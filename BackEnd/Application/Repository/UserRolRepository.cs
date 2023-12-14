using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class UserRolRepository : GenericRepository<UserRol>, IUserRol
{
    private readonly NikeDbContext _context;

    public UserRolRepository(NikeDbContext context) : base(context)
    {
        _context = context;
    }

}