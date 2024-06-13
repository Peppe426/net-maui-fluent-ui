using ExampleApp.Components.Shared;
using ExampleApp.Resources.Languages;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.FluentUI.AspNetCore.Components;
using NavLink = ExampleApp.Components.Shared.NavLink;

namespace ExampleApp.Components.Layout;

public partial class NavMenu
{
    public IReadOnlyList<NavItem> NavMenuItems { get; private set; } = [];

    public NavMenu()
    {
        InitNavMenu();
    }

    public NavMenu InitNavMenu()
    {
        NavMenuItems =
        [
            new NavLink(
                href: "/",
                match: NavLinkMatch.All,
                icon: new Icons.Regular.Size24.Home(),
                title: AppResource.Home
            ),

            new NavGroup(
                icon: new Icons.Regular.Size24.Rocket(),
                title: AppResource.ExpandedMenuGroup,
                expanded: true,
                gap: "10px",
                children:
                [
                    new NavLink(
                        href: "/counter",
                        icon: new Icons.Regular.Size24.Calculator(),
                        title: AppResource.Counter
                    ),

                    new NavLink(
                        href: "/weather",
                        icon: new Icons.Regular.Size24.Cloud(),
                        title: AppResource.Weather
                    ),

                    new NavGroup(
                        icon: new Icons.Regular.Size24.SettingsCogMultiple(),
                        title: AppResource.FoldedMenuGroup,
                        expanded: false,
                        gap: "10px",
                        children:
                        [
                            new NavLink(
                            href: "/counter",
                            icon: new Icons.Regular.Size24.Calculator(),
                            title: AppResource.Counter
                            ),

                            new NavLink(
                                href: "/weather",
                                icon: new Icons.Regular.Size24.Cloud(),
                                title: AppResource.Weather
                            ),
                        ]
                    )
                ]
            )
        ];

        return this;
    }
}