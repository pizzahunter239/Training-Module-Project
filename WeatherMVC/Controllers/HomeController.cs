using Microsoft.AspNetCore.Mvc;
using WeatherMVC.Models;
using System.Text.Json;

namespace WeatherMVC.Controllers
{
    public class HomeController : Controller
    {
        // *** 
       
        // *** 

        // Initial page load - shows empty form
        [HttpGet]
        public IActionResult Index()
        {
            return View(new WeatherViewModel());
        }

        // *** 
        
        // *** 
    }
}