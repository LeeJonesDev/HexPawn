using System.Linq.Expressions;
using HexPawn.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace HexPawn.Data.Repositories.Interfaces;

public interface IRepository<TBaseEntity> where TBaseEntity : BaseEntity
{
    IQueryable<TBaseEntity>?
        Where(Expression<Func<TBaseEntity, bool>> filter,
            bool? includeDeleted = false);
    
    
    
    // IOrderedQueryable<TBaseEntity>? Get2(
    //     Expression<Func<TBaseEntity, bool>>? filter = null,
    //     Func<IQueryable<TBaseEntity>, IOrderedQueryable<TBaseEntity>>? orderBy = null,
    //     Func<IQueryable<TBaseEntity>, IIncludableQueryable<TBaseEntity, object>>? include = null);

    // IQueryable<TBaseEntity> Get2(
    //     Expression<Func<TBaseEntity, bool>>? filter = null,
    //     Func<IQueryable<TBaseEntity>, IOrderedQueryable<TBaseEntity>>? orderBy = null);
    IEnumerable<TBaseEntity> Get(
        Expression<Func<TBaseEntity, bool>>? filter = null,
        Func<IQueryable<TBaseEntity>, IOrderedQueryable<TBaseEntity>>? orderBy = null,
        string? includeProperties = "");
    Task<TBaseEntity?> GetByIDAsync(int id);
    Task<TBaseEntity?> GetByUniqueIdAsync(string id);
    Task InsertAsync(TBaseEntity entity);
    Task InsertRangeAsync(IEnumerable<TBaseEntity> entities);
    void Delete(int id);
    void Delete(string uniqueId);
    void Delete(TBaseEntity entity);
    void DeleteRange(IEnumerable<TBaseEntity> entities);
    void Update(TBaseEntity entity);
    void UpdateRange(IEnumerable<TBaseEntity> entities);
    void Attach(TBaseEntity entity);
    void AttachRange(IEnumerable<TBaseEntity> entities);
    Task<int> SaveChangesAsync();
}
