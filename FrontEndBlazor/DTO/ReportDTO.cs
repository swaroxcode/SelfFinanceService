using BlazorApp2.DAL.Entity;

namespace BlazorApp2.DTO;

public class ReportDTO
{
    public decimal? TotalIncome { get; set; }
    public decimal? TotalExpence { get; set; }
    public List<WebApplication2.DTO.OperationToShowDTO> ListOfCurrentOperations { get; set; }
}