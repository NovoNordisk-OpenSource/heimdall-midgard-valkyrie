using Heimdall.Midgard.Valkyrie.Domain.Repositories;

namespace Heimdall.Midgard.Valkyrie.Domain.Services;

/// <summary>
///     Represents a scaffold service that provides operations related to scaffolding in Midgard.
/// </summary>
public sealed class ScaffoldService(IScaffoldTaskRepository scaffoldTaskRepository) : IScaffoldService
{
    private readonly IScaffoldTaskRepository _scaffoldTaskRepository = scaffoldTaskRepository;
    
    /// <summary>
    ///     Retrieves all scaffold tasks asynchronously.
    /// </summary>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of scaffolding tasks.</returns>
    public async Task<IEnumerable<ScaffoldTask>> GetScaffoldTasksAsync(CancellationToken ct = default)
    {
        return await _scaffoldTaskRepository.GetAsync(o => true, ct);
    }

    /// <summary>
    ///     Retrieves a scaffold task by its identifier asynchronously.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The scaffold task with the specified identifier, or null if not found.</returns>
    public async Task<ScaffoldTask?> GetScaffoldTaskByIdAsync(Guid entityId, CancellationToken ct = default)
    {
        return await _scaffoldTaskRepository.GetAsync(entityId, ct);
    }

    /// <summary>
    ///     Retrieves scaffold tasks by date range asynchronously.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date (optional).</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>A collection of domain entities.</returns>
    public async Task<IEnumerable<ScaffoldTask>> GetScaffoldTaskByDateRangeAsync(DateTime startDate, DateTime? endDate, CancellationToken ct = default)
    {
        return await _scaffoldTaskRepository.GetAsync(r => r.Created >= startDate && r.Created <= (endDate ?? DateTime.UtcNow), ct);
    }

    /// <summary>
    ///     Adds a new scaffold task asynchronously.
    /// </summary>
    /// <param name="account">The account associated with the scaffold task.</param>
    /// <param name="options">The collection of scaffold options (optional).</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The added scaffold task.</returns>
    public async Task<ScaffoldTask> AddScaffoldTaskAsync(AccountInfo account, IEnumerable<ScaffoldOption>? options = default, CancellationToken ct = default)
    {
        var entity = new ScaffoldTask(account);

        if (options != null)
            entity.AddScaffoldOption(options);

        _scaffoldTaskRepository.Add(entity);

        await _scaffoldTaskRepository.UnitOfWork.SaveEntitiesAsync(ct);

        return entity;
    }

    /// <summary>
    ///     Adds or updates a scaffold option asynchronously.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The added or updated scaffold option.</returns>
    public async Task<ScaffoldOption> AddOrUpdateScaffoldOptionAsync(Guid entityId, string key, string value, CancellationToken ct = default)
    {
        var option = new ScaffoldOption(key, value);
        var entity = await _scaffoldTaskRepository.GetAsync(entityId, ct);

        if (entity is not null && entity.Options != null && !entity.Options.Any(o => o.Equals(option)))
        {
            entity.AddScaffoldOption(option);
            await UpdateScaffoldTaskAsync(entity, ct);
        }

        return option;
    }

    /// <summary>
    ///     Deletes a scaffold task asynchronously.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>True if the scaffold task is deleted, otherwise false.</returns>
    public async Task<bool> DeleteScaffoldTaskAsync(Guid entityId, CancellationToken ct = default)
    {
        var entity = await _scaffoldTaskRepository.GetAsync(entityId, ct);

        if (entity is not null) _scaffoldTaskRepository.Delete(entity);

        return await _scaffoldTaskRepository.UnitOfWork.SaveEntitiesAsync(ct);
    }

    /// <summary>
    ///     Deletes a scaffold option asynchronously.
    /// </summary>
    /// <param name="entityId">The entity identifier.</param>
    /// <param name="key">The key.</param>
    /// <param name="capabilityIdentifier">The capability identifier (optional).</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>True if the scaffold option is deleted, otherwise false.</returns>
    public async Task<bool> DeleteScaffoldOptionAsync(Guid entityId, string key, CancellationToken ct = default)
    {
        var entity = await _scaffoldTaskRepository.GetAsync(entityId, ct);

        if (entity is not null)
        {
            var query = entity.Options.Where(ci => ci.Key == key).AsQueryable();

            foreach (var o in query.AsEnumerable())
                entity.RemoveScaffoldOption(o);

            await UpdateScaffoldTaskAsync(entity, ct);

            return true;
        }

        return false;
    }

    /// <summary>
    ///     Updates a scaffold task asynchronously.
    /// </summary>
    /// <param name="entity">The scaffold task.</param>
    /// <param name="ct">The cancellation token.</param>
    /// <returns>The updated scaffold task.</returns>
    public async Task<ScaffoldTask> UpdateScaffoldTaskAsync(ScaffoldTask entity, CancellationToken ct = default)
    {
        var updatedEntity = _scaffoldTaskRepository.Update(entity);

        await _scaffoldTaskRepository.UnitOfWork.SaveEntitiesAsync(ct);

        return updatedEntity;
    }
}