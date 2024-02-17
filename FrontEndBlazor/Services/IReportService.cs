using BlazorApp2.DTO;

namespace BlazorApp2.Services;

public interface IReportService
{
    public Task<ReportDTO> DailyReport(DateTime? neededDate);
    public Task<ReportDTO> DatePeriodReport(DateTime? startDate, DateTime? endDate);
}