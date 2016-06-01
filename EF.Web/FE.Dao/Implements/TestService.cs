using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

        /// <summary>
        /// 执行SQL
        /// </summary>
        public void GetSql()
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@id", 2)
            };
            var t2 = context.Database.SqlQuery<T_Test>("SELECT * FROM T_Test WHERE ID = @id", parameters.ToArray()).ToList();
        }

        /// <summary>
        /// 测试连表查询方法
        /// </summary>
        /// <returns></returns>
        public List<DtoUser> GetDtoTest()
        {
            return context.Database.SqlQuery<DtoUser>("select * from T_Test a,TX_PullingWrong b", new SqlParameter("@id", 2)).ToList();
        }
    }
}
