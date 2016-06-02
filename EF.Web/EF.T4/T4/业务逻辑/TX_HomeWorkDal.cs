

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// TX_HomeWork 操作类
    /// </summary>
	public partial class TX_HomeWorkDal
	{
		

		public static TX_HomeWork Select()
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM TX_HomeWork WHERE  ")
					                    .QuerySingle<TX_HomeWork>();
            }
		}

		public static List<TX_HomeWork> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<TX_HomeWork> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<TX_HomeWork> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<TX_HomeWork>(" * ")
                    .From(" TX_HomeWork ");

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
                return context.Sql(" SELECT COUNT(*) FROM TX_HomeWork ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(TX_HomeWork tX_HomeWork) 
        {
            using (var context =db.Context())
            {
                return context.Insert<TX_HomeWork>("TX_HomeWork", tX_HomeWork)
					.Execute() > 0;
            }
        }
		public static bool Update(TX_HomeWork tX_HomeWork)
        {
            using (var context = db.Context())
            {
                return context.Update<TX_HomeWork>("TX_HomeWork", tX_HomeWork)
                    .AutoMap(x => )
					                    .Execute() > 0;
            }
        }

		public static bool Delete(TX_HomeWork tX_HomeWork) 
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
	
