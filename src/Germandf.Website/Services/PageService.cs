using Germandf.Website.Data;
using Germandf.Website.Extensions;

namespace Germandf.Website.Services;

public interface IPageService
{
    public List<PageDto> GetPages();
}

public class PageService : IPageService
{
    private readonly List<PageDto> _pages = new();

    public PageService()
    {
        var pages = typeof(App).Assembly.GetPages();

        foreach (var page in pages)
            _pages.Add(page);
    }

    public List<PageDto> GetPages() => _pages;
}