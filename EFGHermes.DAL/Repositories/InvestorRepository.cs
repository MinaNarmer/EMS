using EFGHermes.DAL.IRepositories;
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.DAL.Persistance;
using EFGHermes.Data.Models;

namespace EFGHermes.DAL.Repositories
{
    public class InvestorRepository : RepositoryBase<Investor>, IInvestorRepository
    {
        public InvestorRepository(IDbFactory dbFactory)
        : base(dbFactory) { }
    }
}
