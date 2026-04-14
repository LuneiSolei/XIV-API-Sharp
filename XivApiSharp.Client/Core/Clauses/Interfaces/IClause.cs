namespace XivApiSharp.Client.Core.Clauses;

public interface IClause
{ 
    string Specifier { get; set; }
    string Operator { get; set; }
    string ToString();
}