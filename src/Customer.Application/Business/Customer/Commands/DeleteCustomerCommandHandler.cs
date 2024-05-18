using AutoMapper;
using Customer.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Customer.Application.Feature.Customer.Commands;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<DeleteCustomerCommandHandler> _logger;

    public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteCustomerCommandHandler> logger)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var deleteCustomer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

        if (deleteCustomer == null)
            return false;

        await _unitOfWork.CustomerRepository.DeleteAsync(deleteCustomer);
        await _unitOfWork.Complete();

        _logger.LogInformation($"Successful delete for: {request.Id}");

        return true;
    }
}
