using EF.Bll;
using EF.Domain;
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
   ITestBll _test = new TestBll();



         
            T_Test t = new T_Test();
            t.ID = 10;
            t.Name = "6666";
            t.Money = Convert.ToDecimal(152.33);
            t.MyDate = DateTime.Now;
            t.IsTrue = false;
            var dd = _test.Add(t);
        }
    }
}
