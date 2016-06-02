using EF.Domain;
using Entities.Extensions;
using EntityFramework.BulkInsert.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

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
        /// 修改对象
        /// 例：T u = new T() { uId = 1, uLoginName = "asdfasdf" }; this.Modify(u, "uLoginName");
        /// </summary>
        /// <param name="entity">要修改的实体对象</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public int UpdateEntity(TEntity entity, params string[] proNames)
        {
            DbEntityEntry entry = context.Entry<TEntity>(entity);
            entry.State = EntityState.Unchanged;
            foreach (string proName in proNames)
            {
                entry.Property(proName).IsModified = true;
            }
            return context.SaveChanges();
        }

        /// <summary>
        /// 批量更新
        /// </summary>
        /// <param name="entity">要修改的实体对象</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="modifiedProNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public int Update(TEntity entity, Expression<Func<TEntity, bool>> whereLambda, params string[] modifiedProNames)
        {
            //查询要修改的数据             
            List<TEntity> listModifing = context.Set<TEntity>().Where(whereLambda).ToList();
            //获取 实体类 类型对象 
            Type t = typeof(TEntity); // model.GetType();             
            //获取 实体类 所有的 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            //创建 实体属性 字典集合              
            Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            //将 实体属性 中要修改的属性名 添加到 字典集合中 键：属性名  值：属性对象              
            proInfos.ForEach(p =>
            {
                if (modifiedProNames.Contains(p.Name))
                {
                    dictPros.Add(p.Name, p);
                }
            });
            //循环 要修改的属性名              
            foreach (string proName in modifiedProNames)
            {
                //判断 要修改的属性名是否在 实体类的属性集合中存在                 
                if (dictPros.ContainsKey(proName))
                {
                    //如果存在，则取出要修改的 属性对象                      
                    PropertyInfo proInfo = dictPros[proName];
                    //取出 要修改的值                      
                    object newValue = proInfo.GetValue(entity, null);
                    //object newValue = model.uName; 
                    //4.4批量设置 要修改 对象的 属性                      
                    foreach (TEntity usrO in listModifing)
                    {
                        //为 要修改的对象 的 要修改的属性 设置新的值                        
                        proInfo.SetValue(usrO, newValue, null);
                        //usrO.uName = newValue;                    
                    }
                }
            }
            //一次性 生成sql语句到数据库执行             
            return context.SaveChanges();
        }

        /// <summary>
        /// 更新满足条件的实体，返回更新实体的条数
        /// </summary>
        /// <param name="whereLambda">更新的条件</param>
        /// <param name="Updater">更新的值</param>
        /// <returns>int</returns>
        public int UpdateEntity(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, TEntity>> Updater)
        {
            ConditionBuilder Builder = new ConditionBuilder();
            Builder.Build(whereLambda.Body);
            string sqlCondition = Builder.Condition;
            //获取Update的赋值语句
            var updateMemberExpr = (MemberInitExpression)Updater.Body;
            var updateMemberCollection = updateMemberExpr.Bindings.Cast<MemberAssignment>().Select(c => new
            {
                Name = c.Member.Name,
                Value = ((ConstantExpression)c.Expression).Value
            });
            int i = Builder.Arguments.Length;
            string sqlUpdateBlock = string.Join(", ", updateMemberCollection.Select(c => string.Format("[{0}]={1}", c.Name, "{" + (i++) + "}")).ToArray());
            string commandText = string.Format("Update {0} Set {1} Where {2}", typeof(TEntity).Name, sqlUpdateBlock, sqlCondition);
            //获取SQL参数数组 (包括查询参数和赋值参数)
            var args = Builder.Arguments.Union(updateMemberCollection.Select(c => c.Value)).ToArray();
            var Result = context.Database.ExecuteSqlCommand(commandText, args);
            return Result;
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
        /// 删除满足条件的实体，返回删除实体的条数
        /// </summary>
        /// <param name="whereLambda">删除的条件</param>
        /// <returns>int</returns>
        public int DeleteEntity(Expression<Func<TEntity, bool>> whereLambda)
        {
            //查询条件表达式转换成SQL的条件语句
            ConditionBuilder Builder = new ConditionBuilder();
            Builder.Build(whereLambda.Body);
            string sqlCondition = Builder.Condition;
            //获取SQL参数数组
            var args = Builder.Arguments;
            var Result = context.Database.ExecuteSqlCommand("Delete From " + typeof(TEntity).Name + " Where " + sqlCondition, args);
            return Result;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DeleteByExp(Expression<Func<TEntity, bool>> delWhere)
        {
            //查询要删除的数据             
            List<TEntity> listDeleting = context.Set<TEntity>().Where(delWhere).ToList();
            //3.2将要删除的数据 用删除方法添加到 EF 容器中             
            listDeleting.ForEach(u =>
            {
                context.Set<TEntity>().Attach(u);//先附加到 EF容器                 
                context.Set<TEntity>().Remove(u);//标识为 删除 状态             
            });
            //一次性 生成sql语句到数据库执行删除             
            return context.SaveChanges();
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

            //延迟加载
            DbQuery<TEntity> result = dbSet.Where(whereLambda) as DbQuery<TEntity>;
            //时实加载
            //IQueryable<TEntity> result = context.Set<TEntity>().Where<TEntity>(whereLambda).AsQueryable();
            return result;
        }

        /// <summary>
        /// 获取排序列表
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <param name="order">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindList(Func<TEntity, bool> whereLambda, Func<TEntity, bool> order, bool isAsc)
        {
            DbQuery<TEntity> result;
            if (isAsc)
            {
                //延迟加载
                result = dbSet.Where(whereLambda).OrderBy(order) as DbQuery<TEntity>;
            }
            else
            {
                //延迟加载
                result = dbSet.Where(whereLambda).OrderByDescending(order) as DbQuery<TEntity>;
            }
            return result;
        }

        /// <summary>
        /// 获取排序列表
        /// </summary>
        /// <param name="whereLambda">条件</param>
        /// <param name="fileds">字段</param>
        /// <param name="order">排序字段</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        public IQueryable<TEntity> FindList(Func<TEntity, bool> whereLambda, Func<TEntity, bool> field, Func<TEntity, bool> order, bool isAsc)
        {
            DbQuery<TEntity> result;
            if (isAsc)
            {
                //延迟加载
                result = dbSet.Where(whereLambda).OrderBy(order).Select(field) as DbQuery<TEntity>;
            }
            else
            {
                //延迟加载
                result = dbSet.Where(whereLambda).OrderByDescending(order).Select(field) as DbQuery<TEntity>;
            }
            return result;
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

        /// <summary>
        /// disposed
        /// </summary>
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
