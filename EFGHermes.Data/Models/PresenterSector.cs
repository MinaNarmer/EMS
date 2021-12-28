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
        public TimeSpan HourFrom { get; set; }
        public TimeSpan HourTo { get; set; }

        


        #region Navigation Properties
        public Presenter Presenter { get; set; }
        public Sector Sector { get; set; }


        #endregion
    }
}
