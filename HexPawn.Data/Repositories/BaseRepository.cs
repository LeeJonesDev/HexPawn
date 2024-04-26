using HexPawn.Configuration.Database;
using HexPawn.Data.Repositories.Interfaces;
using HexPawn.Models;
using Microsoft.EntityFrameworkCore;

namespace HexPawn.Data.Repositories;

public class BaseRepository<T>(ApplicationDbContext applicationDbContext) : IBaseRepository<T>
    where T : BaseEntity
{
    protected readonly ApplicationDbContext _applicationDbContext = applicationDbContext;
    private readonly DbSet<BaseEntity> DataSet = applicationDbContext.Set<BaseEntity>();

    public virtual T? FirstOrDefaultId(int? id, bool isNoTracking = false) => FirstOrDefaultByIds(id, null, isNoTracking);

    public virtual T? FirstOrDefaultUniqueId(Guid? uniqueId, bool isNoTracking = false) => FirstOrDefaultByIds(null, uniqueId, isNoTracking);

    public virtual IQueryable<T>? All(bool isNoTracking = false) => Get(null, null, isNoTracking);

    public virtual async Task CreateAsync(BaseEntity entity) => await DataSet.AddAsync(entity);


    #region Private Methods

    private IQueryable<T>? Get(int? id, Guid? uniqueId, bool isNoTracking = false)
    {
        var results = isNoTracking
            ? DataSet.AsNoTracking()
            : DataSet;

        results = results
                .Where(x =>
                    (id == null && uniqueId == null) ||
                    (x.UniqueId == null && x.Id.Equals(id)) ||
                    (x.Id == null && x.UniqueId != null && x.UniqueId.Equals(uniqueId)) ||
                    (x.Id == id && x.UniqueId == uniqueId.ToString()))
            as IQueryable<T>;

        return results as IQueryable<T>;
    }

    private T? FirstOrDefaultByIds(int? id, Guid? uniqueId, bool isNoTracking = false)
    {
        if (id == null && uniqueId == null)
        {
            throw new ArgumentException("An identifier is required, either Id or UniqueId as a parameter");
        }

        var collection = Get(id, uniqueId, isNoTracking);

        return collection.FirstOrDefault();
    }

    #endregion



}
