using XivApiSharp.Client.Core.Clauses.Interfaces;

namespace XivApiSharp.Client.Core.Clauses;

public class Clause<T> : IClause where T : notnull
{
    public string Specifier { get; set; }
    public string Operator { get; set; }
    public virtual T Value { get; set; }

    object IClause.Value
    {
        get => Value;
        set => Value = (T)value;
    }

    public override string ToString()
    {
        return $"{Specifier}{Operator}{Value}";
    }
}