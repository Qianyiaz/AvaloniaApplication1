using Avalonia.Collections;
using Avalonia.Controls.Notifications;
using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaApplication1.ViewModels;

public partial class DownloadPageViewModel(INotificationService notification) : ObservableObject
{
    public AvaloniaList<string> LatestVersions { get; } =
    [
        "1.21.1",
        "1.20.1",
        "1.19.4",
        "1.18.2",
        "1.16.4",
        "1.12.2"
    ];

    [ObservableProperty] private string? _selectedVersion;

    partial void OnSelectedVersionChanged(string? value) => 
        notification.Show(new Notification($"You selected version {value}!", "This is a simple notification."));
}