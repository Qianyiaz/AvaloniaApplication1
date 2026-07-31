using Avalonia.Collections;

namespace AvaloniaApplication1.ViewModels;

public class DownloadPageViewModel
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
}