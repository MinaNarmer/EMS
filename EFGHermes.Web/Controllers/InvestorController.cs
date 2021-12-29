using Microsoft.AspNetCore.Mvc;

namespace EFGHermes.Web.Controllers
{
    public class InvestorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
