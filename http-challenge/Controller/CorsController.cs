using Microsoft.AspNetCore.Mvc;

namespace http_challenge
{
    public class CorsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return Ok();

        }
    }
}