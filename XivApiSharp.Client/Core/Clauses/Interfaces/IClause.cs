namespace XivApiSharp.Client.Core.Clauses.Interfaces;

public interface IClause
internal interface IClause
{ 
    string Specifier { get; set; }
    string Operator { get; set; }
    
    object Value { get; set; }
    string ToString();
}