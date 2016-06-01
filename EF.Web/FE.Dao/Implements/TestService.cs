using EF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Dao
{
    public class TestService : BaseRepository<T_Test>
    {
        public TestService() : base(new HomeWorkContext())
        {

        }

        public T_Test Add(T_Test model)
        {
            return AddEntity(model);
        }
    }
}
