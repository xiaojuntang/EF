

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// HW_NodeCategory 操作类
    /// </summary>
	public partial class HW_NodeCategoryDal
	{
		

		public static HW_NodeCategory Select()
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM HW_NodeCategory WHERE  ")
					                    .QuerySingle<HW_NodeCategory>();
            }
		}

		public static List<HW_NodeCategory> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<HW_NodeCategory> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<HW_NodeCategory> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<HW_NodeCategory>(" * ")
                    .From(" HW_NodeCategory ");

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
                return context.Sql(" SELECT COUNT(*) FROM HW_NodeCategory ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(HW_NodeCategory hW_NodeCategory) 
        {
            using (var context =db.Context())
            {
                return context.Insert<HW_NodeCategory>("HW_NodeCategory", hW_NodeCategory)
					.Execute() > 0;
            }
        }
		public static bool Update(HW_NodeCategory hW_NodeCategory)
        {
            using (var context = db.Context())
            {
                return context.Update<HW_NodeCategory>("HW_NodeCategory", hW_NodeCategory)
                    .AutoMap(x => )
					                    .Execute() > 0;
            }
        }

		public static bool Delete(HW_NodeCategory hW_NodeCategory) 
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
	
