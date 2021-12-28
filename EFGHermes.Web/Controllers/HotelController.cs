using EFGHermes.BL.Dtos;
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

        [HttpGet]
        public IActionResult CreateRoom(int HotelId)
        {
            TempData["HotelId"] = HotelId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateRoom(CreateRoomDto dto)
        {
            dto.HotelId = (int)TempData["HotelId"];
            _hotelServices.CreateRoomWithTimeSlot(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> RoomSlotList(int hotelId)
        {
          var model = await _hotelServices.GetHotelRoomsSlotsAsync(hotelId);
            return View(model);
        }



    }
}
