using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
