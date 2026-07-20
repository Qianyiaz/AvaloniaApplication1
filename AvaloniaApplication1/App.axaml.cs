using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AvaloniaApplication1.Services;
using AvaloniaApplication1.ViewModels;

namespace AvaloniaApplication1;

public class App : Application
{
    public override void Initialize() => AvaloniaXamlLoader.Load(this);
    
    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop)
            return;

        using var sp = new AppServiceProvider();
        
        var mv = sp.GetService<MainWindow>();
        mv.DataContext = sp.GetService<MainWindowViewModel>();

        sp.GetService<INavigateView>().Target = mv.Control; 

        desktop.MainWindow = mv;
    }
}