

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// HW_NodeCategoryTj 操作类
    /// </summary>
	public partial class HW_NodeCategoryTjDal
	{
		

		public static HW_NodeCategoryTj Select()
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM HW_NodeCategoryTj WHERE  ")
					                    .QuerySingle<HW_NodeCategoryTj>();
            }
		}

		public static List<HW_NodeCategoryTj> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<HW_NodeCategoryTj> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<HW_NodeCategoryTj> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<HW_NodeCategoryTj>(" * ")
                    .From(" HW_NodeCategoryTj ");

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
                return context.Sql(" SELECT COUNT(*) FROM HW_NodeCategoryTj ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(HW_NodeCategoryTj hW_NodeCategoryTj) 
        {
            using (var context =db.Context())
            {
                return context.Insert<HW_NodeCategoryTj>("HW_NodeCategoryTj", hW_NodeCategoryTj)
					.Execute() > 0;
            }
        }
		public static bool Update(HW_NodeCategoryTj hW_NodeCategoryTj)
        {
            using (var context = db.Context())
            {
                return context.Update<HW_NodeCategoryTj>("HW_NodeCategoryTj", hW_NodeCategoryTj)
                    .AutoMap(x => )
					                    .Execute() > 0;
            }
        }

		public static bool Delete(HW_NodeCategoryTj hW_NodeCategoryTj) 
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
	
