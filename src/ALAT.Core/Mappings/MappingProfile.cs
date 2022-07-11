using ALAT.Core.DTOs;
using ALAT.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALAT.Core.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>()
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
            CreateMap<Customer, CustomerResponse>()
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.Name))
                .ForMember(dest => dest.Lga, opt => opt.MapFrom(src => src.Lga.Name));
            CreateMap<State, StateResponse>()
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.Name));
            CreateMap<Lga, LgaResponse>()
                .ForMember(dest => dest.LgaName, opt => opt.MapFrom(src => src.Name));
        }
    }
}
