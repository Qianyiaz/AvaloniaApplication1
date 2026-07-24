using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    private readonly INavigationService _nav;

    public MainWindowViewModel(PageViewModelFactory pf, INavigationService nav, IMessenger messenger)
    {
        _nav = nav;

        messenger.Register<NavigateMessage>(this, (_, message) =>
        {
            IsCanGoBack = nav.CanGoBack;
            CurrentPage = pf(message.PageId);
            SetProperty(ref _selectedPageId, message.PageId, nameof(SelectedPageId));
        });

        _nav.Navigate(0);
    }

    [ObservableProperty] private object? _currentPage;

    [ObservableProperty] private int _selectedPageId;

    partial void OnSelectedPageIdChanged(int value) => _nav.Navigate(value);

    [ObservableProperty] private bool _isCanGoBack;

    [RelayCommand]
    private void GoBack() => _nav.GoBack();
}