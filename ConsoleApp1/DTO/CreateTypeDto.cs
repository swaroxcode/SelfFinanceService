using ConsoleApp1.DAL.Entity;

namespace ConsoleApp1.DTO;

public class CreateTypeDto
{
    public string TypeName { get; set; }
    public ExpenceOrIncome ExpenceOrIncome { get; set; }
}