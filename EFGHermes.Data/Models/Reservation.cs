
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGHermes.Data.Models
{
    public class Reservation : BaseEntity
    {
        [ForeignKey("Presenter")]
        public int PresenterId { get; set; }

        [ForeignKey("Investor")]
        public int InvestorId { get; set; }

        [ForeignKey("Room")]
        public int RoomId { get; set; }

        [ForeignKey("Hotel")]
        public int HotelId { get; set; }

        [ForeignKey("Sector")]
        public int SectorId { get; set; }


        [ForeignKey("RoomSlot")]
        public int RoomSlotId { get; set; }



        #region Navigation Properties

        public Presenter Presenter { get; set; }
        public Investor Investor { get; set; }
        public Sector Sector { get; set; }
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
        public RoomSlot RoomSlot { get; set; }


        #endregion
    }
}
