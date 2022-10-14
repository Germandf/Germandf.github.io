namespace Germandf.Website.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class TitleAttribute : Attribute
{
    public string Title { get; } = "";

	public TitleAttribute(string title)
	{
		Title = title;
	}
}
