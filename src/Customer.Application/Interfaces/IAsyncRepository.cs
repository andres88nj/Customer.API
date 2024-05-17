﻿using Customer.Domain.Models.Common;

namespace Customer.Application.Interfaces;

public interface IAsyncRepository<T> where T : BaseDomain
{
    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T> GetByIdAsync(Guid id);

    Task<T> AddAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task DeleteAsync(T entity);
}