using System.Net.Http.Headers;
using System.Text.Json;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Notifications;
using Avalonia.Platform.Storage;
using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogHostAvalonia;
using Downloader;

namespace AvaloniaApplication1.ViewModels;

public partial class MainWindowViewModel(INotificationService ns) : ObservableObject
{
    private static readonly HttpClient HttpClient = new()
    {
        DefaultRequestHeaders =
        {
            UserAgent = { new ProductInfoHeaderValue("ImpellerDownloader", "1.0") }
        }
    };
    
    [ObservableProperty] private double _progress;

    [ObservableProperty] private string? _platform;

    [ObservableProperty] private bool _isUseMirror = true;

    [ObservableProperty] private string? _hash;

    [ObservableProperty] private string? _saveFolderPath;

    [ObservableProperty] private string _fileName = "impeller_sdk.zip";

    private DownloadService _downloader = new(new DownloadConfiguration
    {
        ChunkCount = 32,
        ParallelDownload = true
    });
    
    /*[ObservableProperty] private int _chunkCount = 32;

    partial void OnChunkCountChanged(int value)
    {
        _downloader = new(new DownloadConfiguration
        {
            ChunkCount = value,
            ParallelDownload = true
        });
    }*/

    [RelayCommand]
    private async Task DownloadAsync()
    {
        try
        {
            var hash = Hash;
            if (string.IsNullOrWhiteSpace(hash)) hash = await GetLatestFlutterHashAsync();

            var baseUrl = IsUseMirror
                ? "https://storage.flutter-io.cn/flutter_infra_release/flutter"
                : "https://storage.googleapis.com/flutter_infra_release/flutter";
            var url = $"{baseUrl}/{hash}/{Platform}/impeller_sdk.zip";

            if (SaveFolderPath == null) await SelectFolder();
            var savePath = Path.Combine(SaveFolderPath!, FileName);

            Progress = 0;
            _ = DialogHost.Show(null,"MainDialogHost");
            _downloader.DownloadProgressChanged += (_, args) => Progress = args.ProgressPercentage; 
            await _downloader.DownloadFileTaskAsync(url, savePath);
            
            DialogHost.Close("MainDialogHost");
            ns.Show(new Notification("Download Successfully", savePath));
        }
        catch (Exception ex)
        {
            ns.Show(new Notification("Download Failed", ex.Message, NotificationType.Error));
        }
    }

    [RelayCommand]
    private async Task SelectFolder()
    {
        var folders =
            await (Application.Current!.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)!.MainWindow!
                .StorageProvider.OpenFolderPickerAsync(
                    new FolderPickerOpenOptions
                    {
                        Title = "Select Saved Folder",
                        AllowMultiple = false
                    });

        if (folders.Count == 0) return;
        SaveFolderPath = folders[0].Path.LocalPath;
    }

    /*
    [RelayCommand]
    private void Close()
    {
        _downloader.Pause();
    }*/

    private static async Task<string> GetLatestFlutterHashAsync()
    {
        const string url = "https://api.github.com/repos/flutter/flutter/commits/master";
        var json = await HttpClient.GetStringAsync(url);

        using var doc = JsonDocument.Parse(json);
        var sha = doc.RootElement.GetProperty("sha").GetString()!;
        return sha;
    }
}