using System.Runtime.InteropServices.JavaScript;
using WebApplication2.DTO;

namespace WebApplication2.Services;

public interface iFinancinalOperations
{
    public bool isOperationExist(Guid id);
    public string CreateOperation(string id,Guid typeId,string dateTime,float amount);
    public string GetOperation(Guid id);
    public string UpdateOperation(Guid id, Guid typesId, string dateTime,
        float amount);
    public string RemoveOperation(Guid id);

    public Report DailyReport();

    public Report CustomDaysReport(string startDate, string endDate);
    public Report LookingForReport(List<Operation> neededOperations);
    public float TotalCharge(List<float> chargeList);
    public DateTime MoveToCorrectDate(string dateTime);


}