namespace WebApplication2.Services;

public interface IOperationService
{
    public Task<bool> isExist(Guid id);
    public Task<bool> Create(Guid typeId, DateTime dateTime, decimal amount);
    public Task<Operation> Get(Guid id);
    public Task<bool> Update(Operation operation);
    public Task<bool> Remove(Guid id);
}