namespace Heimdall.Midgard.Valkyrie.Infrastructure.EntityFramework.Repositories;

/// <summary>
///     Represents a repository for managing <see cref="ScaffoldTask" /> entities in the database.
/// </summary>
/// <remarks>
///     Initializes a new instance of the <see cref="ScaffoldTaskRepository" /> class.
/// </remarks>
/// <param name="context">The application context.</param>
public class ScaffoldTaskRepository(ApplicationContext context) : EntityFrameworkRepository<ScaffoldTask, ApplicationContext>(context), IScaffoldTaskRepository
{
    /// <summary>
    ///     Retrieves a collection of <see cref="ScaffoldTask" /> entities from the database asynchronously based on the
    ///     specified filter.
    /// </summary>
    /// <param name="filter">The filter expression.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the collection of
    ///     <see cref="ScaffoldTask" /> entities.
    /// </returns>
    public override async Task<IEnumerable<ScaffoldTask>> GetAsync(Expression<Func<ScaffoldTask, bool>> filter, CancellationToken ct = default)
    {
        return await Task.Factory.StartNew(() =>
        {
            return _context.ScaffoldTasks.AsQueryable()
                .AsNoTracking()
                .Where(filter)
                .Include(i => i.Options)
                .AsEnumerable();
        }, ct);
    }

    /// <summary>
    ///     Retrieves a <see cref="ScaffoldTask" /> entity from the database asynchronously based on the specified entity ID.
    /// </summary>
    /// <param name="entityId">The entity ID.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>
    ///     A task that represents the asynchronous operation. The task result contains the <see cref="ScaffoldTask" />
    ///     entity, or null if not found.
    /// </returns>
    public async Task<ScaffoldTask?> GetAsync(Guid entityId, CancellationToken ct = default)
    {
        var entity = await _context.ScaffoldTasks.FindAsync(entityId, ct);

        if (entity is not null)
        {
            var entry = _context.Entry(entity);
            await entry.Reference(o => o.Options).LoadAsync(ct);
        }

        return entity;
    }
}