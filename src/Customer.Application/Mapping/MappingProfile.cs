﻿using AutoMapper;
using Customer.Domain.DTO;
using Customers = Customer.Domain.Models.Customer;

namespace Customer.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerRequest, Customers>()
            .ForMember(dest => dest.CreatedBy, conf => conf.MapFrom(src => "admin"))
            .ForMember(dest => dest.UpdatedBy, conf => conf.MapFrom(src => "admin"));
        
        CreateMap<UpdateCustomerRequest, Customers>()
            .ForMember(dest => dest.CreatedBy, conf => conf.MapFrom(src => "admin"))
            .ForMember(dest => dest.UpdatedBy, conf => conf.MapFrom(src => "admin"));
        
        CreateMap<Customers, GetCustomerResponse>();
    }
}
