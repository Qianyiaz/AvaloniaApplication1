using Avalonia.Controls.Notifications;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication1.ViewModels;

public partial class HomePageViewModel(INotificationManager manager) : ObservableObject
{
    [ObservableProperty] private string? _username;

    [ObservableProperty] private string? _password;

    [RelayCommand]
    private void Login() =>
        manager.Show(new Notification($"Welcome {Username}!",
            $"Wait a Minute! I am a HACKER.\nI know YOUR NAME is: {Username}🤣🤣🤣, PASSWORD is {Password}.😂😂😂"));
}