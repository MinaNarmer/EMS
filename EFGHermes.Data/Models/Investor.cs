using EFGHermes.Data.Models.Base;
using System.Collections.Generic;

namespace EFGHermes.Data.Models
{
    public class Investor : NameEntity
    {
        public string Mobile { get; set; }


        #region Navigation Properties
        public virtual List<InvestorSector> InvestorSectors { get; set; }
        public virtual List<Reservation> Reservations { get; set; }


        #endregion
    }
}
