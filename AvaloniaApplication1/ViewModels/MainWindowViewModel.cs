using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

    [ObservableProperty] private object? _currentPage;

    [ObservableProperty] private bool _isCanGoBack;

    [ObservableProperty] private int _selectedPageId;

    public MainWindowViewModel(PageViewModelFactory pageFactory, INavigationService navigation)
    {
        _navigation = navigation;

        _navigation.Navigated += id =>
        {
            IsCanGoBack = _navigation.CanGoBack;
            CurrentPage = pageFactory(id);
            SetProperty(ref _selectedPageId, id, nameof(SelectedPageId));
        };

        _navigation.Navigate(0);
    }

    partial void OnSelectedPageIdChanged(int value) => _navigation.Navigate(value);

    [RelayCommand]
    private void GoBack() => _navigation.GoBack();
}