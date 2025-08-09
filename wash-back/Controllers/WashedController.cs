using Microsoft.AspNetCore.Mvc;

namespace wash_back.Controllers
{
    public class WashedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
