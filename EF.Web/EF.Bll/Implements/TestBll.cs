using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF.Domain;
using FE.Dao;

namespace EF.Bll
{
    public class TestBll : ITestBll
    {
        private TestService service;
        public TestBll()
        {
            service = new TestService();
        }

        public T_Test Add(T_Test model)
        {
            //1.1测试更新
            T_Test a_1 = new T_Test();
            a_1.ID = 3;
            a_1.Name = "我的1";
            a_1.IsTrue = false;
            //int z_1 = service.UpdateEntity(a_1, "IsTrue", "Name");

            //1.2测试批量更新
            T_Test a_2 = new T_Test();
            a_2.Name = "我的7";
            a_2.IsTrue = false;
            int z_2 = service.Update(a_2, p => p.ID <= 5, "Name", "IsTrue");


            service.JoinTest();
            List<T_Test> ts = new List<T_Test>();
            for (int i = 0; i < 1000000; i++)
            {
                T_Test t = new T_Test();
                t.ID = 10;
                t.Name = "6 " + i;
                t.Money = Convert.ToDecimal(152.33);
                t.MyDate = DateTime.Now;
                t.IsTrue = false;
                ts.Add(t);
            }
            DateTime s1 = DateTime.Now;


            int total = service.BulkInsert(ts);

            TimeSpan s2 = DateTime.Now - s1;

            string dddd = string.Format("{0}-{1}", s2.Minutes, s2.Seconds);




            var ss = service.Delete(p => p.Name.Trim() == "ddd");



            var s = service.FindList(p => p.Name.Equals("ddd") && p.ID == 1).ToList<T_Test>();


            return service.AddEntity(model);
        }
    }
}
