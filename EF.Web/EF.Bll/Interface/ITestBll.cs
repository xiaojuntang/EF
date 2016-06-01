using EF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Bll
{
    public interface ITestBll
    {
        T_Test Add(T_Test model);
    }
}
