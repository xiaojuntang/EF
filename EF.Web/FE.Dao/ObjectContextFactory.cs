using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace FE.Dao
{
    public class ObjectContextFactory
    {
        public static ObjectContext GetCurrentObjectContext()
        {
            //从CallContext数据槽中获取EF上下文
            ObjectContext objectContext = CallContext.GetData(typeof(ObjectContextFactory).FullName) as ObjectContext;
            if (objectContext == null)
            {
                //如果CallContext数据槽中没有EF上下文，则创建EF上下文，并保存到CallContext数据槽中
                //objectContext = new ModelContainer();//当数据库替换为MySql等，只要在次出EF更换上下文即可。
                CallContext.SetData(typeof(ObjectContextFactory).FullName, objectContext);
            }
            return objectContext;
        }
    }


    public class EFContextFactory
    {
        //帮我们返回当前线程内的数据库上下文，如果当前线程内没有上下文，那么创建一个上下文，并保证
        //上线问实例在线程内部是唯一的
        public static DbContext GetCurrentDbContext()
        {
            //CallContext：是线程内部唯一的独用的数据槽（一块内存空间）
            //传递DbContext进去获取实例的信息，在这里进行强制转换。
            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;
            if (dbContext == null)  //线程在数据槽里面没有此上下文
            {
                string conn = "Data Source=36.110.49.104;Initial Catalog=TX_HomeWork;User ID=Zxxk;Password=qw3e4t5-9o$9r^THeb6y5;";
                dbContext = new DbContext("name=DbContext");//new DataModelContainer(); //如果不存在上下文的话，创建一个EF上下文
                //我们在创建一个，放到数据槽中去
                CallContext.SetData("DbContext", dbContext);
            }
            return dbContext;
        }
    }
}
