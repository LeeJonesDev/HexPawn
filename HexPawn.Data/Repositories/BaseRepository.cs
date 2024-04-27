using HexPawn.Configuration.Database;
using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HexPawn.Data.Repositories;

public class BaseRepository<T>(ApplicationDbContext applicationDbContext) : IBaseRepository<T>
    where T : BaseEntity
{
    private readonly DbSet<BaseEntity> DataSet = applicationDbContext.Set<BaseEntity>();


    public virtual IQueryable<T>? Id(int id) => DataSet.Where(entity => entity.Id == id) as IQueryable<T>;
    public virtual IQueryable<T>? UniqueId(int uniqueId) => DataSet.Where(entity => entity.Id == uniqueId) as IQueryable<T>;
    public virtual IQueryable<T>? All() => DataSet as IQueryable<T>;

    public virtual async Task<EntityEntry<BaseEntity>> CreateAsync(BaseEntity entity) => await DataSet.AddAsync(entity);
    public virtual EntityEntry<BaseEntity> Update(T entity) => DataSet.Update(entity);
    public virtual EntityEntry<BaseEntity> Delete(T entity) => DataSet.Remove(entity);
    public virtual void DeleteRange(IEnumerable<T> entities) => DataSet.RemoveRange(entities);
}
