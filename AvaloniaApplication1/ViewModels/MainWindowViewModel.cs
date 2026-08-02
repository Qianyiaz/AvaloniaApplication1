using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INavigationService _navigation;

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

    [ObservableProperty] private object? _currentPage;

    [ObservableProperty] private int _selectedPageId;

    partial void OnSelectedPageIdChanged(int value) => _navigation.Navigate(value);

    [ObservableProperty] private bool _isCanGoBack;

    [RelayCommand]
    private void GoBack() => _navigation.GoBack();
}