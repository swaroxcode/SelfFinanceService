using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.DAL.Entity;
public class Type
{
    public ExpenceOrIncome ExpenceOrIncome { get; set; }
    
    public string TypeName { get; set; }
    
    [Key] public Guid Id { get; set; }
}