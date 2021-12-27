using EFGHermes.BL.Dtos.Base;
using EFGHermes.BL.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EFGHermes.Web.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelServices _hotelServices;

        public HotelController(IHotelServices hotelServices)
        {
            _hotelServices = hotelServices;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _hotelServices.GetHotelsAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IdNameDto dto)
        {
            _hotelServices.CreateHotel(dto);
            return RedirectToAction("Index");
        }
    }
}
