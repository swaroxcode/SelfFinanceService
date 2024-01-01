using System.ComponentModel.DataAnnotations;

namespace WebApplication2;

public class Operation
{
    [Key]
    public Guid id { get; set; }
    public Guid typeId { get; set; }
    public DateTime dateOfOperations { get; set; }
    public double amount { get; set; }
    
}