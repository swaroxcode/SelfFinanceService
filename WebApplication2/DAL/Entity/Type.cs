using System.ComponentModel.DataAnnotations;

namespace WebApplication2;

public class Type
{
    [Key] public Guid Id { get; set; }
    public string TypeName { get; set; }
    public ExpenceOrIncome ExpenceOrIncome { get; set; }
}