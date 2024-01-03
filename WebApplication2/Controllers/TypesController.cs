using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTO;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TypesController : ControllerBase
{
    private ITypeService _typeService;
    private IMapper _imapper;

    public TypesController(ITypeService typeService,IMapper imapper)
    {
        _typeService = typeService;
        _imapper = imapper;
    }

    [HttpGet("all")]
    public async Task<List<TypeDTO>> GetAll()
    {
        var allTypes =await _typeService.GetAll();
        return _imapper.Map<List<TypeDTO>>(allTypes);
    }

    [HttpPost("{Type Name},{Expence or Income")]
    public async Task<IActionResult> CreateNew([FromRoute] string typeName,[FromBody]ExpenceOrIncome expenceOrIncome)
    {
        try
        {
            await _typeService.CreateNew(typeName, expenceOrIncome);
            return Ok();
        }
        catch(Exception e)
        {
            return StatusCode(500, "Internal Service Error");
        }
        
    }

    [HttpPut("{TypeDTO}")]
    public async Task<IActionResult> Update([FromBody]TypeDTO typeDto)
    {
        try
        {
            await _typeService.Update(typeDto.Id,typeDto.TypeName,typeDto.ExpenceOrIncome);
            return Ok();
        }
        catch(Exception e)
        {
            return StatusCode(500, "Internal Service Error");
        }
    }

    [HttpDelete("{ID}")]
    public async Task<IActionResult> Remove([FromBody] Guid id)
    {
        try
        {
            await _typeService.Remove(id);
            return Ok();
        }
        catch(Exception e)
        {
            return StatusCode(500, "Internal Service Error");
        }
    }
    
}