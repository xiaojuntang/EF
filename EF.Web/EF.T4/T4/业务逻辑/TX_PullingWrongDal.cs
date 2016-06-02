

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// TX_PullingWrong 操作类
    /// </summary>
	public partial class TX_PullingWrongDal
	{
		

		public static TX_PullingWrong Select()
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM TX_PullingWrong WHERE  ")
					                    .QuerySingle<TX_PullingWrong>();
            }
		}

		public static List<TX_PullingWrong> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<TX_PullingWrong> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<TX_PullingWrong> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<TX_PullingWrong>(" * ")
                    .From(" TX_PullingWrong ");

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
                return context.Sql(" SELECT COUNT(*) FROM TX_PullingWrong ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(TX_PullingWrong tX_PullingWrong) 
        {
            using (var context =db.Context())
            {
                return context.Insert<TX_PullingWrong>("TX_PullingWrong", tX_PullingWrong)
					.Execute() > 0;
            }
        }
		public static bool Update(TX_PullingWrong tX_PullingWrong)
        {
            using (var context = db.Context())
            {
                return context.Update<TX_PullingWrong>("TX_PullingWrong", tX_PullingWrong)
                    .AutoMap(x => )
					                    .Execute() > 0;
            }
        }

		public static bool Delete(TX_PullingWrong tX_PullingWrong) 
        {
            return Delete();
        }

        public static bool Delete()
        {
            using (var context = db.Context())
            {
                return context.Sql(" DELETE FROM Product WHERE  ")
                                        .Execute() > 0;
            }
        }
	}
	
}
	
