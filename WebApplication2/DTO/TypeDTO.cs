namespace WebApplication2.DTO;

public class TypeDTO
{
    public Guid Id { get; set; }
    public string? TypeName { get; set; }
    public ExpenceOrIncome ExpenceOrIncome { get; set; }
}