using AutoMapper;
using Customer.Application.Interfaces;
using Customer.Domain.DTO;
using MediatR;

namespace Customer.Application.Feature.Customer.Queries;

public class ListCustomersQueryHandler : IRequestHandler<ListCustomersQuery, IEnumerable<GetCustomerResponse>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ListCustomersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetCustomerResponse>> Handle(ListCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _unitOfWork.CustomerRepository.GetAllAsync();

        foreach (var customer in customers) 
        {
            var city = await _unitOfWork.CityRepository.GetByIdAsync(customer.CityId);
            var state = await _unitOfWork.StateRepository.GetByIdAsync(city.StateId);
            city.State = state;
            customer.City = city;  
        }
        
        return _mapper.Map<IEnumerable<GetCustomerResponse>>(customers);
    }
}
