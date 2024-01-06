using Microsoft.EntityFrameworkCore;
using WebApplication2.DTO;

namespace WebApplication2.Services;

public class ReportService:IReportService
{
    private readonly ApiContext _apiContext;
    private ITypeService _typeService;
    
    public ReportService(ApiContext apiContext,ITypeService typeService)
    {
        _apiContext = apiContext;
        _typeService = typeService;
    }
    public async Task<ReportDTO> DailyReport()
    {
        ReportDTO currentReportDto = new ReportDTO();
        currentReportDto.OperationDate = DateOnly.Parse(DateTime.Today.ToString());
        List<Operation> dailyOperations = await (from operation in _apiContext.Operations where operation.DateOfOperations.Equals(currentReportDto.OperationDate)select operation).ToListAsync();
        return LookingForReport(dailyOperations);
    }

    public async Task<ReportDTO> CustomDaysReport(string startDate, string endDate)
    {
        var _startDay =DateOnly.Parse(startDate);
        var _endDay = DateOnly.Parse(endDate);
        List<Operation> customDateOperations = await _apiContext.Operations.Where(o =>
            o.DateOfOperations.CompareTo(_startDay) > 0 &
            o.DateOfOperations.CompareTo( _endDay) < 0).ToListAsync();
        return LookingForReport(customDateOperations,startDate,endDate);

    }
    

    public decimal TotalCharge(List<decimal> chargeList)
    {
        decimal totalcharge = 0;
        foreach (var charge in chargeList)
        {
            totalcharge = totalcharge + charge;
        }

        return totalcharge;
    }

    public ReportDTO LookingForReport(List<Operation> neededOperation, string startDay = null, string endDay = null)
    {
        var currentReport = new ReportDTO();
        if (startDay != null && endDay != null)
        {
            currentReport.StartDate = DateOnly.Parse(startDay);
            currentReport.EndDate = DateOnly.Parse(endDay);
        }
    List<decimal> allIncome = neededOperation.Where(o=> _typeService.Get(o.TypeId).Result.ExpenceOrIncome == ExpenceOrIncome.Income)
            .Select(o => o.Amount).ToList();
        List<decimal> allExpence = neededOperation.Where(o=>_typeService.Get(o.TypeId).Result.ExpenceOrIncome == ExpenceOrIncome.Expence)
            .Select(o => o.Amount).ToList();
        currentReport.TotalExpence = TotalCharge(allExpence);
        currentReport.TotalIncome = TotalCharge(allIncome);
        currentReport.ListOfCurrentOperations = neededOperation;
        return currentReport;
    }
}