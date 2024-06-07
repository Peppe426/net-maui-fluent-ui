using ExampleApp.Infrastructure;
using ExampleApp.Resources.Languages;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.FluentUI.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ExampleApp.Components.Panels
{
    public partial class SiteSettingsPanel : IDisposable
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
            CultureInfoService.CultureChanged += OnCultureChanged;
        }

        private FluentDesignTheme? _theme;
        public DesignThemeModes ThemeMode { get; set; }
        private static IEnumerable<DesignThemeModes> DesignThemeModes => Enum.GetValues<DesignThemeModes>();

        private string _language = CultureInfoService.Culture.TwoLetterISOLanguageName;

        public string Language
        {
            get => _language;
            set
            {
                if (_language != value)
                {
                    _language = value;
                    LanguageChanged(_language);
                }
            }
        }

        private static IEnumerable<string> Languages => CultureInfoService.Cultures.Select(c => c.TwoLetterISOLanguageName);

        public OfficeColor? OfficeColor { get; set; }
        public LocalizationDirection? Direction { get; set; }

        private static string? GetCustomColor(OfficeColor? color)
        {
            return color switch
            {
                null => OfficeColorUtilities.GetRandom(true).ToAttributeValue(),
                Microsoft.FluentUI.AspNetCore.Components.OfficeColor.Default => "#036ac4",
                _ => color.ToAttributeValue(),
            };
        }

        private static string GetFlag(string language)
        {
            try
            {
                var resourceManager = new ResourceManager(typeof(AppResource));
                byte[] outputBytes = (byte[])resourceManager.GetObject("flag", new CultureInfo(language));

                if (outputBytes == null)
                {
                    throw new InvalidOperationException("Flag not found for language: " + language);
                }

                string output = Encoding.UTF8.GetString(outputBytes);

                return Convert.ToBase64String(outputBytes);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error getting flag for language: " + language, ex);
            }
        }

        private void LanguageChanged(string newLanguage)
        {
            CultureInfoService.SetCultureInfo(new CultureInfo(newLanguage));
        }

        private void LanguageChanged(ChangeEventArgs e)
        {
            Language = e.Value.ToString();
        }

        private async Task ResetSiteAsync()
        {
            _theme?.ClearLocalStorageAsync();
            OfficeColor = OfficeColorUtilities.GetRandom();
            ThemeMode = Microsoft.FluentUI.AspNetCore.Components.DesignThemeModes.System;
        }

        private async void OnCultureChanged()
        {
            try
            {
                await InvokeAsync(StateHasChanged);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Dispose()
        {
            CultureInfoService.CultureChanged -= OnCultureChanged;
        }
    }
}