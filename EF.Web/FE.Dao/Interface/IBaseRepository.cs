using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Dao
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        TEntity AddEntity(TEntity entity);

        bool UpdateEntity(TEntity entity);

        bool DeleteEntity(TEntity entity);

        IQueryable<TEntity> LoadEntities(Func<TEntity, bool> whereLambda);

        IQueryable<TEntity> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<TEntity, bool> whereLambda, bool isAsc, Func<TEntity, S> orderByLambda);
    }
}
