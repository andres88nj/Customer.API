using Customer.Domain.DTO;
using MediatR;

namespace Customer.Application.Feature.Customer.Commands;

public class UpdateCustomerCommand : IRequest<bool>
{
    public UpdateCustomerRequest CustomerRequest { get; set; }

    public UpdateCustomerCommand(UpdateCustomerRequest customerRequest)
    {
        CustomerRequest = customerRequest;
    }
}