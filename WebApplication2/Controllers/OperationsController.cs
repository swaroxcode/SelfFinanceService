using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperationsController:ControllerBase
{
    private readonly iFinancinalOperations _financinalOperations;

    public OperationsController(iFinancinalOperations financinalOperations)
    {
        _financinalOperations = financinalOperations;
    }

    [HttpGet("{id}")]
    public string GetAllOperation(Guid id)
    {
        return _financinalOperations.GetOperation(id);
    }

    [HttpPost("{id},{typeId},{dateTime},{amount}")]
    public string CreateOperation(string id, Guid typeId, string dateTime, double amount)
    {
        return _financinalOperations.CreateOperation(id, typeId, dateTime, amount);
    }

    [HttpPut("{id},{typesId},{dateTime},{amount}")]
    public string UpdateOperation(Guid id, Guid typesId, string dateTime,
        double amount)
    {
       return _financinalOperations.UpdateOperation(id, typesId, dateTime, amount);
    }

    [HttpDelete("{id}")]
    public string DeleteOperation(Guid id)
    {
        return _financinalOperations.RemoveOperation(id);
    }
}