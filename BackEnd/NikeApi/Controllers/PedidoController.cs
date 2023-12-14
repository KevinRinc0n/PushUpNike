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

public class PedidoController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public PedidoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<PedidoDto>>> Get()
    {
        var pedido = await unitofwork.Pedidos.GetAllAsync();
        return mapper.Map<List<PedidoDto>>(pedido);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<PedidoDto>>> Get([FromQuery]Params PedidoParams)
    {
        var pedido = await unitofwork.Pedidos.GetAllAsync(PedidoParams.PageIndex,PedidoParams.PageSize, PedidoParams.Search);
        var listaPedido = mapper.Map<List<PedidoDto>>(pedido.registros);
        return new Pager<PedidoDto>(listaPedido, pedido.totalRegistros,PedidoParams.PageIndex,PedidoParams.PageSize,PedidoParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PedidoDto>> Get(int id)
    {
        var pedido = await unitofwork.Pedidos.GetByIdAsync(id);
        return mapper.Map<PedidoDto>(pedido);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PedidoDto>> Post(PedidoDto PedidoDto)
    {
        var pedido = this.mapper.Map<Pedido>(PedidoDto);
        this.unitofwork.Pedidos.Add(pedido);
        await unitofwork.SaveAsync();
        if (pedido == null){
            return BadRequest();
        }
        PedidoDto.Id = pedido.Id;
        return CreatedAtAction(nameof(Post), new { id = PedidoDto.Id }, PedidoDto);
    }

    [HttpPut]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PedidoDto>> Put (int id, [FromBody]PedidoDto PedidoDto)
    {
        if(PedidoDto == null)
            return NotFound();

        var pedido = this.mapper.Map<Pedido>(PedidoDto);
        unitofwork.Pedidos.Update(pedido);
        await unitofwork.SaveAsync();
        return PedidoDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var pedido = await unitofwork.Pedidos.GetByIdAsync(id);

        if (pedido == null)
        {
            return Notfound();
        }

        unitofwork.Pedidos.Remove(pedido);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}