//STUDENTS WILL MAKE THIS FILE

namespace WeatherMVC.Models
{
    // Root response object
    public class WeatherResponse
    {
        public Location Location { get; set; }
        public Current Current { get; set; }
    }

    public class Location
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
    }

    public class Current
    {
        public double Temp_c { get; set; }
        public double Temp_f { get; set; }
        public Condition Condition { get; set; }
        public double Humidity { get; set; }
        public double Feelslike_f { get; set; }
    }

    public class Condition
    {
        public string Text { get; set; }
        public string Icon { get; set; }
    }
}