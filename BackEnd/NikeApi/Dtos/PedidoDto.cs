namespace NikeApi.Dtos;

public class PedidoDto
{
    public int Id { get; set; }
    public DateOnly FechaPedido { get; set; }
    public UserDto User { get; set; }
}