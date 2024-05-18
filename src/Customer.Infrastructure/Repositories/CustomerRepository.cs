using Customer.Application.Interfaces;

namespace Customer.Infrastructure.Repositories;

public class CustomerRepository : RepositoryBase<Domain.Models.Customer>, ICustomerRepository
{
    public CustomerRepository(AppDbContext context) : base(context)
    { }
}