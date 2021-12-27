
using AutoMapper;
using EFGHermes.BL.Dtos.Base;
using EFGHermes.BL.IServices;
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.DAL.IRepository;
using EFGHermes.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFGHermes.BL.Services
{
    public class HotelServices : IHotelServices
    {
        #region Fields and Constructor
        public IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHotelRepository _hotelRepository;

        public HotelServices(IMapper mapper, IUnitOfWork unitOfWork, IHotelRepository hotelRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _hotelRepository = hotelRepository;
        }

        #endregion

        #region Method
        public void CreateHotel(IdNameDto dto)
        {
            var model = _mapper.Map<Hotel>(dto);
            _hotelRepository.Add(model);
            _unitOfWork.SaveChanges();
        }

        public async Task<List<IdNameDto>> GetHotelsAsync()
        {
            var hotels = await _hotelRepository.GetAll().ToListAsync();

            return _mapper.Map<List<IdNameDto>>(hotels);
        }
        #endregion

    }
}
