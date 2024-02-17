namespace WebApplication2.Services;

public interface ITypeService
{
    public Task<bool> CreateNew(string typeName, ExpenceOrIncome expenceOrIncome);
    public Task<List<Type>> GetAll();
    public Task<Type> Get(Guid id);
    public Task<bool> Update(Guid id, string newTypeName,ExpenceOrIncome newExpenceOrIncome);
    public Task<bool> Remove(Guid id);
    public Task<bool> isExist(Guid id);
}