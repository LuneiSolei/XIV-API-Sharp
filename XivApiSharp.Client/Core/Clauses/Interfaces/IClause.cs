namespace XivApiSharp.Client.Core.Clauses.Interfaces;

public interface IClause
{ 
    string Specifier { get; set; }
    string Operator { get; set; }
    string ToString();
}