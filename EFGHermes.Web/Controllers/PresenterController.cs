using EFGHermes.BL.Dtos;
using EFGHermes.BL.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace EFGHermes.Web.Controllers
{
    public class PresenterController : Controller
    {
        private readonly IPresenterService _presenterServices;

        public PresenterController(IPresenterService investorServices)
        {
            _presenterServices = investorServices;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _presenterServices.GetInvestorsAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PresenterDto dto)
        {
            _presenterServices.CreatePresenter(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateSectorWithTimeSlot(int presenterId)
        {
            var sectors = await _presenterServices.GetSectorssAsync();
            ViewBag.Sectors = new SelectList(sectors, "Id", "Name");
            TempData["PresenterId"] = presenterId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateSectorWithTimeSlot(CreatePresenterSectorTimeSlot dto)
        {
            dto.PresenterId = (int)TempData["PresenterId"];
            _presenterServices.CreateSectorWithTimeSlot(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SectorSlotList(int presenterId)
        {
            var model = await _presenterServices.GetInvestorSectorAsync(presenterId);
            return View(model);
        }
    }
}
