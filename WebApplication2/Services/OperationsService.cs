using System.Net;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Services;

public class OperationsService : IOperationService
{
    private readonly ApiContext _apiContext;
    private readonly ITypeService _typeService;

    public OperationsService(ApiContext apiContext, ITypeService typeService)
    {
        _apiContext = apiContext;
        _typeService = typeService;
    }

    public async Task<bool> isExist(Guid id)
    {
        if (await _apiContext.Operations.Where(o =>
                o.Id.Equals(id)).AnyAsync() == true )
        {
            return true;
        }
        else return false;
    }

    public async Task<bool> Create(Guid typeId, DateTime dateTime, decimal amount)
    {
        if (await isExist(typeId, dateTime, amount)) return false;

        var newGuid = Guid.NewGuid();
        var currentDateTime = dateTime;
        await _apiContext.Operations.AddAsync(new Operation
        {
            Amount = amount,
            DateOfOperations = currentDateTime,
            Id = newGuid,
            TypeId = typeId
        });
        await _apiContext.SaveChangesAsync();
        return true;
    }

    public async Task<Operation> Get(Guid id)
    {
        if (await isExist(id)==false) throw new WebException("Element isnt find");

        var operation = await _apiContext.Operations.Where(o => o.Id.Equals(id)).FirstAsync();
        return operation;
    }

    public async Task<bool> Update(Operation operation)
    {
        if (await isExist(operation.Id)==false) return false;

        var changeOperation = await _apiContext.Operations.Where
            (o => o.Id.Equals(operation.Id)).FirstAsync();
        if (!await _typeService.isExist(operation.TypeId))
        {
            return false;
        }

        changeOperation.TypeId = operation.TypeId;
        changeOperation.DateOfOperations = operation.DateOfOperations;
        changeOperation.Amount = operation.Amount;
        await _apiContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(Guid id)
    {
        if (await isExist(id)==false) return false;

        _apiContext.Remove(await _apiContext.Operations.Where
            (o => o.Id.Equals(id)).FirstAsync());
        await _apiContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> isExist(Guid typeId, DateTime dateTime, decimal amount)
    {
        if (await _apiContext.Operations.Where(o =>
                    o.TypeId.Equals(typeId) &
                    (o.DateOfOperations.CompareTo(dateTime) == 0) &
                    (o.Amount == amount))
                .AnyAsync() == true)
        {
            return true;
        }
            
       else return false;
    }
}