namespace WebApplication2.Services;

public interface iListOftypes
{
    public Type CreateNewType(string typeName, ExpenceOrIncome expenceOrIncome);
    public List<Type> GetAllTypes();
    public Type GetType(Guid id);
    public string UpdateType(Guid id, string typeName, string newTypeName,
        ExpenceOrIncome expenceOrIncome,ExpenceOrIncome newExpenceOrIncome);
    public string RemoveType(Guid id);
    public bool isTypeExist(Guid id);
}