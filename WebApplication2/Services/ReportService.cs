using Microsoft.EntityFrameworkCore;
using WebApplication2.DTO;

namespace WebApplication2.Services;

public class ReportService:IReportService
{
    private readonly ApiContext _apiContext;
    private ITypeService _typeService;
    
    public ReportService(ApiContext apiContext,TypeService typeService)
    {
        _apiContext = apiContext;
        _typeService = typeService;
    }
    public async Task<ReportDTO> DailyReport()
    {
        ReportDTO currentReportDto = new ReportDTO();
        var today = DateTime.Today;
        List<Operation> dailyOperations = await (from operation in _apiContext.Operations where operation.DateOfOperations.Equals(DateTime.Today)select operation).ToListAsync();
        return LookingForReport(dailyOperations);
    }

    public async Task<ReportDTO> CustomDaysReport(string startDate, string endDate)
    {
        
        var _startDay =DateTime.Parse(startDate);
        var _endDay = DateTime.Parse(endDate);
        List<Operation> customDateOperations = await _apiContext.Operations.Where(o =>
            DateTime.Compare(o.DateOfOperations, _startDay) > 0 &
            DateTime.Compare(o.DateOfOperations, _endDay) < 0).ToListAsync();
        return LookingForReport(customDateOperations);

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
    
    public ReportDTO LookingForReport(List<Operation> neededOperations)
    {
        var currentReport = new ReportDTO();
        List<decimal> allIncome = neededOperations.Where(o=> _typeService.Get(o.TypeId).Result.ExpenceOrIncome == ExpenceOrIncome.Income)
            .Select(o => o.Amount).ToList();
        List<decimal> allExpence = neededOperations.Where(o=>_typeService.Get(o.TypeId).Result.ExpenceOrIncome == ExpenceOrIncome.Expence)
            .Select(o => o.Amount).ToList();
        currentReport.TotalExpence = TotalCharge(allExpence);
        currentReport.TotalIncome = TotalCharge(allIncome);
        currentReport.ListOfCurrentOperations = neededOperations;
        return currentReport;
    }
}