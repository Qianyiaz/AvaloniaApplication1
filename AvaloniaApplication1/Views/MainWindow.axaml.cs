using Avalonia.Controls;
using AvaloniaApplication1.Services;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1.Views;

public partial class MainWindow : Window
{
    // ReSharper disable once MemberCanBePrivate.Global
    public MainWindow() => InitializeComponent();

    // ReSharper disable once UnusedMember.Global
    public MainWindow(MainWindowViewModel vm, INotificationService ns) : this()
    {
        DataContext = vm;
        Loaded += (_, _) => ns.Initialize(GetTopLevel(this)!);
    }
}