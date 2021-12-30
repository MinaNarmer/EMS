using EFGHermes.BL.Dtos;
using EFGHermes.BL.Dtos.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFGHermes.BL.IServices
{
   public interface IPresenterService 
    {
        void CreatePresenter(PresenterDto dto);
        Task<List<PresenterDto>> GetInvestorsAsync();
        Task<List<IdNameDto>> GetSectorssAsync();
        void CreateSectorWithTimeSlot(CreatePresenterSectorTimeSlot dto);
        Task<PresenterSectorDetailDto> GetInvestorSectorAsync(int presenterId);
    }
}
