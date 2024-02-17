using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.DAL.Entity;

public class Operation
{
    [Key] public Guid Id { get; set; }
    public Guid TypeId { get; set; }
    public DateTime DateOfOperations { get; set; }
    public decimal Amount { get; set; }
}