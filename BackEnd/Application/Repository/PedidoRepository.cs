using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class PedidoRepository : GenericRepository<Pedido>, IPedido
{
    private readonly NikeDbContext _context;

    public PedidoRepository(NikeDbContext context) : base(context)
    {
        _context = context;
    }

}