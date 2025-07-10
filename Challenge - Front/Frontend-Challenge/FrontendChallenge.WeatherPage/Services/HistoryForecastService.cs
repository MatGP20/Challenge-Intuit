using FrontendChallenge.WeatherPage.Responses;

namespace FrontendChallenge.WeatherPage.Services
{
    public class HistoryForecastService
    {
        private readonly HttpClient _http;

        public HistoryForecastService(HttpClient http)
        {
            _http = http;
        }

        public async Task<HistoryForecastResponse?> ObtenerHistoricoAsync(double latitude, double longitude, DateOnly start, DateOnly end)
        {
            var url = $"https://historical-forecast-api.open-meteo.com/v1/forecast" +
                      $"?latitude={latitude}" +
                      $"&longitude={longitude}" +
                      $"&start_date={start:yyyy-MM-dd}" +
                      $"&end_date={end:yyyy-MM-dd}" +
                      $"&daily=weather_code,temperature_2m_max,temperature_2m_min,temperature_2m_mean,precipitation_sum" +
                      $"&timezone=auto";

            return await _http.GetFromJsonAsync<HistoryForecastResponse>(url);
        }
    }
}
