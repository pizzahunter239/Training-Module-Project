using Microsoft.AspNetCore.Mvc;
using WeatherMVC.Models;
using System.Text.Json;

namespace WeatherMVC.Controllers
{
    public class HomeController : Controller
    {
        // *** REMOVE FOR STUDENT VERSION - START ***
        // Students will add this during the lab
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public HomeController(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        // *** REMOVE FOR STUDENT VERSION - END ***

        // Initial page load - shows empty form
        [HttpGet]
        public IActionResult Index()
        {
            return View(new WeatherViewModel());
        }

        // *** TEACH SEPARATELY - This is the main API integration method ***
        // *** REMOVE FOR STUDENT VERSION - START ***
        [HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            var viewModel = new WeatherViewModel();

            // Validate input
            if (string.IsNullOrWhiteSpace(city))
            {
                viewModel.ErrorMessage = "Please enter a city name.";
                return View(viewModel);
            }

            try
            {
                // Get API key from configuration
                // Explain appsettings.json here
                var apiKey = _configuration["WeatherApi:ApiKey"];

                // Build the API URL
                var url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

                // Make the HTTP request
                // Explain async/await here
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    // Read the JSON response
                    var json = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON to our model
                    // Explain JSON deserialization here
                    var weatherData = JsonSerializer.Deserialize<WeatherResponse>(json,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    // Map to ViewModel
                    // Explain why we use ViewModels
                    viewModel.CityName = weatherData.Location.Name;
                    viewModel.Region = weatherData.Location.Region;
                    viewModel.Country = weatherData.Location.Country;
                    viewModel.Temperature = weatherData.Current.Temp_f;
                    viewModel.Condition = weatherData.Current.Condition.Text;
                    viewModel.IconUrl = "https:" + weatherData.Current.Condition.Icon;
                    viewModel.Humidity = weatherData.Current.Humidity;
                    viewModel.FeelsLike = weatherData.Current.Feelslike_f;
                }
                else
                {
                    viewModel.ErrorMessage = "City not found. Please try again.";
                }
            }
            catch (Exception ex)
            {
                viewModel.ErrorMessage = "An error occurred while fetching weather data.";
                // Log the exception in a real application
            }

            return View(viewModel);
        }
        // *** REMOVE FOR STUDENT VERSION - END ***
    }
}