
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
        public string SlotDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
