using System.ComponentModel.DataAnnotations;

namespace WebApplication2;

public class Operation
{
    [Key] public Guid Id { get; set; }
    public Guid TypeId { get; set; }
    public DateOnly DateOfOperations { get; set; }
    public decimal Amount { get; set; }
}