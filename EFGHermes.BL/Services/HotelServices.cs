
using EFGHermes.BL.IServices;
using EFGHermes.Data.DAL.IPersistance;

namespace EFGHermes.BL.Services
{
    public class HotelServices : IHotelServices
    {
        #region Fields and Constructor
        private readonly IUnitOfWork _unitOfWork;

        public HotelServices()
        {

        }
        #endregion
    }
}
