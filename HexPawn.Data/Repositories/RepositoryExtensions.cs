
using System.Linq.Expressions;
using HexPawn.Models;

namespace HexPawn.Data.Repositories;

public static class RepositoryExtensions
{
    /// <summary>
    /// Filter a query for BaseEntities by date
    /// ex: .Where(a => filterByDate<A>(dateTime)
    /// ex: .Where(a => filterByDate<A>(dateTime, includeDeleted: true)
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="includeDeleted"></param>
    /// <typeparam name="TBaseEntity"></typeparam>
    /// <returns></returns>
    public static Expression<Func<BaseEntity, bool>> FilterByDate<TBaseEntity>
        (DateTime dateTime, bool? includeDeleted = false) where TBaseEntity : BaseEntity
    {
        Expression<Func<BaseEntity, bool>> expression = x =>
            (x.DeletedAt == null && x.UpdatedOn >= dateTime)
            || (
                includeDeleted.HasValue &&
                !includeDeleted.Value &&
                x.DeletedAt != null &&
                x.DeletedAt >= dateTime);

        return expression;
    }


    public static Expression<Func<TBaseEntity, bool>> FilterSoftDeletes<TBaseEntity>
        (bool? includeDeleted = false) where TBaseEntity : BaseEntity
    {
        Expression<Func<TBaseEntity, bool>> expression = be =>
            (
                includeDeleted.HasValue &&
                includeDeleted.Value == true &&
                be.DeletedAt != null
            )
            ||
            !includeDeleted.HasValue ||
            (
                !includeDeleted.Value &&
                be.DeletedAt == null
            );

        return expression;
    }
}
