namespace WebApplication2.DTO;

public class OperationDTO
{
    public Guid Id { get; set; }
    public Guid TypeId { get; set; }
    public DateTime DateOfOperations { get; set; }
    public decimal Amount { get; set; }
}