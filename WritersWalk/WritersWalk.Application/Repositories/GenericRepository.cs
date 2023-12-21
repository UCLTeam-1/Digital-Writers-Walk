using Microsoft.EntityFrameworkCore;
using WritersWalk.Application.Database;

namespace WritersWalk.Application.Repositories;

/// <summary>
/// Generic repository for accessing entities in the database.
/// </summary>
/// <typeparam name="T">The entity type</typeparam>
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly SqliteDbContext _context;

    public GenericRepository(SqliteDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity</param>
    /// <returns>The entity with the given ID, or null if not found</returns>
    public async Task<T?> GetByIdAsync(int id)
    {
        return await _context.FindAsync<T>(id);
    }

    /// <summary>
    /// Retrieves all entities of the specified type asynchronously.
    /// </summary>
    /// <returns>A list of entities</returns>
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    /// Adds a new entity to the repository asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add</param>
    public async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing entity in the repository asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update</param>
    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an existing entity from the repository asynchronously.
    /// </summary>
    /// <param name="entity">The entity to delete</param>
    public async Task DeleteAsync(T entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }
}