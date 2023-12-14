namespace Domain.Entities;

public class Pedido : BaseEntity
{
    public DateOnly FechaPedido { get; set; }
    public int IdUsuarioFk { get; set; }
    public User User { get; set; }
    public ICollection<DetallePedido> DetallePedidos { get; set; }
}