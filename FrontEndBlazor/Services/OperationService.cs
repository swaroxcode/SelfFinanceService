using System.Text;
using BlazorApp2.DAL.Entity;
using BlazorApp2.DTO;
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

    public async Task<OperationToShowDTO> GetSomeOperation(Guid id)
    {
        var adressToGet = $"/api/Operations/{id}";
        var httpResponceMessage = await _httpClient.GetAsync(adressToGet);
        if (!httpResponceMessage.IsSuccessStatusCode)
            throw new Exception(httpResponceMessage.StatusCode.ToString());
        try
        {
            using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<OperationToShowDTO>(contestStream.Result);
        }
        catch (JsonException e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> CreateNewOperation(Guid typeId, DateTime? dateOfOperation, decimal amount)
    {
        var newType = new OperationCreateDto
        {
            Id = typeId,
            Amount = amount,
            DateOfOperation = dateOfOperation
        };
        var jsonType = JsonConvert.SerializeObject(newType);
        var content = new StringContent(jsonType, Encoding.UTF8, "application/json");
        var httpResponceMessage = await _httpClient.PostAsync("/api/Operations", content);
        if (httpResponceMessage.IsSuccessStatusCode)
            return true;
        return false;
    }

    public async Task<bool> UpdateOperation(Guid id, Guid typeId, DateTime? dateOfOperation, decimal amount)
    {
        var updateType = new OperationUpdateDTO
        {
            Amount = amount,
            DateOfOperations = dateOfOperation,
            Id = id,
            TypeId = typeId
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
        var adressToRemove = $"/api/Operations/{id}";
        var httpResponceMessage = await _httpClient.DeleteAsync(adressToRemove);
        if (httpResponceMessage.IsSuccessStatusCode)
            return true;
        return false;
    }

    public async Task<List<OperationToShowDTO>?> GetAll()
    {
        var allTypes = new List<OperationToShowDTO>();
        var httpResponceMessage = await _httpClient.GetAsync("/api/Operations");
        if (httpResponceMessage.IsSuccessStatusCode)
            try
            {
                using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
                allTypes = JsonConvert.DeserializeObject<List<OperationToShowDTO>>(contestStream.Result);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
            }

        return allTypes; 
    }
}