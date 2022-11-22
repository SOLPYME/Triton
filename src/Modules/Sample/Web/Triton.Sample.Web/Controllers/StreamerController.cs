using Microsoft.AspNetCore.Mvc;

namespace Triton.Sample.Web.Controllers
{
    public class StreamerController : Controller
    {

        [Route("/Streamer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
