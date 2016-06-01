using EF.Domain;
using FE.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EF.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWorkContext db = new HomeWorkContext();
            T_Test t1 = new T_Test();
            t1.Name = "ddd";
            t1.MyDate = DateTime.Now;
            t1.Money = Convert.ToDecimal(1235.2);
            t1.IsTrue = true;
            //t1.ID = 5;
            //db.Entry<T_Test>(t1).State = EntityState.Added;
            db.T_Test.Add(t1);

            //下面的写法统一
            db.SaveChanges();

            TestService _test = new TestService();

            T_Test t = new T_Test();
            t.Name = "ddd";
            t.MyDate = DateTime.Now;
            t.Money = Convert.ToDecimal(1235.2);
            t.IsTrue = true;
            t.ID = 5;
            _test.AddEntity(t);

        }
    }
}
