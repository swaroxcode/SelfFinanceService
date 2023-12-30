namespace WebApplication2.Services;

public class ListOfTypes : iListOftypes
{
    private readonly ApiContext _apiContext;

    public ListOfTypes(ApiContext apiContext)
    {
        _apiContext = apiContext;
    }
    public Type CreateNewType(string typeName, ExpenceOrIncome expenceOrIncome)
    {
        if (_apiContext.Types.Where(t=>t.typeName.Equals(typeName)& t.expenceOrIncome.Equals(expenceOrIncome)).FirstOrDefault()==null)
        {
            var type = new Type() { typeName = typeName, expenceOrIncome = expenceOrIncome,id = Guid.NewGuid()};
            _apiContext.Types.Add(type);
            _apiContext.SaveChanges();
            return type ;
        }
        else return null;
    }

    public List<Type> GetAllTypes()
    {
        return _apiContext.Types.ToList();
    }

    public Type GetType(Guid id)
    {
        if (isTypeExist(id))
        {
            var type = _apiContext.Types
                .Where(t => t.id.Equals(id))
                .FirstOrDefault();
            return type;
        }
        else
        {
            return null;
        }
    }

    public string UpdateType(Guid id,string typeName, string newTypeName, ExpenceOrIncome _expenceOrIncome,ExpenceOrIncome newExpenceOrIncome)
    {
        if (isTypeExist(id))
        {
            var newType = _apiContext.Types
                .Where(t => t.id.Equals(id))
                .FirstOrDefault();
            newType.typeName =newTypeName;
            newType.expenceOrIncome = newExpenceOrIncome;
            _apiContext.SaveChanges();
            return "Type is successfully updated";
        }

        else return "this type isn`t finded";
    }

    public string RemoveType(Guid id)
    {
        if (isTypeExist(id))
        {
            _apiContext.Types.Remove(_apiContext.Types
                .Where(t => t.id.Equals(id))
                .FirstOrDefault());
            return "Element is removed";
        }
        else return "this type isn`t finded";
    }

    public bool isTypeExist(Guid id)
    {
        if (_apiContext.Types.Where(type =>type.id.Equals(id)).FirstOrDefault() != null)
        {
            return true;
        }
        else return false;
    }
}