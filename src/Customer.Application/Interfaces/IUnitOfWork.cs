using Customer.Domain.Models.Common;

namespace Customer.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : AuditableEntity;

    Task<int> Complete();

    ICustomerRepository CustomerRepository { get; }
}
