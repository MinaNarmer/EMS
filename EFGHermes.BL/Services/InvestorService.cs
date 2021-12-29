
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
    public class InvestorService : IInvestorService
    {
        #region Fields and Constructor

        public IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvestorRepository _investorRepository;
        private readonly IInvestorSectorRepository _investorSectorRepository;
        private readonly ISectorRepository _sectorRepository;

        public InvestorService(IMapper mapper, IUnitOfWork unitOfWork,
            IInvestorRepository investorRepository,
            IInvestorSectorRepository investorSectorRepository,
            ISectorRepository sectorRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _investorRepository = investorRepository;
            _investorSectorRepository = investorSectorRepository;
            _sectorRepository = sectorRepository;
        }
        #endregion

        public void CreateInvestor(InvestorDto dto)
        {
            var model = _mapper.Map<Investor>(dto);
            _investorRepository.Add(model);
            _unitOfWork.SaveChanges();
        }

        public async Task<List<InvestorDto>> GetInvestorsAsync()
        {
            var sectors = await _investorRepository.GetAll().ToListAsync();

            return _mapper.Map<List<InvestorDto>>(sectors);
        }

        public async Task<List<IdNameDto>> GetSectorssAsync()
        {
            var sectors = await _sectorRepository.GetAll().ToListAsync();

            return _mapper.Map<List<IdNameDto>>(sectors);
        }
        public void CreateSectorWithTimeSlot(CreateInvestorSectorTimeSlot dto)
        {
            _investorSectorRepository.Add(new InvestorSector
            {
                InvestorId = dto.InvestorId,
                SectorId = dto.SectorId,
                SlotDate = dto.HourFrom.Date,
                HourFrom = dto.HourFrom.TimeOfDay,
                HourTo = dto.HourTo.TimeOfDay,
            });
            _unitOfWork.SaveChanges();

        }

        public async Task<InvestorSectorDetailDto> GetInvestorSectorAsync(int investorId)
        {
            var investor = _investorRepository.GetById(investorId);
            var sectors = await _investorSectorRepository.GetAll()
                .Include(x=> x.Sector)
                .Where(x => x.InvestorId == investorId).ToListAsync();

            var model = new InvestorSectorDetailDto
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
    }
}
