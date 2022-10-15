namespace Germandf.Website.Data;

public class PageDto
{
    public string Url { get; set; } = "";
    public string Title { get; set; } = "";

    public override string ToString()
    {
        return Title;
    }
}
