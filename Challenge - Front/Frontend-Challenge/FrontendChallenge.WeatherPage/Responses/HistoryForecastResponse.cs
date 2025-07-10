using System.Text.Json.Serialization;

namespace FrontendChallenge.WeatherPage.Responses
{
    public class HistoryForecastResponse
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }

        public DailyData? Daily { get; set; }

        public class DailyData
        {
            public List<string> Time { get; set; }
            public List<int> Weather_Code { get; set; }
            public List<double> Temperature_2m_Max { get; set; }
            public List<double> Temperature_2m_Min { get; set; }
            public List<double> Temperature_2m_mean { get; set; }
            public List<double> Precipitation_sum { get; set; }
        }
    }
}
