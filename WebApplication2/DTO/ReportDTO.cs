using Azure;

namespace WebApplication2.DTO;

public class ReportDTO
{
    public decimal? TotalIncome { get; set; }
    public decimal? TotalExpence { get; set; }
    public List<Operation>? ListOfCurrentOperations { get; set; }
    
    public DateOnly? OperationDate { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}