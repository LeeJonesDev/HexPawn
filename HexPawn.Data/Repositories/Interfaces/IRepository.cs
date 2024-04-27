using System.Linq.Expressions;
using HexPawn.Models;

namespace HexPawn.Data.Repositories.Interfaces;

public interface IRepository<TBaseEntity> where TBaseEntity : BaseEntity
{
    IEnumerable<TBaseEntity> Get(
        Expression<Func<TBaseEntity, bool>> filter = null,
        Func<IQueryable<TBaseEntity>, IOrderedQueryable<TBaseEntity>> orderBy = null,
        string includeProperties = "");
    Task<TBaseEntity> GetByIDAsync(object id);
    void InsertAsync(TBaseEntity entity);
    void InsertRangeAsync(IEnumerable<TBaseEntity> entities);
    void Delete(object id);
    void Delete(TBaseEntity entity);
    void DeleteRange(IEnumerable<TBaseEntity> entities);
    void Update(TBaseEntity entity);
    void UpdateRange(IEnumerable<TBaseEntity> entities);
    void Attach(TBaseEntity entity);
    void AttachRange(IEnumerable<TBaseEntity> entities);
    void AsNoTracking();
    void AsTracking();
    void SaveChangesAsync();
}
