

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// T_Test 操作类
    /// </summary>
	public partial class T_TestDal
	{
		

		public static T_Test Select(Int32 iD)
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM T_Test WHERE ID = @id ")
					.Parameter("id", iD)
                    .QuerySingle<T_Test>();
            }
		}

		public static List<T_Test> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<T_Test> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<T_Test> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<T_Test>(" * ")
                    .From(" T_Test ");

                if (maximumRows > 0)
                {
                    if (startRowIndex == 0) 
                        startRowIndex = 1;

                    select.Paging(startRowIndex, maximumRows);
                }

                if (!string.IsNullOrEmpty(sortExpression))
                    select.OrderBy(sortExpression);

                return select.QueryMany();
            }
        }

		public static int CountAll()
        {
            using (var context = db.Context())
            {
                return context.Sql(" SELECT COUNT(*) FROM T_Test ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(T_Test t_Test) 
        {
            using (var context = db.Context())
            {
                int id = context.Insert<T_Test>("T_Test", t_Test)
                    .AutoMap(x => x.ID)
                    .ExecuteReturnLastId<int>();

                t_Test.ID = id;
                return id > 0;
            }
        }
		public static bool Update(T_Test t_Test)
        {
            using (var context = db.Context())
            {
                return context.Update<T_Test>("T_Test", t_Test)
                    .AutoMap(x => x.ID)
										.Where("ID", t_Test.ID)
					                    .Execute() > 0;
            }
        }

		public static bool Delete(T_Test t_Test) 
        {
            return Delete(t_Test.ID);
        }

        public static bool Delete(Int32 iD)
        {
            using (var context = db.Context())
            {
                return context.Sql(" DELETE FROM Product WHERE ID = @id ")
                    .Parameter("id", iD)
                    .Execute() > 0;
            }
        }
	}
	
}
	
