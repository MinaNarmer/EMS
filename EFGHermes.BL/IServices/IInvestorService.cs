using EFGHermes.BL.Dtos;
using EFGHermes.BL.Dtos.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFGHermes.BL.IServices
{
    public interface IInvestorService
    {
        void CreateInvestor(InvestorDto dto);
        Task<List<InvestorDto>> GetInvestorsAsync();
        Task<List<IdNameDto>> GetSectorssAsync();
        void CreateSectorWithTimeSlot(CreateInvestorSectorTimeSlot dto);
        Task<InvestorSectorDetailDto> GetInvestorSectorAsync(int investorId);


    }
}
