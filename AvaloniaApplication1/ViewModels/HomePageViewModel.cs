using Avalonia;
using Avalonia.Controls.Notifications;
using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Downloader;

namespace AvaloniaApplication1.ViewModels;

public partial class HomePageViewModel(INotificationService manager) : ObservableObject
{
    private DownloadService _downloadService = new(new DownloadConfiguration
    {
        // Number of file parts, default is 1
        ChunkCount = 32,
        // Download parts in parallel (default is false)
        ParallelDownload = true
    });

    [ObservableProperty] private string _content = "Login";

    [ObservableProperty] private string? _username;

    [ObservableProperty] private string? _password;

    [RelayCommand]
    private void Login()
    {
        _downloadService.DownloadProgressChanged +=
            (_, args) => Content = $"Already Download {args.ProgressPercentage}.";
        _downloadService.DownloadFileCompleted += (_, _) =>
            Application.Current!.Dispatcher.Invoke(() =>
                manager.Show(new Notification("Download Successfully", "abababa")));
        _downloadService.DownloadFileTaskAsync("https://avatars.githubusercontent.com/u/6759207?s=64&v=4");
    }
}