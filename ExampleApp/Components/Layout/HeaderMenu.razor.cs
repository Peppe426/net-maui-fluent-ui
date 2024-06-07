using ExampleApp.Components.Panels;
using ExampleApp.Resources.Languages;
using Microsoft.FluentUI.AspNetCore.Components;
using HorizontalAlignment = Microsoft.FluentUI.AspNetCore.Components.HorizontalAlignment;

namespace ExampleApp.Components.Layout
{
    public partial class HeaderMenu : IDisposable
    {
        public string Title { get; set; } = AppResource.Home;

        private IDialogReference? _dialog;

        protected override void OnInitialized()
        {
            base.OnInitialized();
            MainLayout.TitleChanged += OnTitleChanged;
        }

        private async Task OpenSiteSettingsAsync()
        {
            _dialog = await DialogService.ShowPanelAsync<SiteSettingsPanel>(new DialogParameters()
            {
                ShowTitle = true,
                Title = AppResource.SiteSettings,
                Alignment = HorizontalAlignment.Right,
                PrimaryAction = "OK",
                SecondaryAction = null,
                ShowDismiss = true
            });

            DialogResult result = await _dialog.Result;
        }

        private void OnTitleChanged(string newTitle)
        {
            Title = newTitle;
            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            MainLayout.TitleChanged -= OnTitleChanged;
        }
    }
}