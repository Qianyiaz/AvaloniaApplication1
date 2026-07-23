using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INavigationService _nav;
    
    public MainWindowViewModel(INavigationService nav)
    {
        _nav = nav;
        
        _nav.Navigated +=  id =>
        {
            SelectedPageId = id;
            IsCanGoBack = nav.CanGoBack;

            CurrentPage = id switch
            {
                0 => new HomePageViewModel(),
                1 => new SettingsPageViewModel(),
                _ => null
            };
        };
        
        _nav.Navigate(0);
    }
    
    [ObservableProperty] private object? _currentPage;

    [ObservableProperty] private int _selectedPageId;

    partial void OnSelectedPageIdChanged(int value) => _nav.Navigate(value);

    [ObservableProperty] private bool _isCanGoBack;
    
    [RelayCommand]
    private void GoBack() => _nav.GoBack();
}