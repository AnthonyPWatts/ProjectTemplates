using Microsoft.AspNetCore.Mvc;

namespace TemplateMvc01.Controllers
{
    [ApiController]
    [Route("MyApi")]
    public class MyApiController : ControllerBase
    {
        [HttpGet]
        [Route("Example")]
        public IActionResult Example()
        {
            return Ok("Unexciting");
        }
    }
}