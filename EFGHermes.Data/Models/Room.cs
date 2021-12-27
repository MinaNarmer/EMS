using EFGHermes.Data.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGHermes.Data.Models
{
    public class Room : NameEntity
    {
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }


        #region Navigation Properties

        public Hotel Hotel { get; set; }
        public virtual List<RoomSlot> RoomSlots { get; set; }
        public virtual List<Reservation> Reservations { get; set; }


        #endregion
    }
}
