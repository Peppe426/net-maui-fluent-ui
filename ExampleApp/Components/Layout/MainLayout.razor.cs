using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using ExampleApp.Infrastructure;

namespace ExampleApp.Components.Layout;

public partial class MainLayout : IDisposable
{
    private const string JAVASCRIPT_FILE = "./_content/ExampleApp.Components/Layout/MainLayout.razor.js";
    public const string MESSAGES_NOTIFICATION_CENTER = "NOTIFICATION_CENTER";
    public const string MESSAGES_TOP = "TOP";
    public const string MESSAGES_DIALOG = "DIALOG";
    public const string MESSAGES_CARD = "CARD";
    private string? _version;
    private bool _mobile;
    private string? _prevUri;
    private bool _menuChecked = true;
    private bool showMenu = true;
    public static event Action<string>? TitleChanged;

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    protected override void OnInitialized()
    {
        _version = AppVersionService.GetVersionFromAssembly();

        _prevUri = NavigationManager.Uri;
        NavigationManager.LocationChanged += LocationChanged;
    }

    private void LocationChanged(object? sender, LocationChangedEventArgs e)
    {
        if (!e.IsNavigationIntercepted && new Uri(_prevUri!).AbsolutePath != new Uri(e.Location).AbsolutePath)
        {
            _prevUri = e.Location;
            if (_mobile && _menuChecked == true)
            {
                _menuChecked = false;
                StateHasChanged();
            }
        }              
    }
    public static void ChangeTitle(string newTitle)
    {
        TitleChanged?.Invoke(newTitle);
    }

    public void Dispose()
    {
        NavigationManager.LocationChanged -= LocationChanged;
    }
}