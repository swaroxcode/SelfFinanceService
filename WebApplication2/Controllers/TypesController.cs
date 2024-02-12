using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTO;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TypesController : ControllerBase
{
    private readonly IMapper _imapper;
    private readonly ITypeService _typeService;

    public TypesController(ITypeService typeService, IMapper imapper)
    {
        _typeService = typeService;
        _imapper = imapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var allTypes = await _typeService.GetAll();
            return Ok(allTypes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateNew([FromBody] CreateTypeDto createTypeDto)
    {
        try
        {
            await _typeService.CreateNew(createTypeDto.TypeName, createTypeDto.ExpenceOrIncome);
            return Ok();
        }
        catch
        {
            return StatusCode(500, "Internal Service Error");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TypeDTO typeDto)
    {
        try
        {
            await _typeService.Update(typeDto.Id, typeDto.TypeName, typeDto.ExpenceOrIncome);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Service Error");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remove([FromRoute] Guid id)
    {
        try
        {
            await _typeService.Remove(id);
            return Ok(StatusCode(204));
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Service Error");
        }
    }
}