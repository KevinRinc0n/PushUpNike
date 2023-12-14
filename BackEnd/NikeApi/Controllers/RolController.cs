using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces;
using Domain.Entities;

namespace NikeApi.Controllers;

public class RolController : BaseApiController
{
    private IUnitOfWork unitofwork;
    private readonly IMapper mapper;

    public RolController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitofwork = unitOfWork;
        this.mapper = mapper;
    } 

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<IEnumerable<Rol>>> Get()
    {
        var rol = await unitofwork.Roles.GetAllAsync();
        return mapper.Map<List<Rol>>(rol);
    }

    [HttpGet("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Rol>> Get(int id)
    {
        var rol = await unitofwork.Roles.GetByIdAsync(id);
        return mapper.Map<Rol>(rol);
    }

    [HttpPost]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rol>> Post(Rol rolDto)
    {
        var rol = this.mapper.Map<Rol>(rolDto);
        this.unitofwork.Roles.Add(rol);
        await unitofwork.SaveAsync();
        if (rol == null){
            return BadRequest();
        }
        rolDto.Id = rol.Id;
        return CreatedAtAction(nameof(Post), new { id = rolDto.Id }, rolDto);
    }

    [HttpPut("{id}")]    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Rol>> Put (int id, [FromBody]Rol rolDto)
    {
        if(rolDto == null)
            return NotFound();

        var rol = this.mapper.Map<Rol>(rolDto);
        unitofwork.Roles.Update(rol);
        await unitofwork.SaveAsync();
        return rolDto;     
    }

    [HttpDelete("{id}")]    
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]

    public async Task<ActionResult> Delete (int id)
    {
        var rol = await unitofwork.Roles.GetByIdAsync(id);

        if (rol == null)
        {
            return Notfound();
        }

        unitofwork.Roles.Remove(rol);
        await unitofwork.SaveAsync();
        return NoContent();
    }

    private ActionResult Notfound()
    {
        throw new NotImplementedException();
    }
}