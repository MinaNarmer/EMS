using EFGHermes.DAL.IRepositories;
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.DAL.Persistance;
using EFGHermes.Data.Models;

namespace EFGHermes.DAL.Repositories
{
    public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
    {
        public ReservationRepository(IDbFactory dbFactory)
      : base(dbFactory) { }
    }
}
