using FrontendChallenge.WeatherPage.Helpers;
using FrontendChallenge.WeatherPage.Responses;
using FrontendChallenge.WeatherPage.Services;
using Microsoft.AspNetCore.Components;

namespace FrontendChallenge.WeatherPage.Components.Pages
{
    public partial class Forecast
    {
        [Inject] private GeoCodingService GeoService { get; set; }
        [Inject] private ForecasterService ForecastService { get; set; }
        [Inject] private INotificationLoading NotificationLoading { get; set; }

        private string busqueda = string.Empty;
        private List<GeoCodingService.Lugar> sugerencias = new();
        private GeoCodingService.Lugar lugarSeleccionado;
        private ForecasterResponse forecast;
        private string weatherCodeString;
        private List<string> diasAbreviados = ["Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"];

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var defaultPlace = "Córdoba, Argentina";
            var sugested = await GeoService.BuscarAsync(defaultPlace);
            await SeleccionarLugar(sugested.FirstOrDefault());
        }

        private async Task BuscarAsync()
        {
            if (busqueda.Length >= 3)
                sugerencias = await GeoService.BuscarAsync(busqueda);
            else
                sugerencias.Clear();

            await InvokeAsync(StateHasChanged);
        }

        private async Task ChangeSearch(ChangeEventArgs e)
        {
            busqueda = string.IsNullOrWhiteSpace(e.Value.ToString()) ? "" : e.Value.ToString();
            await BuscarAsync();
        }

        private async Task SeleccionarLugar(GeoCodingService.Lugar lugar)
        {
            NotificationLoading.ShowModal();
            lugarSeleccionado = lugar;
            sugerencias.Clear();
            busqueda = string.Empty;
            forecast = await ForecastService.GetForecastAsync(lugarSeleccionado.Latitude, lugarSeleccionado.Longitude);
            weatherCodeString = WeatherCodeHelper.ObtenerDescripcion(forecast.Current.Weather_Code);
            await InvokeAsync(StateHasChanged);
            NotificationLoading.CloseModal();
        }

        private string ObtenerDiaAbreviado(DateOnly fecha)
        {
            return fecha.DayOfWeek switch
            {
                DayOfWeek.Monday => "Lun",
                DayOfWeek.Tuesday => "Mar",
                DayOfWeek.Wednesday => "Mié",
                DayOfWeek.Thursday => "Jue",
                DayOfWeek.Friday => "Vie",
                DayOfWeek.Saturday => "Sáb",
                DayOfWeek.Sunday => "Dom",
                _ => ""
            };
        }
    }
}
