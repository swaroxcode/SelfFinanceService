using BlazorApp2.DAL.Entity;
using BlazorApp2.DTO;

namespace BlazorApp2.Services;

public interface IOperationServices
{
    public Task<OperationToShowDTO> GetSomeOperation(Guid id);
    public Task<bool> CreateNewOperation(Guid typeId, DateTime? dateOfOperation, decimal amount);
    public Task<bool> UpdateOperation(Guid id, Guid typeId, DateTime? dateOfOperation, decimal amount);
    public Task<bool> RemoveOperation(Guid id);
    public Task<List<OperationToShowDTO>?> GetAll();
}