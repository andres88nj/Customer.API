using AutoMapper;
using Customer.Application.Interfaces;
using Customer.Domain.DTO;
using Customer.Domain.Models;
using MediatR;

namespace Customer.Application.Feature.Customer.Queries;

public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, GetCustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetCustomerResponse> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

        if (customer == null)
            return null;

        var city = await _unitOfWork.CityRepository.GetByIdAsync(customer.CityId);
        var state = await _unitOfWork.StateRepository.GetByIdAsync(city.StateId);
        city.State = state;
        customer.City = city;

        return _mapper.Map<GetCustomerResponse>(customer);
    }
}
