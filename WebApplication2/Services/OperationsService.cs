using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Services;

public class OperationsService : IOperationService
{
    private readonly ApiContext _apiContext;
    private ITypeService _typeService;

    public OperationsService(ApiContext apiContext,TypeService typeService)
    {
        _apiContext = apiContext;
        _typeService = typeService;
    }
    public bool isExist(Guid id)
    {
        if (_apiContext.Operations.Where(o => o.Id.Equals(id)).FirstAsync() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> Create(Guid typeId,DateTime dateTime,decimal amount)
    {
        if (! await isExist(typeId,dateTime,amount))
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
        else return false;
    }

    public async Task<Operation> Get(Guid id)
    {
        if (isExist(id))
        {
            var operation = await _apiContext.Operations.Where(o => o.Id.Equals(id)).FirstAsync();
            return operation;
        }
        else
        {
            await Task.FromException<Operation>(new DirectoryNotFoundException("Type isnt found"));
            return null;
        }

        
    }

    public async Task<bool> Update(Guid id,Guid typesId, DateTime dateTime, decimal amount)
    {
        if (isExist(id))
        {
            var changeOperation = await _apiContext.Operations.Where(o => o.Id.Equals(id)).FirstAsync();
            if (await _typeService.isExist(typesId))
            {
                changeOperation.TypeId = typesId;
                changeOperation.DateOfOperations = dateTime;
                changeOperation.Amount = amount;
                await _apiContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
        else return false;
    }

    public async Task<bool> Remove(Guid id)
    {
        if (isExist(id))
        {
            _apiContext.Remove(await _apiContext.Operations.Where(o => o.Id.Equals(id)).FirstAsync());
            await _apiContext.SaveChangesAsync();
            return true;
        }
        else return false;
    }

    public async Task<bool> isExist(Guid typeId, string dateTime, decimal amount)
    {
        if (await _apiContext.Operations.Where(o =>
                    o.TypeId.Equals(typeId) & o.DateOfOperations.CompareTo(DateTime.Parse(dateTime)) == 0 &
                    o.Amount == amount)
                .FirstAsync() != null)
        {
            return true;
        }
        else return false;
    }
}