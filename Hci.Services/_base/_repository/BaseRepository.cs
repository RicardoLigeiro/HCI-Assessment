using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Hci.Services;

/// <summary>
///     Base class for the repository
/// </summary>
internal class BaseRepository
{
    internal readonly DatabaseContext Context;

    public BaseRepository(DatabaseContext context)
    {
        Context = context;
    }

    /// <summary>
    ///     Get all the records from the table
    /// </summary>
    /// <returns></returns>
    protected async Task<IEnumerable<T>> GetAllEntitiesAsync<T>() where T : class
    {
        return await Context.Set<T>().AsNoTracking().ToListAsync();
    }

    /// <summary>
    ///     Find's a collection of entities by a given condition
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    protected async Task<IEnumerable<T>> GetEntitiesByConditionAsync<T>(Expression<Func<T, bool>> expression)
        where T : class
    {
        return await Context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
    }

    /// <summary>
    ///     Get one entity record by the given expression
    /// </summary>
    /// <param name="expression">Predicate</param>
    /// <returns>The entity</returns>
    protected async Task<T> GetEntityAsync<T>(Expression<Func<T, bool>> expression) where T : class
    {
        return await Context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
    }

    /*
     *
     * This class is just to show that we can do all the operations in the database on a generic way
     *
     */
}