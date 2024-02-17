using BlazorApp2.DAL.Entity;

namespace BlazorApp2.DTO;

public class CreateTypeDto
{
    public string TypeName { get; set; }
    public ExpenceOrIncome ExpenceOrIncome { get; set; }
}