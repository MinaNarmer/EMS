
using EFGHermes.DAL.IRepositories;
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.DAL.Persistance;
using EFGHermes.Data.Models;

namespace EFGHermes.DAL.Repositories
{
    public class RoomSlotRepository : RepositoryBase<RoomSlot>, IRoomSlotRepository
    {
        public RoomSlotRepository(IDbFactory dbFactory)
     : base(dbFactory) { }
    }
}
