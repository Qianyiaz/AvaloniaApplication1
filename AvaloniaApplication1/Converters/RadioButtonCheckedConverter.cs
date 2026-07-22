using System.Globalization;
using Avalonia.Data.Converters;

namespace AvaloniaApplication1.Converters;

public class RadioButtonCheckedConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
        value!.ToString() == parameter!.ToString();

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => null;
}