namespace NikeApi.Dtos;

public class DetallePedidoDto
{
    public int Id { get; set; }
    public int Cantidad { get; set; }
    public double SubTotal { get; set; } 
    public ProductoDto Producto { get; set; }
    public PedidoDto Pedido { get; set; }
}