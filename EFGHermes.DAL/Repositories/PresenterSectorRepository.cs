
using EFGHermes.DAL.IRepositories;
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.DAL.Persistance;
using EFGHermes.Data.Models;

namespace EFGHermes.DAL.Repositories
{
    public class PresenterSectorRepository : RepositoryBase<PresenterSector>, IPresenterSectorRepository
    {
        public PresenterSectorRepository(IDbFactory dbFactory)
       : base(dbFactory) { }
    }
}
