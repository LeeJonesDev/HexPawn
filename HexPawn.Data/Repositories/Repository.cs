using System.Linq.Expressions;
using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models;
using Microsoft.EntityFrameworkCore;

namespace HexPawn.Data.Repositories;

public class Repository<TBaseEntity>(DbContext context) : IRepository<TBaseEntity> where TBaseEntity : BaseEntity
{
    private readonly DbSet<TBaseEntity>? _dbSet = context.Set<TBaseEntity>();
    private static readonly char[] separator = [','];

    public virtual IEnumerable<TBaseEntity> Get(
        Expression<Func<TBaseEntity, bool>>? filter = null,
        Func<IQueryable<TBaseEntity>, IOrderedQueryable<TBaseEntity>>? orderBy = null,
        string? includeProperties = "")
    {
        IQueryable<TBaseEntity>? query = _dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        query = includeProperties?.Split(separator, StringSplitOptions.RemoveEmptyEntries)
            .Aggregate(query, (current, includeProperty) =>
                current.Include(includeProperty));

        return orderBy != null ? orderBy(query).ToList() : query.ToList();
    }

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
