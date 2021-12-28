
using System;
using System.ComponentModel.DataAnnotations;

namespace EFGHermes.BL.Dtos
{
    public class CreateRoomDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public DateTime SlotDateFrom { get; set; }
        [Required]
        public DateTime SlotDateTo { get; set; }
      

      
    }
}
