

using EFGHermes.Data.DAL.IPersistance;
using EFGHermes.Data.Models;

namespace EFGHermes.Data.DAL.Persistance
{
   public  class DbFactory : Disposable, IDbFactory
    {
        HermesContext dbContext;
        public HermesContext Init()
        {
            return dbContext ?? (dbContext = new HermesContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
