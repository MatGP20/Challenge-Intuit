namespace FrontendChallenge.WeatherPage.Responses
{
    public class GeoCodingResponse
    {
        public List<Lugar> Results { get; set; } = new();
       
        public class Lugar
        {
            public string Name { get; set; }
            public string Country { get; set; }
            public string Admin1 { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Timezone { get; set; }

            public string Display => $"{Name}, {Admin1}, {Country}";
        }
    }
}
