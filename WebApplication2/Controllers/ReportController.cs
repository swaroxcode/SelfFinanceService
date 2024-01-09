using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("{dayOfOperation}")]
    public async Task<IActionResult> DailyReport([FromQuery] DateTime dayOfOperation)
    {
        try
        {
            var dailyReport = await _reportService.DailyReport(dayOfOperation);
            return Ok(dailyReport);
        }

        catch (Exception ex)
        {
            return StatusCode(500, "Internal Error");
        }
    }

    [HttpGet("{startDate:datetime},{endDate:datetime}")]
    public async Task<IActionResult> CustomDateReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        try
        {
            var customReport = await _reportService.CustomDaysReport(startDate, endDate);
            return Ok(customReport);
        }

        catch (Exception ex)
        {
            return StatusCode(500, "Internal Error");
        }
    }
}