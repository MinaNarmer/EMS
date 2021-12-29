
using System.Collections.Generic;
using System.Linq;

namespace EFGHermes.Data.Models.Seed
{
    public class SeedData
    {
        public static void SeedSectors(HermesContext _context)
        {
            _context.Database.EnsureCreated();
            if (!_context.Sectors.Any())
            {
                var sectors = new List<Sector>
            {
                new Sector { Name = "Restaurants"},
                new Sector { Name = "Finance"},
                new Sector { Name = "IT"},
                new Sector { Name = "Real Estate"},

            };
                _context.AddRange(sectors);
                _context.SaveChanges();

            }
        }
    }
}
