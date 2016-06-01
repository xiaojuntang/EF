using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Dao
{
    public class EngineContext : DbContext
    {
        public EngineContext() : base("DbContext")
        {
        }

        public DbSet<T_Test> SysTest { get; set; }
    }
}
