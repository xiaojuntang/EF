using EF.Domain;
using EntityFramework.BulkInsert.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Dao
{
    /// <summary>
    /// 实现对数据库的操作(增删改查)的基类
    /// </summary>
    /// <typeparam name="TEntity">约束类型</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal HomeWorkContext context;
        internal DbSet<TEntity> dbSet;

        /// <summary>
        /// 仓储对象
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(HomeWorkContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// 实现对数据库的添加功能,添加实现EF框架的引用
        /// </summary>
        /// <param name="entity">对象</param>
        /// <returns></returns>
        public TEntity AddEntity(TEntity entity)
        {
            //EF4.0的写法   添加实体
            //db.CreateObjectSet<T>().AddObject(entity);
            //EF5.0的写法
            context.Entry<TEntity>(entity).State = EntityState.Added;
            //下面的写法统一
            context.SaveChanges();
            return entity;
        }

        /// <summary>
        /// 批量新增记录
        /// </summary>
        /// <param name="entitys"></param>
        public int BulkInsert(List<TEntity> entitys)
        {
            context.BulkInsert(entitys);
            return context.SaveChanges();
        }

        /// <summary>
        /// 实现对数据库的修改功能
        /// </summary>
        /// <param name="entity">对象</param>
        /// <returns></returns>
        public bool UpdateEntity(TEntity entity)
        {
            //EF4.0的写法
            //db.CreateObjectSet<T>().Addach(entity);
            //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            //EF5.0的写法
            context.Set<TEntity>().Attach(entity);
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// 实现对数据库的删除功能
        /// </summary>
        /// <param name="entity">对象</param>
        /// <returns></returns>
        public bool DeleteEntity(TEntity entity)
        {
            //EF4.0的写法
            //db.CreateObjectSet<T>().Addach(entity);
            //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
            //EF5.0的写法
            context.Set<TEntity>().Attach(entity);
            context.Entry<TEntity>(entity).State = EntityState.Deleted;
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// 通过ID删除对象
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Delete(int Id)
        {
            TEntity entity = this.dbSet.Find(Id);
            return DeleteEntity(entity);
        }

        /// <summary>
        /// 删除多个对象
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public bool Delete(Func<TEntity, bool> whereLambda)
        {
            var tes = this.dbSet.Where(whereLambda).ToList();
            this.dbSet.RemoveRange(this.dbSet.Where(whereLambda));
            return context.SaveChanges() > 0;
        }

        /// <summary>
        /// 实现对数据库的查询  --简单查询
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindList(Func<TEntity, bool> whereLambda)
        {
            //EF4.0的写法
            //return db.CreateObjectSet<T>().Where<T>(whereLambda).AsQueryable();
            //EF5.0的写法
            return context.Set<TEntity>().Where<TEntity>(whereLambda).AsQueryable();
        }

        /// <summary>
        /// 分页加载数据
        /// </summary>
        /// <param name="whereLambda">过滤条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="totalCount">总记录数</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindPageList(Func<TEntity, bool> whereLambda, int pageIndex, int pageSize, out int totalCount)
        {
            var tmp = context.Set<TEntity>().Where<TEntity>(whereLambda);
            totalCount = tmp.Count();
            return tmp.Skip<TEntity>(pageSize * (pageIndex - 1))//跳过行数，最终生成的sql语句是Top(n)
                      .Take<TEntity>(pageSize) //返回指定数量的行
                      .AsQueryable<TEntity>();
        }

        /// <summary>
        /// 实现对数据的分页查询
        /// </summary>
        /// <typeparam name="S">按照某个类进行排序</typeparam>
        /// <param name="pageIndex">当前第几页</param>
        /// <param name="pageSize">一页显示多少条数据</param>
        /// <param name="total">总条数</param>
        /// <param name="whereLambda">取得排序的条件</param>
        /// <param name="isAsc">如何排序，根据倒叙还是升序</param>
        /// <param name="orderByLambda">根据那个字段进行排序</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindPageList<S>(int pageIndex, int pageSize, out int total, Func<TEntity, bool> whereLambda, bool isAsc, Func<TEntity, S> orderByLambda)
        {
            //EF4.0和上面的查询一样
            //EF5.0
            var temp = context.Set<TEntity>().Where<TEntity>(whereLambda);
            total = temp.Count(); //得到总的条数
            //排序,获取当前页的数据
            if (isAsc)
            {
                temp = temp.OrderBy<TEntity, S>(orderByLambda)
                     .Skip<TEntity>(pageSize * (pageIndex - 1)) //越过多少条
                     .Take<TEntity>(pageSize).AsQueryable(); //取出多少条
            }
            else
            {
                temp = temp.OrderByDescending<TEntity, S>(orderByLambda)
                    .Skip<TEntity>(pageSize * (pageIndex - 1)) //越过多少条
                    .Take<TEntity>(pageSize).AsQueryable(); //取出多少条
            }
            return temp.AsQueryable();
        }

        private bool disposed = false;

        /// <summary>
        /// 资料释放
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 资料释放
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
