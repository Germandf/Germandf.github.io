using Germandf.Website.Attributes;
using Germandf.Website.Data;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace Germandf.Website.Extensions;

public static class AssemblyExtensions
{
    public static List<PageDto> GetPages(this Assembly assembly)
    {
        var components = assembly
            .ExportedTypes
            .Where(t => t.IsSubclassOf(typeof(ComponentBase)));

        var routes = components
            .Select(component => GetRouteFromComponent(component));

        return routes.Where(route => route is not null).Cast<PageDto>().ToList();
    }

    private static PageDto? GetRouteFromComponent(Type component)
    {
        var attributes = component.GetCustomAttributes(inherit: true);
        var routeAttribute = attributes.OfType<RouteAttribute>().FirstOrDefault();
        var pageDataAttribute = attributes.OfType<PageDataAttribute>().FirstOrDefault();

        if (routeAttribute is null || string.IsNullOrWhiteSpace(routeAttribute.Template) || routeAttribute.Template.Contains('{'))
            return null;

        var pageDto = new PageDto() { Url = routeAttribute.Template };

        if (pageDataAttribute is null)
            return null;

        pageDto.Title = pageDataAttribute.Title;

        return pageDto;
    }
}
