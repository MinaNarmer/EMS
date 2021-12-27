using EFGHermes.Data.Models.Base;
using System.Collections.Generic;

namespace EFGHermes.Data.Models
{
    public class Hotel : NameEntity
    {


        #region Navigation Properties

        public virtual List<Room> Rooms { get; set; }

        public virtual List<Reservation> Reservations { get; set; }


        #endregion
    }
}
