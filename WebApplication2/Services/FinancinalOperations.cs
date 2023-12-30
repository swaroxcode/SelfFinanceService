using System.Globalization;
using Azure;
using WebApplication2.DTO;

namespace WebApplication2.Services;

public class FinancinalOperations : iFinancinalOperations
{
    private readonly ApiContext _apiContext;
    private ListOfTypes _listOfTypes;

    public FinancinalOperations(ApiContext apiContext)
    {
        _apiContext = apiContext;
        _listOfTypes = new ListOfTypes(_apiContext);
    }
    public bool isOperationExist(Guid id)
    {
        if (_apiContext.Operations.Where(o => o.id.Equals(id)).FirstOrDefault() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string CreateOperation(string id,Guid typeId,string dateTime,float amount,string typeName, ExpenceOrIncome expenceOrIncome)
    {
        Type type;
        if (!isOperationExist(Guid.Parse(id)))
        {
            if (_listOfTypes.isTypeExist(typeId))
            {
                type = _listOfTypes.GetType(typeId);
            }
            else
            {
              type = _listOfTypes.CreateNewType(typeName, expenceOrIncome);
                
            }

            Guid newGuid = Guid.NewGuid();
            var currentDateTime = MoveToCorrectDate(dateTime);
            _apiContext.Operations.Add(new Operation()
                { amount = amount, dateOfOperations = currentDateTime, id = newGuid, type = type });
            _apiContext.SaveChanges();
            return "Operation is created";
        }
        else return "Operation is already exist";
    }

    public string GetOperation(Guid id)
    {
        if (isOperationExist(id))
        {
            return _apiContext.Operations.Where(o => o.id.Equals(id)).FirstOrDefault().ToString();
        }
        else return "Operations is not exist";
    }

    public string UpdateOperation(Guid id,Guid typesId, string dateTime, float amount)
    {
        if (isOperationExist(id))
        {
            var changeOperation = _apiContext.Operations.Where(o => o.id.Equals(id)).FirstOrDefault();
            if (_listOfTypes.isTypeExist(typesId))
            {
                changeOperation.typeId = typesId;
                changeOperation.type = _listOfTypes.GetType(typesId);
                changeOperation.dateOfOperations = MoveToCorrectDate(dateTime);
                changeOperation.amount = amount;
                _apiContext.SaveChanges();
                return "Operations is changed";
            }
            else
            {
                return "Wrong id for Types";
            }
        }
        else return "Operation is not exist";
    }

    public string RemoveOperation(Guid id)
    {
        if (isOperationExist(id))
        {
            _apiContext.Remove(_apiContext.Operations.Where(o => o.id.Equals(id)).FirstOrDefault());
            _apiContext.SaveChanges();
            return "Operation is removed";
        }
        else return "Operation is not exist";
    }

    public Report DailyReport()
    {
        Report currentReport = new Report();
        var today = MoveToCorrectDate(DateTime.Today.ToString());
        List<Operation> dailyOperations = _apiContext.Operations.Where(
            o => o.dateOfOperations.Equals(today)).ToList();
        return LookingForReport(dailyOperations);
    }

    public Report CustomDaysReport(string startDate, string endDate)
    {
        
        var _startDay = MoveToCorrectDate(startDate);
        var _endDay = MoveToCorrectDate(endDate);
        List<Operation> customDateOperations = _apiContext.Operations.Where(o =>
            DateTime.Compare(o.dateOfOperations, _startDay) > 0 &
            DateTime.Compare(o.dateOfOperations, _endDay) < 0).ToList();
        return LookingForReport(customDateOperations);

    }

    public DateTime MoveToCorrectDate(string dateTime)
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        string pattern = "MM-dd-yy";
        return  DateTime.ParseExact(dateTime, pattern,provider);
    }

    public float TotalCharge(List<float> chargeList)
    {
        float totalcharge = 0;
        foreach (var charge in chargeList)
        {
            totalcharge = totalcharge + charge;
        }

        return totalcharge;
    }

    public Report LookingForReport(List<Operation> neededOperations)
    {
        var currentReport = new Report();
        List<float> allIncome = neededOperations.Where(o => o.type.expenceOrIncome == ExpenceOrIncome.Income)
            .Select(o => o.amount).ToList();
        List<float> allExpence = neededOperations.Where(o => o.type.expenceOrIncome == ExpenceOrIncome.Expence)
            .Select(o => o.amount).ToList();
        currentReport.totalExpence = TotalCharge(allExpence);
        currentReport.totalIncome = TotalCharge(allIncome);
        currentReport.listOfCurrentOperations = neededOperations;
        return currentReport;
    }
}