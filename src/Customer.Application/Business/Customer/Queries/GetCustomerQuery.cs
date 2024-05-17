using Customer.Domain.DTO;
using MediatR;

namespace Customer.Application.Feature.Customer.Queries;

public class GetCustomerQuery : IRequest<GetCustomerResponse>
{
    public Guid Id { get; set; }

    public GetCustomerQuery(Guid id)
    {
        Id = id;
    }
}
