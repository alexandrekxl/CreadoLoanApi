using Microsoft.AspNetCore.Mvc;

namespace Credo.Api.Controllers
{
    public class ErrorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
