using Customer.Domain.Models.Common;

namespace Customer.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomain;

    Task<int> Complete();

    ICustomerRepository CustomerRepository { get; }
    ICityRepository CityRepository { get; }
    IStateRepository StateRepository { get; }
}
