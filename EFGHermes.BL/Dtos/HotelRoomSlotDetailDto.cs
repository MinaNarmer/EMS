
using System;
using System.Collections.Generic;

namespace EFGHermes.BL.Dtos.Base
{
    public class HotelRoomSlotDetailDto
    {
        public string Name { get; set; }
        public List<RoomDto> Rooms { get; set; }

    }
    public class RoomDto
    {
        public string Name { get; set; }
        public List<RoomSlotDto> RoomSlots { get; set; }

    }
    public class RoomSlotDto
    {
        public DateTime SlotDate { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}
