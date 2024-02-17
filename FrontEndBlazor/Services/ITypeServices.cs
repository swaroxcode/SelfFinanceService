using Type = BlazorApp2.DAL.Entity.Type;

namespace BlazorApp2.Services;

public interface ITypeServices
{
    public Task<List<Type>?> GetAll();
    public Task<bool> CreateNewType(string name, string expenceOrIncome);
    public Task<bool> UpdateType(Guid id, string name, string expenceOrIncome);
    public Task<bool> RemoveType(Guid id);
}