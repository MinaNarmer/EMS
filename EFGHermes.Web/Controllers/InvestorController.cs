using EFGHermes.BL.Dtos;
using EFGHermes.BL.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace EFGHermes.Web.Controllers
{
    public class InvestorController : Controller
    {
        private readonly IInvestorService _investorServices;

        public InvestorController(IInvestorService investorServices)
        {
            _investorServices = investorServices;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _investorServices.GetInvestorsAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InvestorDto dto)
        {
            _investorServices.CreateInvestor(dto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateSectorWithTimeSlot(int investorId)
        {
            var sectors = await _investorServices.GetSectorssAsync();
            ViewBag.Sectors = new SelectList(sectors, "Id", "Name");
            TempData["InvestorId"] = investorId;
            return View();
        }

        [HttpPost]
        public IActionResult CreateSectorWithTimeSlot(CreateInvestorSectorTimeSlot dto)
        {
            dto.InvestorId = (int)TempData["InvestorId"];
            _investorServices.CreateSectorWithTimeSlot(dto);
            return RedirectToAction("Index");
        }


    }
}
