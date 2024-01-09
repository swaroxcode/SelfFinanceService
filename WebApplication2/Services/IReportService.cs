using WebApplication2.DTO;

namespace WebApplication2.Services;

public interface IReportService
{
    
    public Task<ReportDTO> DailyReport(DateOnly dateOfOperation);

    public Task<ReportDTO> CustomDaysReport(DateOnly startDate, DateOnly endDate);
    public ReportDTO LookingForReport(List<Operation> neededOperations,string startDay=null,string endDay=null);
    public decimal TotalCharge(List<decimal> chargeList);
}