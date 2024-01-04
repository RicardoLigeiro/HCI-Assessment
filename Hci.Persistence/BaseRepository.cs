using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Hci.Persistence;

/// <summary>
///     Base class for the repository, we just keep it simple with no interfaces
/// </summary>
public class BaseRepository //: IRepository
{
    private readonly DbContext _context;

    public BaseRepository(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    ///     Get all the records from the table
    /// </summary>
    /// <returns></returns>
    protected async Task<IEnumerable<T>> GetAllEntitiesAsync<T>() where T : class
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    /// <summary>
    ///     Find's a collection of entities by a given condition
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    protected async Task<IEnumerable<T>> GetEntitiesByConditionAsync<T>(Expression<Func<T, bool>> expression)
        where T : class
    {
        return await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
    }

    /// <summary>
    ///     Get one entity record by the given expression
    /// </summary>
    /// <param name="expression">Predicate</param>
    /// <returns>The entity</returns>
    protected async Task<T> GetEntityAsync<T>(Expression<Func<T, bool>> expression) where T : class
    {
        return await _context.Set<T>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
    }
}