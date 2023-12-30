using Azure;

namespace WebApplication2.DTO;

public class Report
{
    public float totalIncome { get; set; }
    public float totalExpence { get; set; }
    public List<Operation> listOfCurrentOperations { get; set; }
}