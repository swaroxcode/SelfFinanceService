using WebApplication2.DTO;

namespace WebApplication2.Services;

public interface IOperationService
{
    public Task<bool> isExist(Guid id);
    public Task<bool> Create(Guid typeId, DateTime dateTime, decimal amount);
    public Task<OperationToShowDTO> Get(Guid id);
    public Task<bool> Update(Operation operation);
    public Task<bool> Remove(Guid id);
    public Task<List<OperationToShowDTO>> GetAllOpertion();
}