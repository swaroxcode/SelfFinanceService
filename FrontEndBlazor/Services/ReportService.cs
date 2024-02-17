using BlazorApp2.DTO;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;

namespace BlazorApp2.Services;

public class ReportService : IReportService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public ReportService(IHttpClientFactory httpClient)
    {
        _httpClientFactory = httpClient;
        _httpClient = _httpClientFactory.CreateClient("Main");
    }

    public async Task<ReportDTO> DailyReport(DateTime? neededDate)
    {
        var adressToGet = "/api/Report/daily?dayOfOperation=" + neededDate;
        var httpResponceMessage = await _httpClient.GetAsync(adressToGet);
        if (!httpResponceMessage.IsSuccessStatusCode) throw new Exception(httpResponceMessage.StatusCode.ToString());
        try
        {
            using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReportDTO>(contestStream.Result);
        }
        catch (JsonException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ReportDTO> DatePeriodReport(DateTime? startDate, DateTime? endDate)
    {
        var adressToGet = $"/api/Report/period?startDate={startDate}&endDate={endDate}";
        var httpResponceMessage = await _httpClient.GetAsync(adressToGet);
        if (!httpResponceMessage.IsSuccessStatusCode) throw new Exception(httpResponceMessage.StatusCode.ToString());

        try
        {
            using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReportDTO>(contestStream.Result);
        }
        catch (JsonException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}