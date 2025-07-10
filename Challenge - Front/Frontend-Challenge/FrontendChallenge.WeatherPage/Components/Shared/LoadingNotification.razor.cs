using FrontendChallenge.WeatherPage.Services;
using Microsoft.AspNetCore.Components;

namespace FrontendChallenge.WeatherPage.Components.Shared
{
    public partial class LoadingNotification : IDisposable
    {
        [Inject] INotificationLoading notificationLoading { get; set; }

        private bool IsVisible { get; set; } = false;
        private string modalDisplay = "none";
        private bool showBackdrop = false;

        protected override async Task OnInitializedAsync()
        {
            notificationLoading.OnShow += ShowModal;
            notificationLoading.OnClose += HideModal;

            await base.OnInitializedAsync();
        }

        public async void ShowModal()
        {            
            IsVisible = true;
            modalDisplay = "block";
            showBackdrop = true;
            await InvokeAsync(StateHasChanged);
        }

        private async void HideModal()
        {
            IsVisible = false;
            modalDisplay = "none";
            showBackdrop = false;
            await InvokeAsync(StateHasChanged);
        }     

        public void Dispose()
        {
            notificationLoading.OnShow -= ShowModal;
            notificationLoading.OnClose -= HideModal;
        }
    }
}
