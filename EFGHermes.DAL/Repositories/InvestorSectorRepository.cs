
using EFGHermes.DAL.IRepositories;
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.DAL.Persistance;
using EFGHermes.Data.Models;

namespace EFGHermes.DAL.Repositories
{
    public class InvestorSectorRepository : RepositoryBase<InvestorSector>, IInvestorSectorRepository
    {
        public InvestorSectorRepository(IDbFactory dbFactory)
       : base(dbFactory) { }
    }
}
