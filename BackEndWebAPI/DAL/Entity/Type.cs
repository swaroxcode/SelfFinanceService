using System.ComponentModel.DataAnnotations;

namespace WebApplication2;

public class Type
{
    public ExpenceOrIncome ExpenceOrIncome { get; set; }
    
    public string TypeName { get; set; }
    
    [Key] public Guid Id { get; set; }
}