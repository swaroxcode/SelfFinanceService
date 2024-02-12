using System.Globalization;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebApplication2.DTO;

namespace BlazorApp2.Services;

public class ReportService: IReportService
{
    public readonly IHttpClientFactory _httpClientFactory;

    public ReportService(IHttpClientFactory httpClient)
    {
        _httpClientFactory = httpClient;
    }
    public async Task<ReportDTO> DailyReport(DateTime neededDate)
    {
        var AdressToGet = "/api/Report/daily?dayOfOperation="+neededDate.ToString("dd/MM/yyyy");
        var httpClient = _httpClientFactory.CreateClient("Main");
        var httpResponceMessage = httpClient.GetAsync(AdressToGet).Result;
        using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
        return  Newtonsoft.Json.JsonConvert.DeserializeObject<ReportDTO>(contestStream.Result);
        
    }

    public async Task<ReportDTO> DatePeriodReport(DateTime startDate, DateTime endDate)
    {
        var AdressToGet = "/api/Report/period?startDate="+startDate.ToString("dd/MM/yyyy")+"&endDate="+endDate.ToString("dd/MM/yyyy");
        var httpClient = _httpClientFactory.CreateClient("Main");
        var httpResponceMessage = httpClient.GetAsync(AdressToGet).Result;
        using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
        return  Newtonsoft.Json.JsonConvert.DeserializeObject<ReportDTO>(contestStream.Result);
    }
}