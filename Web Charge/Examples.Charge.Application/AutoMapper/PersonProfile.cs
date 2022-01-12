using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)).ReverseMap();

            CreateMap<PersonPhone, PersonPhoneDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BusinessEntityID))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.PhoneNumberTypeId, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
                .ForMember(dest => dest.PhoneNumberTypeName, opt => opt.MapFrom(src => src.PhoneNumberType.Name)).ReverseMap();

            CreateMap<PersonPhoneRequest, PersonPhone>()
                .ForMember(dest => dest.BusinessEntityID, opt => opt.MapFrom(src => src.BusinessEntityID))
                .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ReverseMap();
        }
    }
}
