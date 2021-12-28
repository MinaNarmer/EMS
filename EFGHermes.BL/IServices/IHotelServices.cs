
using EFGHermes.BL.Dtos;
using EFGHermes.BL.Dtos.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFGHermes.BL.IServices
{
    public interface IHotelServices
    {
        void CreateHotel(IdNameDto dto);
        Task<List<IdNameDto>> GetHotelsAsync();
        Task<HotelRoomSlotDetailDto> GetHotelRoomsSlotsAsync(int hotelId);
        void CreateRoomWithTimeSlot(CreateRoomDto dto);




    }
}
