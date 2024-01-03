using System.Runtime.InteropServices.JavaScript;
using WebApplication2.DTO;

namespace WebApplication2.Services;

public interface IOperationService
{
    public bool isExist(Guid id);
    public Task<bool> Create(Guid typeId,DateTime dateTime,decimal amount);
    public Task<Operation> Get(Guid id);
    public Task<bool> Update(Guid id, Guid typesId, DateTime dateTime,
        decimal amount);
    public Task<bool> Remove(Guid id);


}