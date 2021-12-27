using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGHermes.Data.Models
{
    public class InvestorSector : BaseEntity
    {

        [ForeignKey("Investor")]
        public int InvestorId { get; set; }

        [ForeignKey("Sector")]
        public int SectorId { get; set; }
        public DateTime SlotDate { get; set; }
        public int HourFrom { get; set; }
        public int HourTo { get; set; }

        [MaxLength(2)]
        public string TimeType { get; set; } // It mean AM or PM


        #region Navigation Properties
        public Investor Investor { get; set; }
        public Sector Sector { get; set; }


        #endregion

    }
}
