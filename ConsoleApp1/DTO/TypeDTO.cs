using ConsoleApp1.DAL.Entity;

namespace ConsoleApp1.DTO;

public class TypeDTO
{
    public ExpenceOrIncome ExpenceOrIncome { get; set; }
    public Guid Id { get; set; }
    public string? TypeName { get; set; }
    
}