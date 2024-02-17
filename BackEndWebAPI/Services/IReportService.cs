using WebApplication2.DTO;

namespace WebApplication2.Services;

public interface IReportService
{
    public Task<ReportDTO> DailyReport(DateTime dateOfOperation);

    public Task<ReportDTO> CustomDaysReport(DateTime startDate, DateTime endDate);
    public Task<ReportDTO> LookingForReport(List<Operation> neededOperations);
    public decimal TotalCharge(List<decimal> chargeList);
}