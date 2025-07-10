using FrontendChallenge.WeatherPage.Responses;
using static FrontendChallenge.WeatherPage.Responses.GeoCodingResponse;

namespace FrontendChallenge.WeatherPage.Services
{
    public class GeoCodingService
    {
        private readonly HttpClient _http;

        public GeoCodingService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Lugar>> BuscarAsync(string nombre)
        {
            var url = $"https://geocoding-api.open-meteo.com/v1/search?name={Uri.EscapeDataString(nombre)}&count=5&language=es&format=json";
            var resultado = await _http.GetFromJsonAsync<GeoCodingResponse>(url);

            return resultado?.Results ?? new();
        }
    }
}
