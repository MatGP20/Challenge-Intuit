namespace FrontendChallenge.WeatherPage.Responses
{
    public class ForecasterResponse
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Timezone { get; set; }

        public CurrentUnit? Current_Units { get; set; }
        public CurrentWeather? Current { get; set; }
        public HourlyData? Hourly { get; set; }
        public DailyData? Daily { get; set; }
        public Minutely15Data? Minutely_15 { get; set; }

        public class CurrentUnit
        {
            public string Temperature_2m { get; set; }
            public string Apparent_Temperature { get; set; }
        }

        public class CurrentWeather
        {
            public double Temperature_2m { get; set; }
            public double Apparent_Temperature { get; set; }
            public int Is_Day { get; set; }
            public double Precipitation { get; set; }
            public double Relative_humidity_2m { get; set; }
            public int Weather_Code { get; set; }
            public double Cloud_Cover { get; set; }
        }

        public class HourlyData
        {
            public List<string> Time { get; set; }
            public List<double> Temperature_2m { get; set; }
            public List<double> Apparent_Temperature { get; set; }
            public List<double> Precipitation_Probability { get; set; }
            public List<double> Precipitation { get; set; }
            public List<double> Relative_humidity_2m { get; set; }
            public List<int> Weather_Code { get; set; }
        }

        public class DailyData
        {
            public List<string> Time { get; set; }
            public List<int> Weather_Code { get; set; }
            public List<double> Temperature_2m_Max { get; set; }
            public List<double> Temperature_2m_Min { get; set; }
        }

        public class Minutely15Data
        {
            public List<string> Time { get; set; }
            public List<double> Temperature_2m { get; set; }
            public List<double> Apparent_Temperature { get; set; }
            public List<int> Weather_Code { get; set; }
            public List<double> Precipitation { get; set; }
            public List<double> Relative_humidity_2m { get; set; }
            public List<int> Is_Day { get; set; }
        }
    }
}
