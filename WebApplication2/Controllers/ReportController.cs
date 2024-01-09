using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTO;
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
    public async Task<IActionResult> DailyReport([FromQuery] DateOnly dayOfOperation)
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

    [HttpGet("{startDate},{endDate}")]
    public async Task<IActionResult> CustomDateReport([FromQuery] DateOnly startDate, [FromQuery] DateOnly endDate)
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