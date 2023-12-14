using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class DetallePedidoRepository : GenericRepository<DetallePedido>, IDetallePedido
{
    private readonly NikeDbContext _context;

    public DetallePedidoRepository(NikeDbContext context) : base(context)
    {
        _context = context;
    }

}