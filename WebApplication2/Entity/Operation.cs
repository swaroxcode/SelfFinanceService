using System.ComponentModel.DataAnnotations;

namespace WebApplication2;

public class Operation
{
    public Guid id { get; set; }
    public Guid typeId { get; set; }
    public Type type { get; set; }
    public DateTime dateOfOperations { get; set; }
    public float amount { get; set; }
    
}