using System.Runtime.InteropServices.JavaScript;
using WebApplication2.DTO;

namespace WebApplication2.Services;

public interface IOperationService
{
    public bool isExist(Guid id);
    public Task<bool> Create(Guid typeId,DateOnly dateTime,decimal amount);
    public Task<Operation> Get(Guid id);
    public Task<bool> Update(Operation operation);
    public Task<bool> Remove(Guid id);


}