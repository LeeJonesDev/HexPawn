using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HexPawn.Data.Repositories;

public class Repository<TBaseEntity>(DbContext context)
    where TBaseEntity : class
{
    private readonly DbSet<TBaseEntity> _dbSet = context.Set<TBaseEntity>();
    private static readonly char[] separator = [','];

    public virtual IEnumerable<TBaseEntity> Get(
        Expression<Func<TBaseEntity, bool>> filter = null,
        Func<IQueryable<TBaseEntity>, IOrderedQueryable<TBaseEntity>> orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TBaseEntity> query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = includeProperties
            .Split(separator, StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty));

        return orderBy != null ? orderBy(query).ToList() : query.ToList();
    }

    public virtual async Task<TBaseEntity> GetByIDAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async void InsertAsync(TBaseEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async void InsertRangeAsync(IEnumerable<TBaseEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public virtual async void Delete(object id)
    {
        var entityToDelete = await _dbSet.FindAsync(id);
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

    public virtual void AsNoTracking()
    {
        _dbSet.AsNoTracking();
    }

    public virtual void AsTracking()
    {
        _dbSet.AsTracking();
    }

    public virtual async void SaveChangesAsync()
    {
        await context.SaveChangesAsync();
    }
}
