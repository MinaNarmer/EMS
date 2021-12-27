using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.DAL.IRepository;
using EFGHermes.Data.DAL.Persistance;
using EFGHermes.Data.Models;

namespace EFGHermes.Data.DAL.Repository
{
   public class HotelRepository :RepositoryBase<Hotel> , IHotelRepository
    {
        public HotelRepository(IDbFactory dbFactory)
        : base(dbFactory) { }
    }
}
