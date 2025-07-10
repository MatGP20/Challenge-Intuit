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
            var resultado = await _http.GetFromJsonAsync<GeocodingResponse>(url);

            return resultado?.Results ?? new();
        }

        public class GeocodingResponse
        {
            public List<Lugar> Results { get; set; } = new();
        }

        public class Lugar
        {
            public string Name { get; set; }
            public string Country { get; set; }
            public string Admin1 { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Timezone { get; set; }

            public string Display => $"{Name}, {Country}";
        }
    }
}
