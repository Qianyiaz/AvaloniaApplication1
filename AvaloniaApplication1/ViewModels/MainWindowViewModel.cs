using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel(INavigateView nv) : ObservableObject
{
    [RelayCommand]
    private void Navigate(string tag) => nv.Navigate(int.Parse(tag));
}