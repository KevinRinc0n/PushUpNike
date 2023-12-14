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

public class DetallePedidoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public DetallePedidoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<DetallePedidoDto>>> Get()
    {
        var detallePedido = await unitofwork.DetallesPedidos.GetAllAsync();
        return mapper.Map<List<DetallePedidoDto>>(detallePedido);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<DetallePedidoDto>>> Get([FromQuery]Params DetallePedidoParams)
    {
        var detallePedido = await unitofwork.DetallesPedidos.GetAllAsync(DetallePedidoParams.PageIndex,DetallePedidoParams.PageSize, DetallePedidoParams.Search);
        var listaDetallePedido = mapper.Map<List<DetallePedidoDto>>(detallePedido.registros);
        return new Pager<DetallePedidoDto>(listaDetallePedido, detallePedido.totalRegistros,DetallePedidoParams.PageIndex,DetallePedidoParams.PageSize,DetallePedidoParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DetallePedidoDto>> Get(int id)
    {
        var detallePedido = await unitofwork.DetallesPedidos.GetByIdAsync(id);
        return mapper.Map<DetallePedidoDto>(detallePedido);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetallePedidoDto>> Post(DetallePedidoDto DetallePedidoDto)
    {
        var detallePedido = this.mapper.Map<DetallePedido>(DetallePedidoDto);
        this.unitofwork.DetallesPedidos.Add(detallePedido);
        await unitofwork.SaveAsync();
        if (detallePedido == null){
            return BadRequest();
        }
        DetallePedidoDto.Id = detallePedido.Id;
        return CreatedAtAction(nameof(Post), new { id = DetallePedidoDto.Id }, DetallePedidoDto);
    }

    [HttpPut]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DetallePedidoDto>> Put (int id, [FromBody]DetallePedidoDto DetallePedidoDto)
    {
        if(DetallePedidoDto == null)
            return NotFound();

        var detallePedido = this.mapper.Map<DetallePedido>(DetallePedidoDto);
        unitofwork.DetallesPedidos.Update(detallePedido);
        await unitofwork.SaveAsync();
        return DetallePedidoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var detallePedido = await unitofwork.DetallesPedidos.GetByIdAsync(id);

        if (detallePedido == null)
        {
            return Notfound();
        }

        unitofwork.DetallesPedidos.Remove(detallePedido);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}