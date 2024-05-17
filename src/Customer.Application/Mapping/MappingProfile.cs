using AutoMapper;
using Customer.Domain.DTO;
using Customers = Customer.Domain.Models.Customer;

namespace Customer.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCustomerRequest, Customers>();
        CreateMap<UpdateCustomerRequest, Customers>();
        CreateMap<Customers, GetCustomerResponse>();
    }
}
