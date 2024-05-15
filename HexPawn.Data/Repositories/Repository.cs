using System.Data;
using System.Linq.Expressions;
using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models;
using Microsoft.EntityFrameworkCore;

namespace HexPawn.Data.Repositories;

public class Repository<TBaseEntity>(DbContext context) : IRepository<TBaseEntity> where TBaseEntity : BaseEntity
{
    private readonly DbSet<TBaseEntity>? _dbSet = context.Set<TBaseEntity>();

    #region Where

    /// <summary>
    /// Perform a Where filter on the dbset while respecting soft deletes
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public virtual IQueryable<TBaseEntity> Where(Expression<Func<TBaseEntity, bool>> filter,
            bool? includeDeleted = false)
    {
        var where = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .Where(filter);

        return where;
    }

    #endregion

    #region First

    public virtual TBaseEntity First(Expression<Func<TBaseEntity, bool>> filter,
            bool? includeDeleted = false)
    {
        var first =  (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .First(filter);

        return first;
    }

    public virtual TBaseEntity? FirstOrDefault(Expression<Func<TBaseEntity, bool>> filter,
            bool? includeDeleted = false)
    {
        var firstOrDefault = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .FirstOrDefault(filter);

        return firstOrDefault;
    }

    public virtual async Task<TBaseEntity> FirstAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var firstAsync = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .FirstAsync(filter, cancellationToken);

        return firstAsync;
    }

    public virtual async Task<TBaseEntity?> FirstOrDefaultAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var firstOrDefaultAsync = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .FirstOrDefaultAsync(filter, cancellationToken);

        return firstOrDefaultAsync;
    }

    #endregion

    #region Single

    public virtual TBaseEntity Single(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var single = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .Single(filter);

        return single;
    }

    public virtual TBaseEntity? SingleOrDefault(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var singleOrDefault = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .SingleOrDefault(filter);

        return singleOrDefault;
    }

    public virtual async Task<TBaseEntity> SingleAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var singleAsync = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .SingleAsync(filter, cancellationToken);

        return singleAsync;
    }

    public virtual async Task<TBaseEntity?> SingleOrDefaultAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var singleOrDefaultAsync = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .SingleOrDefaultAsync(filter, cancellationToken);

        return singleOrDefaultAsync;
    }

    #endregion

    #region Last

    public virtual TBaseEntity Last(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var last = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .Last(filter);

        return last;
    }

    public virtual TBaseEntity? LastOrDefault(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var lastOrDefault = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .LastOrDefault(filter);

        return lastOrDefault;
    }

    public virtual async Task<TBaseEntity> LastAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var lastAsync = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .LastAsync(filter, cancellationToken);

        return lastAsync;
    }

    public virtual async Task<TBaseEntity?> LastOrDefaultAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var lastOrDefaultAsync = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .LastOrDefaultAsync(filter, cancellationToken);

        return lastOrDefaultAsync;
    }

    #endregion

    #region Any

    public virtual bool Any(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var any = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .Any(filter);

        return any;
    }

    public virtual async Task<bool> AnyAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var anyAsync = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .AnyAsync(filter, cancellationToken);

        return anyAsync;
    }

    #endregion

    #region All

    public virtual bool All(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var all = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .All(filter);

        return all;
    }

    public virtual async Task<bool> AllAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default)
    {
        var allAsync = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .AllAsync(filter, cancellationToken);

        return allAsync;
    }

    #endregion

    #region Min

    public virtual TBaseEntity? Min(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var min = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .Min();

        return min;
    }

    public virtual async Task<TBaseEntity?> MinAsync(bool? includeDeleted = false,
        CancellationToken cancellationToken = default)
    {
        var minAsync = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .MinAsync(cancellationToken);

        return minAsync;
    }

    public virtual TBaseEntity? MinBy<TKey>(
        Expression<Func<TBaseEntity,TKey>> keySelector,
        bool? includeDeleted = false)
    {
        var min = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .MinBy(keySelector);

        return min;
    }

    #endregion

    #region Max



    #endregion

    #region Average



    #endregion

    #region Sum



    #endregion

    #region Count



    #endregion

    //count
    //max
    //maxby
    //avg
    //orderby
    //orderbydescending
    //select
    //selectmany
    //sum
    //to list
    //to array
    //to dictionary
    //takewhile
    //to lookup



    public virtual async Task<TBaseEntity?> GetByIDAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }


    public virtual async Task<TBaseEntity?> GetByUniqueIdAsync(string id)
    {
        return await _dbSet.FirstAsync(o => o.UniqueId == id);
    }

    public virtual async Task InsertAsync(TBaseEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task InsertRangeAsync(IEnumerable<TBaseEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public virtual async void Delete(int id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);
        Delete(entityToDelete);
    }

    public virtual async void Delete(string uniqueId)
    {
        var entityToDelete = await _dbSet.FirstAsync(e => e.UniqueId == uniqueId);
        Delete(entityToDelete);
    }

    public virtual void Delete(TBaseEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public virtual void DeleteRange(IEnumerable<TBaseEntity> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public virtual void Update(TBaseEntity entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void UpdateRange(IEnumerable<TBaseEntity> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public virtual void Attach(TBaseEntity entity)
    {
        if (context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
    }

    public virtual void AttachRange(IEnumerable<TBaseEntity> entities)
    {
        _dbSet.AttachRange(entities);
    }

    public virtual async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}
