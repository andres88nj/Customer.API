using MediatR;

namespace Customer.Application.Feature.Customer.Commands;

public class DeleteCustomerCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteCustomerCommand(Guid id)
    {
        Id = id;
    }
}