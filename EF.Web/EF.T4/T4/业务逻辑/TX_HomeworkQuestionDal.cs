

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// TX_HomeworkQuestion 操作类
    /// </summary>
	public partial class TX_HomeworkQuestionDal
	{
		

		public static TX_HomeworkQuestion Select()
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM TX_HomeworkQuestion WHERE  ")
					                    .QuerySingle<TX_HomeworkQuestion>();
            }
		}

		public static List<TX_HomeworkQuestion> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<TX_HomeworkQuestion> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<TX_HomeworkQuestion> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<TX_HomeworkQuestion>(" * ")
                    .From(" TX_HomeworkQuestion ");

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
                return context.Sql(" SELECT COUNT(*) FROM TX_HomeworkQuestion ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(TX_HomeworkQuestion tX_HomeworkQuestion) 
        {
            using (var context =db.Context())
            {
                return context.Insert<TX_HomeworkQuestion>("TX_HomeworkQuestion", tX_HomeworkQuestion)
					.Execute() > 0;
            }
        }
		public static bool Update(TX_HomeworkQuestion tX_HomeworkQuestion)
        {
            using (var context = db.Context())
            {
                return context.Update<TX_HomeworkQuestion>("TX_HomeworkQuestion", tX_HomeworkQuestion)
                    .AutoMap(x => )
					                    .Execute() > 0;
            }
        }

		public static bool Delete(TX_HomeworkQuestion tX_HomeworkQuestion) 
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
	
