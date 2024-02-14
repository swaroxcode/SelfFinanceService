using ConsoleApp1.DAL.Entity;

namespace ConsoleApp1.DTO;

public class ReportDTO
{
    public decimal? TotalIncome { get; set; }
    public decimal? TotalExpence { get; set; }
    public List<Operation>? ListOfCurrentOperations { get; set; }
}