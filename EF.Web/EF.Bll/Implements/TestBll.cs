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
            var s = service.FindList(p => p.Name.Equals("ddd")).ToList<T_Test>();
            return service.AddEntity(model);
        }
    }
}
