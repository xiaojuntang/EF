

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// HW_CategoryQuestion 操作类
    /// </summary>
	public partial class HW_CategoryQuestionDal
	{
		

		public static HW_CategoryQuestion Select()
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM HW_CategoryQuestion WHERE  ")
					                    .QuerySingle<HW_CategoryQuestion>();
            }
		}

		public static List<HW_CategoryQuestion> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<HW_CategoryQuestion> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<HW_CategoryQuestion> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<HW_CategoryQuestion>(" * ")
                    .From(" HW_CategoryQuestion ");

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
                return context.Sql(" SELECT COUNT(*) FROM HW_CategoryQuestion ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(HW_CategoryQuestion hW_CategoryQuestion) 
        {
            using (var context =db.Context())
            {
                return context.Insert<HW_CategoryQuestion>("HW_CategoryQuestion", hW_CategoryQuestion)
					.Execute() > 0;
            }
        }
		public static bool Update(HW_CategoryQuestion hW_CategoryQuestion)
        {
            using (var context = db.Context())
            {
                return context.Update<HW_CategoryQuestion>("HW_CategoryQuestion", hW_CategoryQuestion)
                    .AutoMap(x => )
					                    .Execute() > 0;
            }
        }

		public static bool Delete(HW_CategoryQuestion hW_CategoryQuestion) 
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
	
