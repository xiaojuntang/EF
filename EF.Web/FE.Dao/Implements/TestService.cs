using EF.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FE.Dao
{
    /// <summary>
    /// 测试对象
    /// </summary>
    public class TestService : BaseRepository<T_Test>
    {
        public TestService() : base(new HomeWorkContext()) { }

        /// <summary>
        /// 执行SQL
        /// </summary>
        public void ExecSql()
        {
            List<SqlParameter> parameters = new List<SqlParameter>(){
                new SqlParameter("@Id", 2)
            };
            var t2 = context.Database.SqlQuery<T_Test>("SELECT * FROM T_Test WHERE ID = @Id", parameters.ToArray()).ToList();
        }

        /// <summary>
        /// 测试连表查询方法
        /// </summary>
        /// <returns></returns>
        public List<DtoUser> GetDtoTest()
        {
            return context.Database.SqlQuery<DtoUser>("select * from T_Test a,TX_PullingWrong b", new SqlParameter("@Id", 2)).ToList();
        }

        /// <summary>
        /// 联合查询
        /// </summary>
        public void JoinTest()
        {
            var b = (from p in context.T_Test
                     where p.ID == 3
                     select p).ToList();

            var data = context.TX_PullingWrong.GroupJoin(context.T_Test, c => c.WrongID, p => p.ID, (c, p) => new { CategoryID = c.WrongID, ProductList = p });
            var aa = context.TX_PullingWrong.Join(context.T_Test, e => e.WrongID, o => o.ID, (e, o) => new { a = o.Name, e.QuesId });
            var ddd = aa.ToList();
        }
    }
}
