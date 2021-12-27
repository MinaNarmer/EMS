
using EFGHermes.Data.Models;
using System;


namespace EFGHermes.Data.DAL.IPersistance
{
    public interface IDbFactory : IDisposable
    {
        HermesContext Init();
    }
}
