using System.Data;
using System.Linq.Expressions;
using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models;
using Microsoft.EntityFrameworkCore;

namespace HexPawn.Data.Repositories;

public class Repository<TBaseEntity>(DbContext context) : IRepository<TBaseEntity> where TBaseEntity : BaseEntity
{
    private readonly DbSet<TBaseEntity>? _dbSet = context.Set<TBaseEntity>();

    /// <summary>
    /// Perform a Where filter on the dbset while respecting soft deletes
    /// </summary>
    /// <param name="filter"></param>
    /// <param name="includeDeleted"></param>
    /// <returns></returns>
    public virtual IQueryable<TBaseEntity> Where(Expression<Func<TBaseEntity, bool>> filter,
            bool? includeDeleted = false)
    {
        var queryable = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .Where(filter);

        return queryable;
    }

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
        var first = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .FirstOrDefault(filter);

        return first;
    }

    public virtual async Task<TBaseEntity> FirstAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .FirstAsync(filter);

        return first;
    }

    public virtual async Task<TBaseEntity?> FirstOrDefaultAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .FirstOrDefaultAsync(filter);

        return first;
    }

    #endregion

    #region Single

    public virtual TBaseEntity Single(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .Single(filter);

        return first;
    }

    public virtual TBaseEntity? SingleOrDefault(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .SingleOrDefault(filter);

        return first;
    }

    public virtual async Task<TBaseEntity> SingleAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .SingleAsync(filter);

        return first;
    }

    public virtual async Task<TBaseEntity?> SingleOrDefaultAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .SingleOrDefaultAsync(filter);

        return first;
    }

    #endregion

    #region Last

    public virtual TBaseEntity Last(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .Last(filter);

        return first;
    }

    public virtual TBaseEntity? LastOrDefault(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .LastOrDefault(filter);

        return first;
    }

    public virtual async Task<TBaseEntity> LastAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .LastAsync(filter);

        return first;
    }

    public virtual async Task<TBaseEntity?> LastOrDefaultAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false)
    {
        var first = await (_dbSet ?? throw new DataException("_dbSet should never be null"))
            .Where(RepositoryExtensions.FilterSoftDeletes<TBaseEntity>(includeDeleted))
            .LastOrDefaultAsync(filter);

        return first;
    }

    #endregion

    


    //any
    //count
    //all
    //contains


    //min
    //minby
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
