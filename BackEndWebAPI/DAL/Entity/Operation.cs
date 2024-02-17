using System.ComponentModel.DataAnnotations;

namespace WebApplication2;

public class Operation
{
    [Key] public Guid Id { get; set; }
    public Guid TypeId { get; set; }
    public DateTime DateOfOperations { get; set; }
    public decimal Amount { get; set; }
}