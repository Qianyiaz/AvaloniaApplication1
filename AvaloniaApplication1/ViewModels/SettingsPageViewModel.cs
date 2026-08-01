using Avalonia;
using Avalonia.Collections;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public partial class SettingsPageViewModel : ObservableObject
{
    public AvaloniaList<string> ThemeOptions { get; } = ["Light", "Dark", "System"];

    [ObservableProperty] private string _selectedTheme =
        Application.Current!.RequestedThemeVariant == ThemeVariant.Default
            ? "System" : Application.Current.RequestedThemeVariant!.Key.ToString()!;

    partial void OnSelectedThemeChanged(string value) => Application.Current!.RequestedThemeVariant = value switch
    {
        "Light" => ThemeVariant.Light,
        "Dark" => ThemeVariant.Dark,
        _ => ThemeVariant.Default
    };
}