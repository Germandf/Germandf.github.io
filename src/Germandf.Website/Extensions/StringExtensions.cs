using Germandf.Website.Data;
using System.Globalization;

namespace Germandf.Website.Extensions;

public static class StringExtensions
{
    public static List<BreadcrumbDto> GetBreadcrumbsFromRoute(this string route)
    {
        route = route.Split("?")[0];
        var breadcrumbs = route.Split("/").ToList();
        var breadcrumbDtos = new List<BreadcrumbDto>();

        for (var i = 0; i < breadcrumbs.Count; i++)
        {
            if (string.IsNullOrWhiteSpace(breadcrumbs[i]))
                continue;

            var breadcrumbRoute = route;

            for (var j = i + 1; j < breadcrumbs.Count; j++)
            {
                if (breadcrumbs[j].Length == 0)
                    continue;

                breadcrumbRoute = breadcrumbRoute.Replace(breadcrumbs[j], "");
                breadcrumbRoute = breadcrumbRoute.Replace("//", "/");

                if (j == breadcrumbs.Count - 1)
                    breadcrumbRoute = breadcrumbRoute.Remove(breadcrumbRoute.Length - 1, 1);
            }

            breadcrumbDtos.Add(new()
            {
                Url = breadcrumbRoute,
                Title = breadcrumbs[i].Replace("-", " ").ToUpperFirstLetterEveryWord()
            });
        }

        return breadcrumbDtos;
    }

    public static string ToUpperFirstLetterEveryWord(this string src) =>
        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(src.ToLower());
}
