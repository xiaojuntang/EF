using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Domain
{
    public partial class T_Test
    {
        public int Ext { get; set; }

        public int SExt
        {
            get
            {
                if (MyDate > DateTime.Now)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
