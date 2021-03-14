using AutoMapper;
using CongestionTax.Contracts.Dtos;
using CongestionTaxCalculator.Data.Models;

namespace CongestionTaxCalculator.Api.Mapping
{
    public class DomainToResponseMappingProfile : Profile
    {
        public DomainToResponseMappingProfile()
        {
            CreateMap<Passage, PassageDto>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Tariff.Price));

            CreateMap<VehicleType, VehicleTypeDto>();
            CreateMap<Zone, ZoneDto>();
            CreateMap<Vehicle, VehicleDto>();
        }
    }
}
