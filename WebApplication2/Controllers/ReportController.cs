using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTO;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReportController:ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet]
    public async Task<ReportDTO> DailyReport()
    {
        return await _reportService.DailyReport();
    }

    [HttpGet("{startDate},{endDate}")]
    public async Task<ReportDTO> CustomDateReport(string startDate,string endDate)
    {
        return await _reportService.CustomDaysReport(startDate, endDate);
    }
}