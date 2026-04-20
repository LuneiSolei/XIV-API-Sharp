using System.Reflection;

namespace XivApiSharp.Client.Core.Extensions;

internal static class EnumExtensions
{
    extension(Enum value)
    {
        public string GetStringValue()
        {
            ArgumentNullException.ThrowIfNull(value);

            Type type = value.GetType();
            string? name = Enum.GetName(type, value);
            if (name is null) return value.ToString();

            FieldInfo? field = type.GetField(name);
            if (field is null) return value.ToString();
            
            StringValueAttribute? attr = field.GetCustomAttribute<StringValueAttribute>();
            return attr?.Value ?? name;
        }
    }
}