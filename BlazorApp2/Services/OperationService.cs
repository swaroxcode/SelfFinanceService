using System.Text;
using ConsoleApp1.DAL.Entity;
using ConsoleApp1.DTO;
using Newtonsoft.Json;

namespace BlazorApp2.Services;

public class OperationService : IOperationServices
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public OperationService(IHttpClientFactory httpClient)
    {
        _httpClientFactory = httpClient;
        _httpClient = _httpClientFactory.CreateClient("Main");
    }

    public async Task<Operation> GetSomeOperation(Guid id)
    {
        var adressToGet = $"/api/Operations/{id}";
        var httpResponceMessage = await _httpClient.GetAsync(adressToGet);
        if (!httpResponceMessage.IsSuccessStatusCode)
            throw new Exception(httpResponceMessage.StatusCode.ToString());
        try
        {
            using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Operation>(contestStream.Result);
        }
        catch (JsonException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> CreateNewOperation(Guid TypeId, DateTime date, decimal amount)
    {
        var newType = new OperationCreateDto
        {
            id = TypeId,
            amount = amount,
            date = date
        };
        var jsonType = JsonConvert.SerializeObject(newType);
        var content = new StringContent(jsonType, Encoding.UTF8, "application/json");
        var httpResponceMessage = await _httpClient.PostAsync("/api/Operations", content);
        if (httpResponceMessage.IsSuccessStatusCode)
            return true;
        return false;
    }

    public async Task<bool> UpdateOperation(Guid id, Guid TypeId, DateTime dateTime, decimal amount)
    {
        var updateType = new OperationUpdateDTO
        {
            Amount = amount,
            DateOfOperations = dateTime,
            Id = id,
            TypeId = TypeId
        };
        var jsonType = JsonConvert.SerializeObject(updateType);
        var content = new StringContent(jsonType, Encoding.UTF8, "application/json");
        var httpResponceMessage = await _httpClient.PutAsync("/api/Operations", content);
        if (httpResponceMessage.IsSuccessStatusCode)
            return true;
        return false;
    }

    public async Task<bool> RemoveOperation(Guid id)
    {
        var adressToRemove = $"/api/Operations{id}";
        var httpResponceMessage = await _httpClient.DeleteAsync(adressToRemove);
        if (httpResponceMessage.IsSuccessStatusCode)
            return true;
        return false;
    }
}