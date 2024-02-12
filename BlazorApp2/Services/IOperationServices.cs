using MudBlazor;

namespace BlazorApp2.Services;

public interface IOperationServices
{
    public Task<WebApplication2.Operation> GetSomeOperation(Guid id);
    public Task<bool> CreateNewOperation(Guid TypeId, DateTime date, decimal amount);
    public Task<bool> UpdateOperation(Guid id, Guid TypeId, DateTime dateTime, decimal amount);
    public Task<bool> RemoveOperation(Guid id);
}