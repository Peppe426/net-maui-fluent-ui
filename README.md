# net-maui-fluent-ui

.NET Maui boilerplate with Fluent UI, with language and theme support.

## Overview

This sample app shows how to use Fluent UI with .NET MAUI to create a modern, consistent UI across different platforms. It uses Fluent UI components for good-looking, interactive user interfaces. Plus, the app supports multiple languages, making it usable for people around the world. Here’s a quick look at what’s inside:

### MauiProgram.cs

MauiProgram.cs is the core of the .NET MAUI app. It sets up the app's configuration, including Fluent UI components, fonts, and service registrations. It also adds developer tools and logging for debugging when needed. This file is key to initializing the app with the right settings and dependencies.

### SiteSettingsPanel.razor.cs

SiteSettingsPanel.razor.cs manages site settings like theme mode, language, and other preferences. It shows how the app can change settings on the fly. Using Fluent UI components and services like CultureInfoService, it makes switching languages and themes easy for users.

### NavMenu.razor.cs

NavMenu.razor.cs sets up the navigation menu using Fluent UI icons and components. It organizes navigation links and groups, creating a responsive and user-friendly navigation bar.

### NavMenuItem.razor.cs

This file defines NavItem, NavLink, and NavGroup, which build the navigation menu in NavMenu.razor.cs. It provides the structure for a flexible and dynamic navigation system.

### MainLayout.razor.cs

MainLayout.razor.cs is the main layout component. It includes the navigation menu and a container for displaying main content. It can dynamically update the page title and manage navigation events, ensuring a smooth user experience.

### Platforms/MacCatalyst/AppDelegate.cs and Program.cs

These files are for the Mac Catalyst platform, showing how to configure .NET MAUI apps to run on macOS. AppDelegate.cs and Program.cs are entry points for the Mac Catalyst app, connecting the .NET MAUI setup with the native macOS app lifecycle.

Overall, this sample app demonstrates the flexibility and power of .NET MAUI with Fluent UI, giving developers a solid framework for building cross-platform apps with rich UI components and multi-language support.

## Themes

Customizing the Fluent UI theme in a .NET MAUI app involves tweaking the UI’s colors, typography, and component styles to match your brand or design needs. Here’s a basic guide on how to do it:

### 1. Define Your Theme

Start by defining the colors, fonts, and other design tokens that represent your theme. Fluent UI’s theming system lets you centralize these values.

### 2. Create a Custom Theme

Make a custom theme by extending the default theme and overriding the properties you want to change. Create a new theme object and set your custom values. For example, in a web context (Blazor):

```csharp
var myCustomTheme = new FluentUITheme
{
    Palette = new Palette
    {
        ThemePrimary = "#0078d4",
        ThemeLighterAlt = "#f3f9fd",
        ThemeLighter = "#d0e7f8",
        // Add other color overrides here
    },
    Typography = new Typography
    {
        BaseFontSize = "14px",
        // Define other typography settings here
    },
    // Define other theme settings here
};
```

### 3. Apply the Custom Theme

After defining your custom theme, apply it to your app. This step depends on your app's structure and where you’re using Fluent UI components. In a Blazor app, apply the theme using a ThemeProvider component at the root of your app:

```xml
<ThemeProvider Theme="@myCustomTheme">
    <!-- Your application components go here -->
</ThemeProvider>
```