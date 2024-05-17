using AutoMapper;
using Customer.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Application.Feature.Customer.Commands;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdateCustomerCommandHandler> _logger;

    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateCustomerCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Domain.Models.Customer>(request.CustomerRequest);

        await _unitOfWork.CustomerRepository.UpdateAsync(result);
        await _unitOfWork.Complete();

        //_logger.LogInformation($"La operacion fue exitosa actualizando el streamer {request.CustomerRequest.Id}");

        return true;
    }
}
