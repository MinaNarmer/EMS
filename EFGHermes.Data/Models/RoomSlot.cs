
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGHermes.Data.Models
{
    public class RoomSlot : BaseEntity
    {
        [ForeignKey("Room")]
        public int RoomId { get; set; }
        public DateTime SlotDate { get; set; }
        public TimeSpan HourFrom { get; set; }
        public TimeSpan HourTo { get; set; }

     


        #region Navigation Properties
        public Room Room { get; set; }
        public virtual List<Reservation> Reservations { get; set; }


        #endregion
    }
}
