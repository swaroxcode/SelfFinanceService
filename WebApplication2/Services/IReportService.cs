using WebApplication2.DTO;

namespace WebApplication2.Services;

public interface IReportService
{
    public Task<ReportDTO> DailyReport(DateOnly dateOfOperation);

    public Task<ReportDTO> CustomDaysReport(DateOnly startDate, DateOnly endDate);
    public ReportDTO LookingForReport(List<Operation> neededOperations);
    public decimal TotalCharge(List<decimal> chargeList);
}