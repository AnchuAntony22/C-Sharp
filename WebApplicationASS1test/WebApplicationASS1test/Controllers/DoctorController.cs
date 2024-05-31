using Microsoft.AspNetCore.Mvc;
using WebApplicationASS1test.Models;

namespace WebApplicationASS1test.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult FeverCheck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FeverCheck(float temperature, string scale)
        {
            if (scale == "Fahrenheit")
            {
                temperature = ConvertToFahrenheit(temperature);
            }
            string diagnosis = Temperature.CheckTemperature(temperature);
            
            ViewBag.Diagnosis = diagnosis;
            return View();
        }
        private float ConvertToFahrenheit(float fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }
    }
}