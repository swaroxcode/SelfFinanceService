using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ListOfTypesController : ControllerBase
{
    private iListOftypes _iListOftypes;

    public ListOfTypesController(iListOftypes iListOftypes)
    {
        _iListOftypes = iListOftypes;
    }

    [HttpGet]
    public List<Type> GetAllTypes()
    {
        return _iListOftypes.GetAllTypes();
    }

    [HttpPost("{typeName},{expenceOrIncome}")]
    public string CreateNewType(string typeName,string expenceOrIncome)
    {
        var answer = _iListOftypes.CreateNewType(typeName, Enum.Parse<ExpenceOrIncome>(expenceOrIncome)).ToString();
        answer = JsonSerializer.Serialize(answer);
        return answer;
    }

    [HttpPut("{id},{typeName},{newTypeName},{_expenceOrIncome},{newExpenceOrIncome}")]
    public string UpdateType(Guid id,string typeName, string newTypeName, ExpenceOrIncome _expenceOrIncome,
         ExpenceOrIncome newExpenceOrIncome)
    {
        return _iListOftypes.UpdateType(id,typeName, newTypeName, _expenceOrIncome,
            newExpenceOrIncome);
    }

    [HttpDelete("{id}")]
    public string RemoveType(Guid id)
    {
        return _iListOftypes.RemoveType(id);
    }
    
}