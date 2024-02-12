using WebApplication2;
using WebApplication2.DTO;
using Type = System.Type;


namespace BlazorApp2.Services;

public interface ITypeServices
{
    public Task<List<WebApplication2.Type>?> GetAll();
    public Task<bool> CreateNewType(string name, string expenceOrIncome);
    public Task<bool> UpdateType(Guid id, string name, string expenceOrIncome);
    public Task<bool> RemoveType(Guid id);
}