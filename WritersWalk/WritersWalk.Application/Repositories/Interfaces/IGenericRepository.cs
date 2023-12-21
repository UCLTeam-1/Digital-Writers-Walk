namespace WritersWalk.Application.Repositories;

/// <summary>
/// Generic repository interface for accessing entities.
/// </summary>
/// <typeparam name="T">The entity type</typeparam>
public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}