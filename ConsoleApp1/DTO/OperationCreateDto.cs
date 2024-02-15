namespace ConsoleApp1.DTO;

public class OperationCreateDto
{
    public Guid Id { get; set; }
    public DateTime DateOfOperation { get; set; }
    public decimal Amount { get; set; }
}