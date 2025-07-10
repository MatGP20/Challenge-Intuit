using FrontendChallenge.WeatherPage.Helpers;
using FrontendChallenge.WeatherPage.Responses;
using FrontendChallenge.WeatherPage.Services;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using static FrontendChallenge.WeatherPage.Responses.GeoCodingResponse;

namespace FrontendChallenge.WeatherPage.Components.Pages
{
    public partial class Forecast
    {
        [Inject] private GeoCodingService GeoService { get; set; }
        [Inject] private ForecasterService ForecastService { get; set; }
        [Inject] private HistoryForecastService HistoryService { get; set; }
        [Inject] private INotificationLoading NotificationLoading { get; set; }

        private string busqueda = string.Empty;
        private DateOnly startDayValue = DateOnly.FromDateTime(DateTime.Now.AddDays(-15));
        private DateOnly finishDayValue = DateOnly.FromDateTime(DateTime.Now);
        private string maxDaysPicker = DateOnly.FromDateTime(DateTime.Today).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        private List<Lugar> sugerencias = new();
        private Lugar lugarSeleccionado;
        private ForecasterResponse forecast;
        private HistoryForecastResponse historyForecast;
        private string weatherCodeString;
        private string searchHistoryMessage = string.Empty;

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

        private async Task SeleccionarLugar(Lugar lugar)
        {
            NotificationLoading.ShowModal();
            lugarSeleccionado = lugar;
            sugerencias.Clear();
            busqueda = string.Empty;
            forecast = await ForecastService.GetForecastAsync(lugarSeleccionado.Latitude, lugarSeleccionado.Longitude);
            weatherCodeString = WeatherCodeHelper.ObtenerDescripcion(forecast.Current.Weather_Code);
            
            if (startDayValue < finishDayValue)
                historyForecast = await HistoryService.ObtenerHistoricoAsync(forecast.Latitude, forecast.Longitude, startDayValue, finishDayValue);
            
            await InvokeAsync(StateHasChanged);
            NotificationLoading.CloseModal();
        }

        private async Task SearchHistoryForecast()
        {
            NotificationLoading.ShowModal();
            if(startDayValue < finishDayValue)
            {
                historyForecast = await HistoryService.ObtenerHistoricoAsync(forecast.Latitude, forecast.Longitude, startDayValue, finishDayValue);
            }
            else
            {
                searchHistoryMessage = "Por favor verifica que la fechas de la búsqueda";
            }
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

        private string ObtenerMesAbreviado(int mes) => mes switch
        {
            1 => "Ene",
            2 => "Feb",
            3 => "Mar",
            4 => "Abr",
            5 => "May",
            6 => "Jun",
            7 => "Jul",
            8 => "Ago",
            9 => "Sep",
            10 => "Oct",
            11 => "Nov",
            12 => "Dic",
            _ => ""
        };
    }
}
