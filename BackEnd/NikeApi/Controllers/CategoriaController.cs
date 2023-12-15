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
// [Authorize (Roles= "Administrador")]    

public class CategoriaController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public CategoriaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<CategoriaDto>>> Get()
    {
        var categoria = await unitofwork.Categorias.GetAllAsync();
        return mapper.Map<List<CategoriaDto>>(categoria);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pager<CategoriaDto>>> Get([FromQuery]Params categoriaParams)
    {
        var categoria = await unitofwork.Categorias.GetAllAsync(categoriaParams.PageIndex,categoriaParams.PageSize, categoriaParams.Search);
        var listaCategorias = mapper.Map<List<CategoriaDto>>(categoria.registros);
        return new Pager<CategoriaDto>(listaCategorias, categoria.totalRegistros,categoriaParams.PageIndex,categoriaParams.PageSize,categoriaParams.Search);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CategoriaDto>> Get(int id)
    {
        var categoria = await unitofwork.Categorias.GetByIdAsync(id);
        return mapper.Map<CategoriaDto>(categoria);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CategoriaDto>> Post(CategoriaDto categoriaDto)
    {
        var categoria = this.mapper.Map<Categoria>(categoriaDto);
        this.unitofwork.Categorias.Add(categoria);
        await unitofwork.SaveAsync();
        if (categoria == null){
            return BadRequest();
        }
        categoriaDto.Id = categoria.Id;
        return CreatedAtAction(nameof(Post), new { id = categoriaDto.Id }, categoriaDto);
    }

    [HttpPut]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CategoriaDto>> Put (int id, [FromBody]CategoriaDto categoriaDto)
    {
        if(categoriaDto == null)
            return NotFound();

        var categoria = this.mapper.Map<Categoria>(categoriaDto);
        unitofwork.Categorias.Update(categoria);
        await unitofwork.SaveAsync();
        return categoriaDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var categoria = await unitofwork.Categorias.GetByIdAsync(id);

        if (categoria == null)
        {
            return Notfound();
        }

        unitofwork.Categorias.Remove(categoria);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}