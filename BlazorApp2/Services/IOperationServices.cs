using ConsoleApp1.DAL.Entity;
namespace BlazorApp2.Services;

public interface IOperationServices
{
    public Task<Operation> GetSomeOperation(Guid id);
    public Task<bool> CreateNewOperation(Guid typeId, DateTime dateOfOperation, decimal amount);
    public Task<bool> UpdateOperation(Guid id, Guid typeId, DateTime dateOfOperation, decimal amount);
    public Task<bool> RemoveOperation(Guid id);
}