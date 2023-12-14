using Domain.Entities;
using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NikeApi.Helpers;
using NikeApi.Dtos;

namespace NikeApi.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]
[Authorize (Roles= "Administrador")]    

public class ProductoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public ProductoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<ProductoDto>>> Get()
    {
        var producto = await unitofwork.Productos.GetAllAsync();
        return mapper.Map<List<ProductoDto>>(producto);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<ProductoDto>>> Get([FromQuery]Params ProductoParams)
    {
        var producto = await unitofwork.Productos.GetAllAsync(ProductoParams.PageIndex,ProductoParams.PageSize, ProductoParams.Search);
        var listaProducto = mapper.Map<List<ProductoDto>>(producto.registros);
        return new Pager<ProductoDto>(listaProducto, producto.totalRegistros,ProductoParams.PageIndex,ProductoParams.PageSize,ProductoParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductoDto>> Get(int id)
    {
        var producto = await unitofwork.Productos.GetByIdAsync(id);
        return mapper.Map<ProductoDto>(producto);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ProductoDto>> Post(ProductoDto ProductoDto)
    {
        var producto = this.mapper.Map<Producto>(ProductoDto);
        this.unitofwork.Productos.Add(producto);
        await unitofwork.SaveAsync();
        if (producto == null){
            return BadRequest();
        }
        ProductoDto.Id = producto.Id;
        return CreatedAtAction(nameof(Post), new { id = ProductoDto.Id }, ProductoDto);
    }

    [HttpPut]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ProductoDto>> Put (int id, [FromBody]ProductoDto ProductoDto)
    {
        if(ProductoDto == null)
            return NotFound();

        var producto = this.mapper.Map<Producto>(ProductoDto);
        unitofwork.Productos.Update(producto);
        await unitofwork.SaveAsync();
        return ProductoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var producto = await unitofwork.Productos.GetByIdAsync(id);

        if (producto == null)
        {
            return Notfound();
        }

        unitofwork.Productos.Remove(producto);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}