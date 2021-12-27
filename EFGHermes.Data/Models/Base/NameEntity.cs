
using System.ComponentModel.DataAnnotations;

namespace EFGHermes.Data.Models.Base
{
    public class NameEntity : BaseEntity
    {
        [Required,MaxLength(200)]
        public string Name { get; set; }
    }
}
