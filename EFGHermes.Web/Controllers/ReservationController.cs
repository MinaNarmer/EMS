using Microsoft.AspNetCore.Mvc;

namespace EFGHermes.Web.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
