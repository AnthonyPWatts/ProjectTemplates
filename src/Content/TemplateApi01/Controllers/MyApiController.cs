using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TemplateApi01.Controllers
{
    /// <summary>
    /// Example API Controller
    /// </summary>
    [ApiController]
    [Route("MyApi")]
    public class MyApiController : ControllerBase
    {
        private readonly ILogger<MyApiController> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">ILogger Dependency</param>
        public MyApiController(ILogger<MyApiController> logger)
        {
            _logger = logger;
        }
        
        
        /// <summary>
        /// An uninteresting endpoint which does some logging
        /// </summary>
        /// <returns>Uninteresting</returns>
        [HttpGet]
        [Route("Example")]
        public IActionResult Example()
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
            
            return Ok("Uninteresting");
        }
    }
}