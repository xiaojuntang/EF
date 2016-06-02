

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// TX_HomeWorkUser 操作类
    /// </summary>
	public partial class TX_HomeWorkUserDal
	{
		

		public static TX_HomeWorkUser Select()
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM TX_HomeWorkUser WHERE  ")
					                    .QuerySingle<TX_HomeWorkUser>();
            }
		}

		public static List<TX_HomeWorkUser> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<TX_HomeWorkUser> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<TX_HomeWorkUser> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<TX_HomeWorkUser>(" * ")
                    .From(" TX_HomeWorkUser ");

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
                return context.Sql(" SELECT COUNT(*) FROM TX_HomeWorkUser ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(TX_HomeWorkUser tX_HomeWorkUser) 
        {
            using (var context =db.Context())
            {
                return context.Insert<TX_HomeWorkUser>("TX_HomeWorkUser", tX_HomeWorkUser)
					.Execute() > 0;
            }
        }
		public static bool Update(TX_HomeWorkUser tX_HomeWorkUser)
        {
            using (var context = db.Context())
            {
                return context.Update<TX_HomeWorkUser>("TX_HomeWorkUser", tX_HomeWorkUser)
                    .AutoMap(x => )
					                    .Execute() > 0;
            }
        }

		public static bool Delete(TX_HomeWorkUser tX_HomeWorkUser) 
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
	
