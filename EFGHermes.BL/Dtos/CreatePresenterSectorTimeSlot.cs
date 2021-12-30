using System;
using System.Collections.Generic;
using System.Text;

namespace EFGHermes.BL.Dtos
{
    public class CreatePresenterSectorTimeSlot
    {
        public int PresenterId { get; set; }
        public int SectorId { get; set; }
        public DateTime SlotDate { get; set; }
        public DateTime HourFrom { get; set; }
        public DateTime HourTo { get; set; }
    }
}
