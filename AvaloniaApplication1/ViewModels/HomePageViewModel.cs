using Avalonia.Controls.Notifications;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApplication1.ViewModels;

public partial class HomePageViewModel(IMessenger messenger) : ObservableObject
{
    [ObservableProperty] private string? _username;

    [ObservableProperty] private string? _password;

    [RelayCommand]
    private void Login() =>
        messenger.Send(
            new Notification($"Welcome {Username}!",
                $"Wait a Minute! I am a HACKER.\nI know YOUR NAME is: {Username}🤣🤣🤣, PASSWORD is {Password}.😂😂😂"));
}