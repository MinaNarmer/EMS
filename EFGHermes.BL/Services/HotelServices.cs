
using AutoMapper;
using EFGHermes.BL.Dtos;
using EFGHermes.BL.Dtos.Base;
using EFGHermes.BL.IServices;
using EFGHermes.DAL.IRepositories;
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
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomSlotRepository _roomSlotRepository;

        public HotelServices(IMapper mapper, IUnitOfWork unitOfWork, IHotelRepository hotelRepository, IRoomRepository roomRepository, IRoomSlotRepository roomSlotRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _hotelRepository = hotelRepository;
            _roomRepository = roomRepository;
            _roomSlotRepository = roomSlotRepository;
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

        public void CreateRoomWithTimeSlot(CreateRoomDto dto)
        {
            _roomSlotRepository.Add(new RoomSlot
            {

                SlotDate = dto.SlotDateFrom.Date,
                HourFrom = dto.SlotDateFrom.TimeOfDay,
                HourTo = dto.SlotDateTo.TimeOfDay,
                Room = new Room
                {
                    Name = dto.Name,
                    HotelId = dto.HotelId

                }
            });
            _unitOfWork.SaveChanges();

        }

        public async Task<HotelRoomSlotDetailDto> GetHotelRoomsSlotsAsync(int hotelId)
        {
            var hotel = _hotelRepository.GetById(hotelId);
            var rooms = await _roomRepository.GetAll()
                .Include(x=> x.RoomSlots)
                .Where(x => x.HotelId == hotelId).ToListAsync();

            var model = new HotelRoomSlotDetailDto
            {
                Name = hotel.Name,
                Rooms= rooms.Select(x=> new RoomDto { 
                Name = x.Name,
                RoomSlots = x.RoomSlots.Select(r=> new RoomSlotDto { 
                SlotDate = r.SlotDate.ToString("dddd, dd MMMM yyyy"),
                From =r.HourFrom.ToString("dd\\:hh\\:mm"),
                To = r.HourTo.ToString("dd\\:hh\\:mm")
                }).ToList()
                }).ToList()

            };
            return model;
        }



        #endregion

    }
}
