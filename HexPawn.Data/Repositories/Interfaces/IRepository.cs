using System.Linq.Expressions;
using HexPawn.Models;

namespace HexPawn.Data.Repositories.Interfaces;

public interface IRepository<TBaseEntity> where TBaseEntity : BaseEntity
{
    #region Where

    IQueryable<TBaseEntity>
            Where(Expression<Func<TBaseEntity, bool>> filter,
                bool? includeDeleted = false);

    #endregion

    #region First

    TBaseEntity First(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false);

    TBaseEntity? FirstOrDefault(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false);

    Task<TBaseEntity> FirstAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default);

    Task<TBaseEntity?> FirstOrDefaultAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default);


    #endregion

    #region Single

    TBaseEntity Single(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false);

    TBaseEntity? SingleOrDefault(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false);

    Task<TBaseEntity> SingleAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default);

    Task<TBaseEntity?> SingleOrDefaultAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default);

    #endregion

    #region Last

    TBaseEntity Last(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false);

    TBaseEntity? LastOrDefault(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false);

    Task<TBaseEntity> LastAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default);

    Task<TBaseEntity?> LastOrDefaultAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default);

    #endregion

    #region Any

    bool Any(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false);

    Task<bool> AnyAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default);

    #endregion

    #region All

    bool All(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false);

    Task<bool> AllAsync(Expression<Func<TBaseEntity, bool>> filter,
        bool? includeDeleted = false, CancellationToken cancellationToken = default);

    #endregion

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
