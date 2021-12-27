
using EFGHermes.Data.Models.Base;
using System.Collections.Generic;

namespace EFGHermes.Data.Models
{
    public class Presenter : NameEntity
    {
        public string Mobile { get; set; }


        #region Navigation Properties

        public virtual List<PresenterSector> PresenterSectors { get; set; }
        public virtual List<Reservation> Reservations { get; set; }


        #endregion
    }
}
