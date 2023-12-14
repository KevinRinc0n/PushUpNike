namespace Domain.Entities;

public class DetallePedido : BaseEntity
{
    public int IdProductoFk { get; set; }
    public Producto Producto { get; set; }
    public int IdPedidoFk { get; set; }
    public Pedido Pedido { get; set; }
    public int Cantidad { get; set; }
    public double SubTotal { get; set; } 
}