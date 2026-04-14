namespace XivApiSharp.Client.Core.Clauses;

public class Clause<T> : IClause
{
    public string Specifier { get; set; }
    public string Operator { get; set; }
    public virtual T Value { get; set; }

    public override string ToString()
    {
        return $"{Specifier}{Operator}{Value}";
    }
}