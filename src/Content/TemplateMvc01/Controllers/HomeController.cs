using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemplateMvc01.Models;

namespace TemplateMvc01.Controllers
{
    /// <summary>
    /// Home Controllwe
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        /// <summary>
        /// Index
        /// </summary>
        /// <returns>Home\Index</returns>
        public IActionResult Index()
        {
            var complexObject = new
            {
                FirstName = "Barney",
                LastName = "Rubble",
                Address = new
                {
                    Line1 = "Some House",
                    Town = "Some Town"
                }
            };
            
            
            _logger.LogInformation("Here's a complex object: {@ComplexObject}", complexObject);
            return View();
        }

        /// <summary>
        /// I'm not sure I've ever used this when I've left it in.
        /// </summary>
        /// <returns></returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
