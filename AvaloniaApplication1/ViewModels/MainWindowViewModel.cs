using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private object? _currentPage;

    public MainWindowViewModel(INavigationService nav)
    {
        Nav = nav;
        Nav.Navigated += id =>
        {
            CurrentPage = id switch
            {
                0 => new HomePageViewModel(),
                1 => new SettingsPageViewModel(),
                _ => null
            };
        };
        Nav.Navigate(0);
    }

    public INavigationService Nav { get; }

    [RelayCommand]
    private void Navigate(string id) => Nav.Navigate(int.Parse(id));

    [RelayCommand]
    private void GoBack() => Nav.GoBack();
}