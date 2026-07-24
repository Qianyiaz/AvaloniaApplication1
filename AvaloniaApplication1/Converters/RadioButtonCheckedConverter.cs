using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace AvaloniaApplication1.Converters;

public class RadioButtonCheckedConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        string.Equals(value!.ToString(), parameter as string, StringComparison.Ordinal);

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value is true ? System.Convert.ChangeType(parameter, targetType)! : BindingOperations.DoNothing;
}