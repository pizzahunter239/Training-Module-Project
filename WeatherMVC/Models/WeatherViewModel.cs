namespace WeatherMVC.Models
{
    public class WeatherViewModel
    {
        public string CityName { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public double Temperature { get; set; }
        public string Condition { get; set; }
        public string IconUrl { get; set; }
        public double Humidity { get; set; }
        public double FeelsLike { get; set; }
        public string ErrorMessage { get; set; }
    }
}