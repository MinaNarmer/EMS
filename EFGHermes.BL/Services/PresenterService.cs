using AutoMapper;
using EFGHermes.BL.Dtos;
using EFGHermes.BL.Dtos.Base;
using EFGHermes.BL.IServices;
using EFGHermes.DAL.IRepositories;
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.BL.Services
{
    public class PresenterService : IPresenterService
    {
        #region Fields and Constructor

        public IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISectorRepository _sectorRepository;
        private readonly IPresenterRepository _presenterRepository;
        private readonly IPresenterSectorRepository _presenterSectorRepository;


        public PresenterService(IMapper mapper,
            IUnitOfWork unitOfWork, ISectorRepository sectorRepository,
            IPresenterRepository presenterRepository,
            IPresenterSectorRepository presenterSectorRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _sectorRepository = sectorRepository;
            _presenterRepository = presenterRepository;
            _presenterSectorRepository = presenterSectorRepository;
        }
        #endregion
        public void CreatePresenter(PresenterDto dto)
        {
            var model = _mapper.Map<Presenter>(dto);
            _presenterRepository.Add(model);
            _unitOfWork.SaveChanges();
        }

        public void CreateSectorWithTimeSlot(CreatePresenterSectorTimeSlot dto)
        {
            _presenterSectorRepository.Add(new PresenterSector
            {
                PresenterId = dto.PresenterId,
                SectorId = dto.SectorId,
                SlotDate = dto.HourFrom.Date,
                HourFrom = dto.HourFrom.TimeOfDay,
                HourTo = dto.HourTo.TimeOfDay,
            });
            _unitOfWork.SaveChanges();
        }

        public async Task<List<PresenterDto>> GetInvestorsAsync()
        {
            var presenter = await _presenterRepository.GetAll().ToListAsync();

            return _mapper.Map<List<PresenterDto>>(presenter);
        }

        public async Task<PresenterSectorDetailDto> GetInvestorSectorAsync(int presenterId)
        {
            var investor = _presenterRepository.GetById(presenterId);
            var sectors = await _presenterSectorRepository.GetAll()
                .Include(x => x.Sector)
                .Where(x => x.PresenterId == presenterId).ToListAsync();

            var model = new PresenterSectorDetailDto
            {
                Name = investor.Name,
                Sectors = sectors.Select(x => new SectorSlot
                {
                    Name = x.Sector.Name,
                    SlotDate = x.SlotDate.ToString("dddd, dd MMMM yyyy"),
                    From = x.HourFrom.ToString("dd\\:hh\\:mm"),
                    To = x.HourTo.ToString("dd\\:hh\\:mm")

                }).ToList()

            };
            return model;
        }

        public async Task<List<IdNameDto>> GetSectorssAsync()
        {
            var sectors = await _sectorRepository.GetAll().ToListAsync();
            return _mapper.Map<List<IdNameDto>>(sectors);
        }
    }
}
