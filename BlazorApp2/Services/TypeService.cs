using System.Text;
using ConsoleApp1.DAL.Entity;
using ConsoleApp1.DTO;
using Newtonsoft.Json;
using JsonException = System.Text.Json.JsonException;
using Type = ConsoleApp1.DAL.Entity.Type;

namespace BlazorApp2.Services;

public class TypeService : ITypeServices
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly HttpClient _httpClient;

    public TypeService(IHttpClientFactory httpClient)
    {
        _httpClientFactory = httpClient;
        _httpClient = _httpClientFactory.CreateClient("Main");
    }

    public async Task<List<Type>?> GetAll()
    {
        var allTypes = new List<Type>();
        var httpResponceMessage = await _httpClient.GetAsync("/api/Types");
        if (httpResponceMessage.IsSuccessStatusCode)
            try
            {
                using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
                allTypes = JsonConvert.DeserializeObject<List<Type>>(contestStream.Result);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message);
            }

        return allTypes;
    }

    public async Task<bool> CreateNewType(string name, string expenceOrIncome)
    {
        var newType = new CreateTypeDto
        {
            ExpenceOrIncome = (ExpenceOrIncome)Enum.Parse(typeof(ExpenceOrIncome), expenceOrIncome), TypeName = name
        };
        var jsonType = JsonConvert.SerializeObject(newType);
        var content = new StringContent(jsonType, Encoding.UTF8, "application/json");
        var httpResponceMessage = await _httpClient.PostAsync("/api/Types", content);
        if (httpResponceMessage.IsSuccessStatusCode)
            return true;
        return false;
    }

    public async Task<bool> UpdateType(Guid id, string name, string expenceOrIncome)
    {
        var newType = new TypeDTO
        {
            ExpenceOrIncome = (ExpenceOrIncome)Enum.Parse(typeof(ExpenceOrIncome), expenceOrIncome), TypeName = name,
            Id = id
        };
        var jsonType = JsonConvert.SerializeObject(newType);
        var httpClient = _httpClientFactory.CreateClient("Main");
        var content = new StringContent(jsonType, Encoding.UTF8, "application/json");
        var httpResponceMessage = await httpClient.PutAsync("/api/Types", content);
        if (httpResponceMessage.IsSuccessStatusCode)
            return true;
        return false;
    }

    public async Task<bool> RemoveType(Guid id)
    {
        var addressToRemove = $"/api/Types/{id}";
        var httpResponceMessage = await _httpClient.DeleteAsync(addressToRemove);
        if (httpResponceMessage.IsSuccessStatusCode)
            return true;
        return false;
    }
}