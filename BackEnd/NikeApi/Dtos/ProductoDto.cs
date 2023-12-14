namespace NikeApi.Dtos;

public class ProductoDto
{
    public int Id { get; set; }
    public string IdProducto { get; set; }
    public string Titulo { get; set; }
    public string Imagen { get; set; }
    public CategoriaDto Categoria { get; set; }
    public double Precio { get; set; }
}