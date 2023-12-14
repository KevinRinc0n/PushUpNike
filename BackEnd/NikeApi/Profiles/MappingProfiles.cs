using NikeApi.Dtos;
using AutoMapper;
using Domain.Entities;

namespace NikeApi.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Categoria, CategoriaDto>().ReverseMap();

        CreateMap<DetallePedido, DetallePedidoDto>().ReverseMap();

        CreateMap<Pedido, PedidoDto>().ReverseMap();

        CreateMap<Producto, ProductoDto>().ReverseMap();
        
        CreateMap<User, UserDto>().ReverseMap();
    }
}