namespace WebApplication2.DTO;

public class OperationUpdateDTO
{
    public Guid Id { get; set; }
    public Guid TypeId { get; set; }
    public DateOnly DateOfOperations { get; set; }
    public decimal Amount { get; set; }
}