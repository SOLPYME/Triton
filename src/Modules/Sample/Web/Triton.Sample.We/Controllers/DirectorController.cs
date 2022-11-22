using Microsoft.AspNetCore.Mvc;

namespace Triton.Sample.Web.Controllers
{
    public class DirectorController : Controller
    {

        [Route("/Director")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
