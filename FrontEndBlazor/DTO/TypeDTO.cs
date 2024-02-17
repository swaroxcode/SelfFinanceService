using BlazorApp2.DAL.Entity;

namespace BlazorApp2.DTO;

public class TypeDTO
{
    public ExpenceOrIncome ExpenceOrIncome { get; set; }
    public Guid Id { get; set; }
    public string? TypeName { get; set; }
    
}