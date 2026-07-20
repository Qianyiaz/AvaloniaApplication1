using Avalonia;
using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Styling;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    private readonly UserControl _homeView = new HomePage();

    private readonly UserControl _settingsView = new SettingsPage();

    public MainWindow() => InitializeComponent();

    protected override async void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);

        RenderTransformOrigin = new RelativePoint(0.5, 0.5, RelativeUnit.Relative);

        var transformGroup = new TransformGroup();
        var translate = new TranslateTransform(100, 0);
        var scale = new ScaleTransform(0.85, 0.85);
        transformGroup.Children.Add(translate);
        transformGroup.Children.Add(scale);
        RenderTransform = transformGroup;
        Opacity = 0;

        var fadeIn = new Animation
        {
            Duration = TimeSpan.FromSeconds(0.45),
            FillMode = FillMode.Forward,
            Children =
            {
                new KeyFrame { Cue = new Cue(0d), Setters = { new Setter(OpacityProperty, 0d) } },
                new KeyFrame { Cue = new Cue(1d), Setters = { new Setter(OpacityProperty, 1d) } }
            },
            Easing = new SineEaseOut()
        };

        var slideIn = new Animation
        {
            Duration = TimeSpan.FromSeconds(0.6),
            FillMode = FillMode.Forward,
            Children =
            {
                new KeyFrame { Cue = new Cue(0d), Setters = { new Setter(TranslateTransform.XProperty, 50d) } },
                new KeyFrame { Cue = new Cue(1d), Setters = { new Setter(TranslateTransform.XProperty, 0d) } }
            },
            Easing = new BackEaseOut()
        };

        var scaleIn = new Animation
        {
            Duration = TimeSpan.FromSeconds(0.6),
            FillMode = FillMode.Forward,
            Children =
            {
                new KeyFrame
                {
                    Cue = new Cue(0d),
                    Setters =
                    {
                        new Setter(ScaleTransform.ScaleXProperty, 0.85),
                        new Setter(ScaleTransform.ScaleYProperty, 0.85)
                    }
                },
                new KeyFrame
                {
                    Cue = new Cue(1d),
                    Setters =
                    {
                        new Setter(ScaleTransform.ScaleXProperty, 1d),
                        new Setter(ScaleTransform.ScaleYProperty, 1d)
                    }
                }
            },
            Easing = new BackEaseOut()
        };

        await Task.WhenAll(fadeIn.RunAsync(this), slideIn.RunAsync(this), scaleIn.RunAsync(this));

        Control.Content = _homeView;
    }

    private void OnNavigateClick(object? sender, RoutedEventArgs e)
    {
        Control.Content = (sender as RadioButton) switch
        {
            { Content: "Home" } => _homeView,
            { Content: "Settings" } => _settingsView,
            _ => null
        };
    }
}