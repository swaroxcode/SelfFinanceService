using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.DAL.Entity;

public class Type
{
    public ExpenceOrIncome ExpenceOrIncome { get; set; }
    
    public string TypeName { get; set; }
    
    [Key] public Guid Id { get; set; }
}