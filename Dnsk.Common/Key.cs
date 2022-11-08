using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Dnsk.Common;

public interface IKeyed
{
    Key Key { get; }
}

[TypeConverter(typeof(KeyConverter))]
public record Key
{
    public const int Min = 1;
    public const int Max = 50;
    public string Value { get; }

    public Key(string value)
    {
        Value = value;
        Validate();
    }

    private void Validate()
    {
        var str = Value;
        if (str.Length is < Min or > Max)
        {
            throw new InvalidDataException($"{str} must be {Min} to {Max} characters long");
        }
        if (Regex.IsMatch(str, @"__"))
        {
            throw new InvalidDataException($"{str} must not contain double underscores");
        }
        if (!Regex.IsMatch(str, @"^[a-z]"))
        {
            throw new InvalidDataException($"{str} must start with a lower case letter");
        }
        if (Regex.IsMatch(str, @"_$"))
        {
            throw new InvalidDataException($"{str} must not end with _");
        }
        if (!Regex.IsMatch(str, @"^[a-z0-9_]+$"))
        {
            throw new InvalidDataException($"{str} must only container lower case letters, digits and underscore");
        }
    }

    public static bool IsValid(string maybeKey)
    {
        try
        {
            var _ = new Key(maybeKey);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static explicit operator Key?(string? b) => b is null ? null : new Key(b);

    public override string ToString() => Value;
}

public class KeyConverter : TypeConverter
{
    // Overrides the CanConvertFrom method of TypeConverter.
    // The ITypeDescriptorContext interface provides the context for the
    // conversion. Typically, this interface is used at design time to
    // provide information about the design-time container.
    public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType)
    {
        if (sourceType == typeof(string))
        {
            return true;
        }
        return base.CanConvertFrom(context, sourceType);
    }

    // Overrides the ConvertFrom method of TypeConverter.
    public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
    {
        if (value is string s)
        {
            return new Key(s);
        }
        return base.ConvertFrom(context, culture, value);
    }

    // Overrides the ConvertTo method of TypeConverter.
    public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
    {
        if (destinationType == typeof(string) && value is not null)
        {
            return ((Key)value).Value;
        }
        return base.ConvertTo(context, culture, value, destinationType);
    }
}