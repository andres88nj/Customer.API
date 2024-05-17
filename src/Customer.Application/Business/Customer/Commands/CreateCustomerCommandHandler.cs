using AutoMapper;
using Customer.Application.Interfaces;
using Customer.Domain.DTO;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Application.Feature.Customer.Commands;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, GetCustomerResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateCustomerCommandHandler> _logger;

    public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateCustomerCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<GetCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _mapper.Map<Domain.Models.Customer>(request.CustomerRequest);

        await _unitOfWork.CustomerRepository.AddAsync(customer);
        await _unitOfWork.Complete();

        var result = _mapper.Map<GetCustomerResponse>(customer);
        //_logger.LogInformation($"Streamer {customer.Id} fue creado existosamente");

        return result;
    }
}
