using Microsoft.AspNetCore.Mvc;

namespace Triton.Sample.Web.Controllers
{
    public class ActorController : Controller
    {

        [Route("/Actor")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
