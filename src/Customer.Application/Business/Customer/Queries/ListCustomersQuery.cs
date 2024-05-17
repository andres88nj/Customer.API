using Customer.Domain.DTO;
using MediatR;

namespace Customer.Application.Feature.Customer.Queries;

public class ListCustomersQuery : IRequest<IEnumerable<GetCustomerResponse>>
{
}
