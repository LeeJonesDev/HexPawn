using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HexPawn.Data.Repositories;

public static class RepositoryExtensions
{
    public static IQueryable<TEntity> Include<TEntity>(this DbSet<TEntity> dbSet,
        params Expression<Func<TEntity, object>>[] includes)
        where TEntity : class
    {
        IQueryable<TEntity> query = null;
        foreach (var include in includes)
        {
            query = dbSet.Include(include);
        }

        return query ?? dbSet;
    }
}
