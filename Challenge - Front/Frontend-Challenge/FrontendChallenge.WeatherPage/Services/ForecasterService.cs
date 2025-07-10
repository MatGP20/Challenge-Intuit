using FrontendChallenge.WeatherPage.Responses;

namespace FrontendChallenge.WeatherPage.Services
{
    public class ForecasterService
    {
        private readonly HttpClient _http;

        public ForecasterService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ForecasterResponse?> GetForecastAsync(double latitude, double longitude)
        {
            var url = $"https://api.open-meteo.com/v1/forecast" +
                      $"?latitude={latitude}&longitude={longitude}" +
                      $"&daily=weather_code,temperature_2m_max,temperature_2m_min" +
                      $"&hourly=temperature_2m,apparent_temperature,precipitation_probability,precipitation,weather_code,relative_humidity_2m" +
                      $"&current=temperature_2m,apparent_temperature,is_day,precipitation,weather_code,cloud_cover,relative_humidity_2m" +
                      $"&minutely_15=temperature_2m,apparent_temperature,weather_code,precipitation,is_day,relative_humidity_2m" +
                      $"&forecast_minutely_15=24&past_minutely_15=24&timezone=auto&forecast_days=6";

            return await _http.GetFromJsonAsync<ForecasterResponse>(url);
        }
    }
}
