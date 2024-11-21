namespace InsellerateApi.Models;

public class IQLQueryBuilder
{
    private readonly List<string> _conditions = [];

    public IQLQueryBuilder Where(InsellerateField field, string value)
    {
        _conditions.Add($"[{field.GetFieldId()}]=\"{value}\"");
        return this;
    }

    public IQLQueryBuilder And(InsellerateField field, string value)
    {
        _conditions.Add($"AND [{field.GetFieldId()}]=\"{value}\"");
        return this;
    }

    public IQLQueryBuilder Or(InsellerateField field, string value)
    {
        _conditions.Add($"OR [{field.GetFieldId()}]=\"{value}\"");
        return this;
    }

    public string Build()
    {
        return string.Join(" ", _conditions);
    }
}