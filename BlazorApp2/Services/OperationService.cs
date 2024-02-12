using System.Text;
using Microsoft.VisualBasic.CompilerServices;
using MudBlazor;
using WebApplication2;
using WebApplication2.DTO;
using Type = System.Type;

namespace BlazorApp2.Services;

public class OperationService:IOperationServices
{
    public readonly IHttpClientFactory _httpClientFactory;
    
    public OperationService(IHttpClientFactory httpClient)
    {
        _httpClientFactory = httpClient;
    }

    public async Task<Operation> GetSomeOperation(Guid id)
    {
        var AdressToGet = "/api/Operations/"+id.ToString();
        var httpClient = _httpClientFactory.CreateClient("Main");
        var httpResponceMessage = httpClient.GetAsync(AdressToGet).Result;
        using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
        return  Newtonsoft.Json.JsonConvert.DeserializeObject<Operation>(contestStream.Result);
    }

    public async Task<bool> CreateNewOperation(Guid TypeId, DateTime date, decimal amount)
    {
        var newType = new OperationCreateDto{id = TypeId,amount = amount,date = date};
        var jsonType = Newtonsoft.Json.JsonConvert.SerializeObject(newType);
        var httpClient = _httpClientFactory.CreateClient("Main");
        var content = new StringContent(jsonType, Encoding.UTF8, "application/json");
        var httpResponceMessage =httpClient.PostAsync("/api/Operations", content).Result;
        if (httpResponceMessage.IsSuccessStatusCode)
        {
            return true;
        }
        else return false;
    }

    public async Task<bool> UpdateOperation(Guid id,Guid TypeId, DateTime dateTime, decimal amount)
    {
        var updateType = new OperationUpdateDTO{Amount =amount,DateOfOperations = dateTime,Id = id,TypeId = TypeId };
        var jsonType = Newtonsoft.Json.JsonConvert.SerializeObject(updateType);
        var httpClient = _httpClientFactory.CreateClient("Main");
        var content = new StringContent(jsonType, Encoding.UTF8, "application/json");
        var httpResponceMessage =httpClient.PutAsync("/api/Operations", content).Result;
        if (httpResponceMessage.IsSuccessStatusCode)
        {
            return true;
        }
        else return false;
    }

    public async Task<bool> RemoveOperation(Guid id)
    {
        var AdressToRemove ="/api/Operations"+id.ToString();
        var httpClient = _httpClientFactory.CreateClient("Main");
        var httpResponceMessage = httpClient.DeleteAsync(AdressToRemove).Result;
        if (httpResponceMessage.IsSuccessStatusCode)
        {
            return true;
        }
        else return false;
    }
}