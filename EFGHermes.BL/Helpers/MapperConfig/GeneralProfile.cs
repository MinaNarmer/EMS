
using AutoMapper;
using EFGHermes.BL.Dtos;
using EFGHermes.BL.Dtos.Base;
using EFGHermes.Data.Models;

namespace EFGHermes.BL.Helpers.MapperConfig
{
   public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<IdNameDto, Hotel>().ReverseMap();
            CreateMap<IdNameDto, Sector>().ReverseMap();
            CreateMap<InvestorDto, Investor>().ReverseMap();
        }
    }
}
