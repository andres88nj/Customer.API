using Customer.Domain.DTO;
using MediatR;

namespace Customer.Application.Feature.Customer.Commands;

public class CreateCustomerCommand : IRequest<GetCustomerResponse>
{
    public CreateCustomerRequest CustomerRequest { get; set; }

    public CreateCustomerCommand(CreateCustomerRequest customerRequest)
    {
        CustomerRequest = customerRequest;
    }
}