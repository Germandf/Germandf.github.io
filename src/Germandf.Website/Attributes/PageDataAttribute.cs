namespace Germandf.Website.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class PageDataAttribute : Attribute
{
    public string Title { get; } = "";
    public string Description { get; set; } = "";
    public bool IsFeatured { get; set; }

    public PageDataAttribute(string title, string description, bool isFeatured)
	{
		Title = title;
        Description = description;
        IsFeatured = isFeatured;
	}
}
