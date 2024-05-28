using AutoMapper;
using CrayonCloudSales.ResponseRequestModels;
using CrayonCloudSales.Services;
using CrayonCloudSales.Services.CcpService;
using DataAccess.Entities;
using System.Numerics;

namespace CrayonCloudSales.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountResponse>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer!.Name));
            CreateMap<Software, SoftwareResponse>()
             .ForMember(dest => dest.ValidTo, opt => opt.MapFrom(src => src.ValidTo.ToShortDateString()));

            CreateMap<(Service service, SoftwareOrderRequest request, string state, DateTime validTo), Software>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.request.Quantity))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.state))
                .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.request.AccountId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.service.Name))
                .ForMember(dest => dest.ValidTo, opt => opt.MapFrom(src => src.validTo));

        }
    }
}
