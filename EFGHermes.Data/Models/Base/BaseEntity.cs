
using System.ComponentModel.DataAnnotations;

namespace EFGHermes.Data.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
