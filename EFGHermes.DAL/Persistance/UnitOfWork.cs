
using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.Models;

namespace EFGHermes.Data.DAL.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly IDbFactory _dbFactory;
        private HermesContext _dbcontext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this._dbFactory = dbFactory;
            this._dbcontext = this._dbcontext ?? (this._dbcontext = dbFactory.Init());

        }
        public HermesContext DbContext
        {
            get { return _dbcontext ?? (_dbcontext = _dbFactory.Init()); }

        }

        public void SaveChanges()
        {
            this._dbcontext.SaveChanges();
        }
    }
}

