namespace XivApiSharp.Client.Core;

[AttributeUsage(AttributeTargets.Field)]
internal sealed class StringValueAttribute : Attribute
{
    public string Value { get; }
    public StringValueAttribute(string value) => Value = value;
}