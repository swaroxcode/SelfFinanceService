using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTO;
using WebApplication2.Services;

namespace WebApplication2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReportController:ControllerBase
{
    private readonly iFinancinalOperations _financinalOperations;

    public ReportController(iFinancinalOperations iFinancinalOperations)
    {
        _financinalOperations = iFinancinalOperations;
    }

    [HttpGet]
    public Report DailyReport()
    {
        return _financinalOperations.DailyReport();
    }

    [HttpGet("{startDate},{endDate}")]
    public Report CustomDateReport(string startDate,string endDate)
    {
        return _financinalOperations.CustomDaysReport(startDate, endDate);
    }
}