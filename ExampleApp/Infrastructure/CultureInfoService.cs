using System.Globalization;

namespace ExampleApp.Infrastructure;

public static class CultureInfoService
{
    public static string LANGUAGE_PREFERENCE = "language";

    public static event Action? CultureChanged;

    public static CultureInfo[] Cultures =
    [
        new CultureInfo("en-US"),
        new CultureInfo("es-ES"),
        new CultureInfo("sv-SE")
    ];

    public static CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                SetCultureInfo(value);
            }
        }
    }

    public static void SetCultureInfo(CultureInfo? cultureInfo)
    {
        if (cultureInfo is null)
        {
            string language = Preferences.Get(LANGUAGE_PREFERENCE, "en-US");
            if (string.IsNullOrWhiteSpace(language) is true)
            {
                cultureInfo = new CultureInfo("en-US");
            }
            else
            {
                cultureInfo = new CultureInfo(language);
            }
        }

        Thread.CurrentThread.CurrentCulture = cultureInfo;
        Thread.CurrentThread.CurrentUICulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        Preferences.Set(LANGUAGE_PREFERENCE, cultureInfo.Name);

        CultureChanged?.Invoke();
    }
}