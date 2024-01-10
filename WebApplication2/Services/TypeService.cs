using System.Net;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Services;

public class TypeService : ITypeService
{
    private readonly ApiContext _apiContext;

    public TypeService(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }

    public async Task<bool> CreateNew(string typeName, ExpenceOrIncome expenceOrIncome)
    {
        if (!await isExist(typeName, expenceOrIncome)) return false;

        var type = new Type
        {
            TypeName = typeName,
            ExpenceOrIncome = expenceOrIncome,
            Id = Guid.NewGuid()
        };
        await _apiContext.Types.AddAsync(type);
        await _apiContext.SaveChangesAsync();
        return true;
    }

    public async Task<List<Type>> GetAll()
    {
        return await _apiContext.Types.ToListAsync();
    }

    public async Task<Type> Get(Guid id)
    {
        if (!await isExist(id)) throw new WebException("Task isn`t found");
        var type = await _apiContext.Types
            .Where(t => t.Id.Equals(id))
            .FirstAsync();
        return type;
    }

    public async Task<bool> Update(Guid id, string newTypeName, ExpenceOrIncome newExpenceOrIncome)
    {
        if (!await isExist(id)) return false;

        if (!await isExist(newTypeName, newExpenceOrIncome))
        {
            return false;
        }

        var newType = await _apiContext.Types
            .Where(t => t.Id.Equals(id))
            .FirstAsync();
        newType.TypeName = newTypeName;
        newType.ExpenceOrIncome = newExpenceOrIncome;
        await _apiContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Remove(Guid id)
    {
        if (!await isExist(id)) return false;

        _apiContext.Types.Remove(await _apiContext.Types
            .Where(t => t.Id.Equals(id))
            .FirstAsync());
        return true;
    }

    public async Task<bool> isExist(Guid id)
    {
        if (await _apiContext.Types.Where
                (type => type.Id.Equals(id)).FirstAsync() != null)
            return true;
        return false;
    }

    public async Task<bool> isExist(string typeName, ExpenceOrIncome expenceOrIncome)
    {
        if (await _apiContext.Types.Where
                    (t => t.TypeName.Equals(typeName) & t.ExpenceOrIncome.Equals(expenceOrIncome))
                .FirstAsync() == null)
            return true;
        return false;
    }
}