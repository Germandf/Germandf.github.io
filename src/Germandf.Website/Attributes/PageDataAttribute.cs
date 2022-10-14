namespace Germandf.Website.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class PageDataAttribute : Attribute
{
    public string Title { get; } = "";

	public PageDataAttribute(string title)
	{
		Title = title;
	}
}
