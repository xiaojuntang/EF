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
            return service.AddEntity(model);
        }
    }
}
