using WebApplication2.DTO;

namespace WebApplication2.Services;

public interface IReportService
{
    
    public Task<ReportDTO> DailyReport();

    public Task<ReportDTO> CustomDaysReport(string startDate, string endDate);
    public ReportDTO LookingForReport(List<Operation> neededOperations);
    public decimal TotalCharge(List<decimal> chargeList);
}