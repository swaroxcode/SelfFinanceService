using Microsoft.EntityFrameworkCore;
using WebApplication2.DTO;

namespace WebApplication2.Services;

public class ReportService : IReportService
{
    private readonly ApiContext _apiContext;
    private readonly ITypeService _typeService;

    public ReportService(ApiContext apiContext, ITypeService typeService)
    {
        _apiContext = apiContext;
        _typeService = typeService;
    }

    public async Task<ReportDTO> DailyReport(DateTime dateOfOperation)
    {
        var currentReportDto = new ReportDTO();
        List<Operation> dailyOperations = await (from
                operation in _apiContext.Operations
            where operation.DateOfOperations.Equals(
                dateOfOperation)
            select operation).ToListAsync();
        return await LookingForReport(dailyOperations);
    }

    public async Task<ReportDTO> CustomDaysReport(DateTime startDate, DateTime endDate)
    {
        var customDateOperations = await _apiContext.Operations.Where(o =>
            (o.DateOfOperations.CompareTo(startDate) > 0) &
            (o.DateOfOperations.CompareTo(endDate) < 0)).ToListAsync();
        return await LookingForReport(customDateOperations);
    }


    public decimal TotalCharge(List<decimal> chargeList)
    {
        var totalcharge = chargeList.Sum();
        return totalcharge;
    }

    public async Task<ReportDTO> LookingForReport(List<Operation> neededOperation)
    {
        var currentReport = new ReportDTO();
        var allIncome = neededOperation.Where
                (o => _typeService.Get(o.TypeId).Result.ExpenceOrIncome == ExpenceOrIncome.Income)
            .Select(o => o.Amount).ToList();
        var allExpence = neededOperation.Where
                (o => _typeService.Get(o.TypeId).Result.ExpenceOrIncome == ExpenceOrIncome.Expence)
            .Select(o => o.Amount).ToList();
        currentReport.TotalExpence = TotalCharge(allExpence);
        currentReport.TotalIncome = TotalCharge(allIncome);
        List<OperationToShowDTO> finallListOperations = new List<OperationToShowDTO>();
        foreach (var operation in neededOperation)
        {
            var type = await _apiContext.Types.Where(t => t.Id.Equals(operation.TypeId)).FirstAsync();
            finallListOperations.Add(new OperationToShowDTO
            {
                Id = operation.Id,
                TypeName = type.TypeName,
                Amount = operation.Amount,
                DateOfOperations = operation.DateOfOperations
            });
        }

        currentReport.ListOfCurrentOperations = finallListOperations;
        return currentReport;
    }
}