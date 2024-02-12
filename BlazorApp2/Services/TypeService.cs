using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication2;
using WebApplication2.DTO;
using Type = WebApplication2.Type;
namespace BlazorApp2.Services;


public class TypeService : ITypeServices
{
    public readonly IHttpClientFactory _httpClientFactory;

    public TypeService(IHttpClientFactory httpClient)
    {
        _httpClientFactory = httpClient;
    }
    public async Task<List<Type>?> GetAll()
    {
        List<Type>? allTypes = new List<Type>();
        var httpClient = _httpClientFactory.CreateClient("Main");
        var httpResponceMessage =  httpClient.GetAsync("/api/Types").Result;
        if (httpResponceMessage.IsSuccessStatusCode)
        {
             using var contestStream = httpResponceMessage.Content.ReadAsStringAsync();
            allTypes =  Newtonsoft.Json.JsonConvert.DeserializeObject<List<Type>>(contestStream.Result);
        }
    
        return allTypes;
    }

    public async Task<bool> CreateNewType(string name, string expenceOrIncome)
    {
        var newType = new CreateTypeDto{ExpenceOrIncome = (ExpenceOrIncome)Enum.Parse(typeof(ExpenceOrIncome), expenceOrIncome),TypeName = name};
        var jsonType = Newtonsoft.Json.JsonConvert.SerializeObject(newType);
        var httpClient = _httpClientFactory.CreateClient("Main");
        var content = new StringContent(jsonType, Encoding.UTF8, "application/json");
        var httpResponceMessage = httpClient.PostAsync("/api/Types", content).Result;
        if (httpResponceMessage.IsSuccessStatusCode)
        {
            return true;
        }
        else return false;
    }  
    public async Task<bool> UpdateType(Guid id,string name, string expenceOrIncome)
    {
        var newType = new TypeDTO{ExpenceOrIncome = (ExpenceOrIncome)Enum.Parse(typeof(ExpenceOrIncome), expenceOrIncome),TypeName = name,Id = id};
        var jsonType = Newtonsoft.Json.JsonConvert.SerializeObject(newType);
        var httpClient = _httpClientFactory.CreateClient("Main");
        var content = new StringContent(jsonType, Encoding.UTF8, "application/json");
        var httpResponceMessage = httpClient.PutAsync("/api/Types", content).Result;
        if (httpResponceMessage.IsSuccessStatusCode)
        {
            return true;
        }
        else return false;
    }

    public async Task<bool> RemoveType(Guid id)
    {
        var AdressToRemove = "/api/Types/"+id.ToString();
        var httpClient = _httpClientFactory.CreateClient("Main");
        var httpResponceMessage = httpClient.DeleteAsync(AdressToRemove).Result;
        if (httpResponceMessage.IsSuccessStatusCode)
        {
            return true;
        }
        else return false;
    }   
}