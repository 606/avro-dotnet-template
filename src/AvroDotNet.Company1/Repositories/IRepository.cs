namespace AvroDotNet.Company1.Repositories;

/// <summary>
/// Generic repository interface for data access
/// </summary>
/// <typeparam name="T">Entity type</typeparam>
public interface IRepository<T> where T : class
{
    /// <summary>
    /// Gets all entities
    /// </summary>
    /// <returns>Collection of entities</returns>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Gets entity by identifier
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <returns>Entity or null</returns>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Adds a new entity
    /// </summary>
    /// <param name="entity">Entity to add</param>
    /// <returns>Added entity</returns>
    Task<T> AddAsync(T entity);

    /// <summary>
    /// Updates an existing entity
    /// </summary>
    /// <param name="entity">Entity to update</param>
    /// <returns>Updated entity</returns>
    Task<T> UpdateAsync(T entity);

    /// <summary>
    /// Deletes an entity by identifier
    /// </summary>
    /// <param name="id">Entity identifier</param>
    /// <returns>True if deleted, false otherwise</returns>
    Task<bool> DeleteAsync(int id);
}
