using Microsoft.AspNetCore.Mvc;


namespace EFGHermes.Web.Controllers
{
    public class PresenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
