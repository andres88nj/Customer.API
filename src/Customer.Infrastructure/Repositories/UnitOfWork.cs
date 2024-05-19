using Customer.Application.Interfaces;
using Customer.Domain.Models.Common;
using System.Collections;

namespace Customer.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable _repositories;
    private readonly AppDbContext _context;

    private ICustomerRepository _customerRepository;

    public ICustomerRepository CustomerRepository => _customerRepository ??= new CustomerRepository(_context);

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public AppDbContext AppDbContext => _context;

    public async Task<int> Complete()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomain
    {
        if (_repositories == null)
            _repositories = new Hashtable();

        var type = typeof(TEntity).Name;

        if (!_repositories.ContainsKey(type))
        {
            var repositotyType = typeof(RepositoryBase<>);
            var repositoryInstance = Activator.CreateInstance(repositotyType.MakeGenericType(typeof(TEntity)), _context);
            _repositories.Add(type, repositoryInstance);
        }

        return (IAsyncRepository<TEntity>)_repositories[type];
    }
}
