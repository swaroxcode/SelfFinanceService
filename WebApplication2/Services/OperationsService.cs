using System.Net;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Services;

public class OperationsService : IOperationService
{
    private readonly ApiContext _apiContext;
    private ITypeService _typeService;

    public OperationsService(ApiContext apiContext,ITypeService typeService)
    {
        _apiContext = apiContext;
        _typeService = typeService;
    }
    public bool isExist(Guid id)
    {
        if (_apiContext.Operations.Where(o => 
                o.Id.Equals(id)).FirstAsync() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> Create(Guid typeId, DateOnly dateTime, decimal amount)
    {
        if (await isExist(typeId, dateTime, amount))
        {
            return false;
        }
        else
        {
            Guid newGuid = Guid.NewGuid();
            var currentDateTime = dateTime;
            await _apiContext.Operations.AddAsync(new Operation()
            {
                Amount = amount,
                DateOfOperations = currentDateTime,
                Id = newGuid,
                TypeId = typeId
            });
            await _apiContext.SaveChangesAsync();
            return true;
        }
    }

    public async Task<Operation> Get(Guid id)
    {
        if (!isExist(id))
        {
            throw new WebException("Element isnt find");
        }

        var operation = await _apiContext.Operations.Where
            (o => o.Id.Equals(id)).FirstAsync();
        return operation;
    }

    public async Task<bool> Update(Operation operation)
    {
        if (!isExist(operation.Id))
        {
            return false;
        }
        else
        {
            var changeOperation = await _apiContext.Operations.Where
                (o => o.Id.Equals(operation.Id)).FirstAsync();
            if (!await _typeService.isExist(operation.TypeId))
            {
                return false;
            }
            else
            {
                changeOperation.TypeId = operation.TypeId;
                changeOperation.DateOfOperations = operation.DateOfOperations;
                changeOperation.Amount = operation.Amount;
                await _apiContext.SaveChangesAsync();
                return true;
            }
        }
    }

    public async Task<bool> Remove(Guid id)
    {
        if (!isExist(id))
        {
            return false;
        }
        else
        {
            _apiContext.Remove(await _apiContext.Operations.Where
                (o => o.Id.Equals(id)).FirstAsync());
            await _apiContext.SaveChangesAsync();
            return true;
        }
    }

    public async Task<bool> isExist(Guid typeId, DateOnly dateTime, decimal amount)
    {
        if (await _apiContext.Operations.Where(o =>
                    o.TypeId.Equals(typeId) & 
                    o.DateOfOperations.CompareTo(dateTime) == 0 &
                    o.Amount == amount)
                .FirstAsync() != null)
        {
            return true;
        }
        else return false;
    }
}