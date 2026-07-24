using CommunityToolkit.Mvvm.Messaging;

namespace AvaloniaApplication1.Services;

public record NavigateMessage(int PageId);

public interface INavigationService
{
    bool CanGoBack { get; }

    void Navigate(int pageId);

    void GoBack();
}

public class NavigationService(IMessenger messenger) : INavigationService
{
    private readonly Stack<int> _navigationStack = new();

    public bool CanGoBack => _navigationStack.Count > 1;

    public void Navigate(int pageId)
    {
        if (_navigationStack.Count > 0 && _navigationStack.Peek() == pageId)
            return;

        _navigationStack.Push(pageId);
        messenger.Send(new NavigateMessage(pageId));
    }

    public void GoBack()
    {
        if (!CanGoBack) return;

        _navigationStack.Pop();
        messenger.Send(new NavigateMessage(_navigationStack.Peek()));
    }
}