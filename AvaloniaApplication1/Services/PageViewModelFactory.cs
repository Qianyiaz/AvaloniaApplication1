namespace AvaloniaApplication1.Services;

public interface IPageViewModelFactory
{
    object Create(int pageId);
}

public class PageViewModelFactory(Func<int, object> factory) : IPageViewModelFactory
{
    public object Create(int pageId) => factory(pageId);
}