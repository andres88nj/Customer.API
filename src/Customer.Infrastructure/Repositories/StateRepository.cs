using Customer.Application.Interfaces;

namespace Customer.Infrastructure.Repositories;

public class StateRepository : RepositoryBase<Domain.Models.State>, IStateRepository
{
    public StateRepository(AppDbContext context) : base(context)
    { }
}