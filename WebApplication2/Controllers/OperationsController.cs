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

    [HttpPost("{id},{typeId},{dateTime},{amount},{typeName},{ExpenceOrIncome}")]
    public string CreateOperation(string id, Guid typeId, string dateTime, float amount, string typeName,
        ExpenceOrIncome expenceOrIncome)
    {
        return _financinalOperations.CreateOperation(id, typeId, dateTime, amount, typeName, expenceOrIncome);
    }

    [HttpPut("{id},{typesId},{dateTime},{amount}")]
    public string UpdateOperation(Guid id, Guid typesId, string dateTime,
        float amount)
    {
       return _financinalOperations.UpdateOperation(id, typesId, dateTime, amount);
    }

    [HttpDelete("{id}")]
    public string DeleteOperation(Guid id)
    {
        return _financinalOperations.RemoveOperation(id);
    }
}