using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Dao
{
    /// <summary>
    /// 公共仓储接口类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// 新增对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        TEntity AddEntity(TEntity entity);
        /// <summary>
        /// 批量更新记录
        /// </summary>
        /// <param name="entitys"></param>
        int BulkInsert(List<TEntity> entitys);
        /// <summary>
        /// 更新对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateEntity(TEntity entity);
        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(TEntity entity);
        /// <summary>
        /// 通过ID删除对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(int Id);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        bool Delete(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 获取对象列表
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindList(Func<TEntity, bool> whereLambda);
        /// <summary>
        /// 分页加载数据
        /// </summary>
        /// <param name="whereLambda">过滤条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        IQueryable<TEntity> FindPageList(Func<TEntity, bool> whereLambda, int pageIndex, int pageSize, out int totalCount);
        /// <summary>
        /// 分页获取对象列表
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <param name="whereLambda"></param>
        /// <param name="isAsc"></param>
        /// <param name="orderByLambda"></param>
        /// <returns></returns>
        IQueryable<TEntity> FindPageList<S>(int pageIndex, int pageSize, out int total, Func<TEntity, bool> whereLambda, bool isAsc, Func<TEntity, S> orderByLambda);
    }
}
