
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
        public int HourFrom { get; set; }
        public int HourTo { get; set; }

        [MaxLength(2)]
        public string TimeType { get; set; } // It mean AM or PM


        #region Navigation Properties
        public Room Room { get; set; }
        public virtual List<Reservation> Reservations { get; set; }


        #endregion
    }
}
