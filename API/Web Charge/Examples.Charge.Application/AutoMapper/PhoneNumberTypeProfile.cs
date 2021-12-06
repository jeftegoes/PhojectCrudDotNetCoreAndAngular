using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PhoneNumberTypeProfile : Profile
    {
        public PhoneNumberTypeProfile()
        {
            CreateMap<PhoneNumberType, PhoneNumberTypeDto>()
               .ReverseMap()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID));

            CreateMap<PhoneNumberType, PhoneNumberTypeResponse>()
               .ReverseMap()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
               .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.BusinessEntityID));
        }
    }
}
