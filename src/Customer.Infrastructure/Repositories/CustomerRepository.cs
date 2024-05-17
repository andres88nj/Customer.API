using Customer.Application.Interfaces;
using Customer.Domain.DTO;

namespace Customer.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Domain.Models.Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    { }
}