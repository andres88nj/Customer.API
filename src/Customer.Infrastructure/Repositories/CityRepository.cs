using Customer.Application.Interfaces;

namespace Customer.Infrastructure.Repositories;

public class CityRepository : RepositoryBase<Domain.Models.City>, ICityRepository
{
    public CityRepository(AppDbContext context) : base(context)
    { }
}