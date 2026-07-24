using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INavigationService _nav;

    public MainWindowViewModel(Func<int, object> pageFactory, INavigationService nav)
    {
        _nav = nav;

        _nav.Navigated += id =>
        {
            CurrentPage = pageFactory(id);
            IsCanGoBack = nav.CanGoBack;
            SetProperty(ref _selectedPageId, id, nameof(SelectedPageId));
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