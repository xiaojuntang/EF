

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// TX_TencentMata 操作类
    /// </summary>
	public partial class TX_TencentMataDal
	{
		

		public static TX_TencentMata Select()
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM TX_TencentMata WHERE  ")
					                    .QuerySingle<TX_TencentMata>();
            }
		}

		public static List<TX_TencentMata> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<TX_TencentMata> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<TX_TencentMata> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<TX_TencentMata>(" * ")
                    .From(" TX_TencentMata ");

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
                return context.Sql(" SELECT COUNT(*) FROM TX_TencentMata ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(TX_TencentMata tX_TencentMata) 
        {
            using (var context =db.Context())
            {
                return context.Insert<TX_TencentMata>("TX_TencentMata", tX_TencentMata)
					.Execute() > 0;
            }
        }
		public static bool Update(TX_TencentMata tX_TencentMata)
        {
            using (var context = db.Context())
            {
                return context.Update<TX_TencentMata>("TX_TencentMata", tX_TencentMata)
                    .AutoMap(x => )
					                    .Execute() > 0;
            }
        }

		public static bool Delete(TX_TencentMata tX_TencentMata) 
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
	
