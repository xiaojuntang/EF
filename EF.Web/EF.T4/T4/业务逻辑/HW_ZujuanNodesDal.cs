

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// HW_ZujuanNodes 操作类
    /// </summary>
	public partial class HW_ZujuanNodesDal
	{
		

		public static HW_ZujuanNodes Select()
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM HW_ZujuanNodes WHERE  ")
					                    .QuerySingle<HW_ZujuanNodes>();
            }
		}

		public static List<HW_ZujuanNodes> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<HW_ZujuanNodes> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<HW_ZujuanNodes> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<HW_ZujuanNodes>(" * ")
                    .From(" HW_ZujuanNodes ");

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
                return context.Sql(" SELECT COUNT(*) FROM HW_ZujuanNodes ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(HW_ZujuanNodes hW_ZujuanNodes) 
        {
            using (var context =db.Context())
            {
                return context.Insert<HW_ZujuanNodes>("HW_ZujuanNodes", hW_ZujuanNodes)
					.Execute() > 0;
            }
        }
		public static bool Update(HW_ZujuanNodes hW_ZujuanNodes)
        {
            using (var context = db.Context())
            {
                return context.Update<HW_ZujuanNodes>("HW_ZujuanNodes", hW_ZujuanNodes)
                    .AutoMap(x => )
					                    .Execute() > 0;
            }
        }

		public static bool Delete(HW_ZujuanNodes hW_ZujuanNodes) 
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
	
