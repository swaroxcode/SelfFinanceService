
using Microsoft.Data.SqlClient;

namespace WebApplication2.DTO;

public class OperationCreateDto
{
    public Guid id { get; set; }
    public DateOnly date { get; set; }
    public decimal amount { get; set; }
    
}