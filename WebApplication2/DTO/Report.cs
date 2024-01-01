using Azure;

namespace WebApplication2.DTO;

public class Report
{
    public double totalIncome { get; set; }
    public double totalExpence { get; set; }
    public List<Operation> listOfCurrentOperations { get; set; }
}