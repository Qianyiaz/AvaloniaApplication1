using Avalonia.Controls;
using Avalonia.Metadata;
using Xaml.Behaviors.SourceGenerators;

[assembly: XmlnsDefinition("https://github.com/avaloniaui", "Avalonia.Controls")]
[assembly: GenerateEventCommand(typeof(Button), "Click", ParameterPath = "Source")]
[assembly: GenerateEventCommand(typeof(Control), "Loaded", ParameterPath = "Source")]