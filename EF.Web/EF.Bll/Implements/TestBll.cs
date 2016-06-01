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

            var ss = service.Delete(p => p.Name.Trim() == "ddd");
            var s = service.FindList(p => p.Name.Equals("ddd")).ToList<T_Test>();

            return service.AddEntity(model);
        }
    }
}
