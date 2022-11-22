using Microsoft.AspNetCore.Mvc;

namespace Triton.Sample.Web.Controllers
{
    public class VideoController : Controller
    {

        [Route("/Video")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
