using System;
using System.Collections.Generic;

namespace EFGHermes.BL.Dtos
{
    public class InvestorSectorDetailDto
    {
        public string Name { get; set; }
        public List<SectorSlot> Sectors { get; set; }
    }

    public class SectorSlot
    {
        public string Name { get; set; }
        public string SlotDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }

    }
}
