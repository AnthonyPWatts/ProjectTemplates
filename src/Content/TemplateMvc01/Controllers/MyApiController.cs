using Microsoft.AspNetCore.Mvc;

namespace TemplateMvc01.Controllers
{
    /// <summary>
    /// Example API Controller
    /// </summary>
    [ApiController]
    [Route("MyApi")]
    public class MyApiController : ControllerBase
    {
        /// <summary>
        /// Example
        /// </summary>
        /// <returns>Unexciting</returns>
        [HttpGet]
        [Route("Example")]
        public IActionResult Example()
        {
            return Ok("Unexciting");
        }
    }
}