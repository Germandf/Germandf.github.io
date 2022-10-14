using FluentAssertions;
using Germandf.Website.Extensions;
using Xunit;

namespace Germandf.Website.Tests.Unit.Extensions;

public class StringExtensionsTests
{
    [Fact]
    public void GetBreadcrumbsFromRoute_ShouldAvoidQueryParams_WhenThereAreQueryParams()
    {
        var route = "/one/two?three";

        var breadcrumbs = route.GetBreadcrumbsFromRoute();

        breadcrumbs.Should().HaveCount(2);
    }

    [Fact]
    public void GetBreadcrumbsFromRoute_ShouldReturnBreadcrumbs_WhenCurrentRouteIsNotIndex()
    {
        var route = "/one/two";

        var breadcrumbs = route.GetBreadcrumbsFromRoute();

        breadcrumbs.Should().HaveCount(2);
    }

    [Fact]
    public void GetBreadcrumbsFromRoute_ShouldReturnEmptyList_WhenCurrentRouteIsIndex()
    {
        var route = "/";

        var breadcrumbs = route.GetBreadcrumbsFromRoute();

        breadcrumbs.Should().BeEmpty();
    }
}
