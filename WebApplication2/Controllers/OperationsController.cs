using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTO;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationsController:ControllerBase
{
    private readonly IOperationService _operationService;

    public OperationsController(IOperationService operationService)
    {
        _operationService = operationService;
    }

    [HttpGet("{OperationDTO ID}")]
    public async Task<IActionResult> Get([FromBody]Guid operationDTOID)
    {
        try
        {
            var getElem = await _operationService.Get(operationDTOID);
            return Ok(getElem);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Error");
        }
    }

    [HttpPost("{Type Id},{Date},{Amount Operation}")]
    public async Task<IActionResult>Create([FromBody]Guid id,DateTime date,decimal amount)
    {
        try
        {
            await _operationService.Create(id, date, amount);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Error");
        }
        
    }

    [HttpPut("{OperationDTO}")]
    public async Task<IActionResult> Update([FromBody]OperationDTO operationDto)
    {
        try
        {
            await _operationService.Update(operationDto.Id, operationDto.TypeId, operationDto.DateOfOperations,
                operationDto.Amount);
            return Ok();
        }
        catch
        {
            return StatusCode(500, "Internal Error");  
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute]Guid id)
    {
        try
        {
            await _operationService.Remove(id);
            return Ok();
        }
        catch
        {
            return StatusCode(500, "Internal Error");  
        }
    }
}