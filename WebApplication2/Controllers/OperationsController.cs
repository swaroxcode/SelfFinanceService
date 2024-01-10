using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTO;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationsController : ControllerBase
{
    private readonly IOperationService _operationService;

    public OperationsController(IOperationService operationService)
    {
        _operationService = operationService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute]Guid id)
    {
        try
        {
            var element = await _operationService.Get(id);
            return Ok(element);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal Error");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OperationCreateDto operationCreateDto)
    {
        try
        {
            await _operationService.Create(operationCreateDto.id, operationCreateDto.date, operationCreateDto.amount);
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal Error");
        }
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] OperationUpdateDTO operationUpdateDto)
    {
        var operationDTO = new Operation
        {
            DateOfOperations = operationUpdateDto.DateOfOperations,
            TypeId = operationUpdateDto.TypeId,
            Id = operationUpdateDto.Id,
            Amount = operationUpdateDto.Amount
        };
        try
        {
            await _operationService.Update(operationDTO);
            return Ok();
        }
        catch
        {
            return StatusCode(500, "Internal Error");
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        try
        {
            await _operationService.Remove(id);
            return Ok(StatusCode(204));
        }
        catch
        {
            return StatusCode(500, "Internal Error");
        }
    }
}