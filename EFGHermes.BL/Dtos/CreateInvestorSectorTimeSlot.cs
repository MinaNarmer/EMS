using System;

namespace EFGHermes.BL.Dtos
{
   public class CreateInvestorSectorTimeSlot
    {
        public int InvestorId { get; set; }
        public int SectorId { get; set; }
        public DateTime SlotDate { get; set; }
        public DateTime HourFrom { get; set; }
        public DateTime HourTo { get; set; }
    }
}
