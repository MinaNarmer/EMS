using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGHermes.Data.Models
{
   public class PresenterSector : BaseEntity
    {
        [ForeignKey("Presenter")]
        public int PresenterId { get; set; }

        [ForeignKey("Sector")]
        public int SectorId { get; set; }
        public DateTime SlotDate { get; set; }
        public int HourFrom { get; set; }
        public int HourTo { get; set; }

        [MaxLength(2)]
        public string TimeType { get; set; } // It mean AM or PM


        #region Navigation Properties
        public Presenter Presenter { get; set; }
        public Sector Sector { get; set; }


        #endregion
    }
}
