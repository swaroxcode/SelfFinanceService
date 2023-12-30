using System.ComponentModel.DataAnnotations;

namespace WebApplication2;

public class Type
{
    [Key]
    public Guid id { get; set; }
    public string typeName { get; set; }
    public ExpenceOrIncome expenceOrIncome { get; set; }
}