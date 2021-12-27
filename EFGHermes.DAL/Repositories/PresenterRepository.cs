
using EFGHermes.DAL.IRepositories;
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.DAL.Persistance;
using EFGHermes.Data.Models;

namespace EFGHermes.DAL.Repositories
{
    public class PresenterRepository : RepositoryBase<Presenter>, IPresenterRepository
    {
        public PresenterRepository(IDbFactory dbFactory)
        : base(dbFactory) { }
    }
}
