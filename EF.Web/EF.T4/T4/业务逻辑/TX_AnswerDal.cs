

using System;
using System.Collections.Generic;
using MY.Model;
namespace MY.BLL
{	
	
	/// <summary>
    /// TX_Answer 操作类
    /// </summary>
	public partial class TX_AnswerDal
	{
		

		public static TX_Answer Select(Int32 answerID)
		{
			using(var context = db.Context())
            {
                return context.Sql(" SELECT * FROM TX_Answer WHERE AnswerID = @answerid ")
					.Parameter("answerid", answerID)
                    .QuerySingle<TX_Answer>();
            }
		}

		public static List<TX_Answer> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public static List<TX_Answer> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public static List<TX_Answer> SelectAll(int startRowIndex, int maximumRows, string sortExpression)
        {
            using (var context = db.Context())
            {
                var select = context.Select<TX_Answer>(" * ")
                    .From(" TX_Answer ");

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
                return context.Sql(" SELECT COUNT(*) FROM TX_Answer ")
                    .QuerySingle<int>();
            }
        }

		
		public static bool Insert(TX_Answer tX_Answer) 
        {
            using (var context = db.Context())
            {
                int id = context.Insert<TX_Answer>("TX_Answer", tX_Answer)
                    .AutoMap(x => x.AnswerID)
                    .ExecuteReturnLastId<int>();

                tX_Answer.AnswerID = id;
                return id > 0;
            }
        }
		public static bool Update(TX_Answer tX_Answer)
        {
            using (var context = db.Context())
            {
                return context.Update<TX_Answer>("TX_Answer", tX_Answer)
                    .AutoMap(x => x.AnswerID)
										.Where("AnswerID", tX_Answer.AnswerID)
					                    .Execute() > 0;
            }
        }

		public static bool Delete(TX_Answer tX_Answer) 
        {
            return Delete(tX_Answer.AnswerID);
        }

        public static bool Delete(Int32 answerID)
        {
            using (var context = db.Context())
            {
                return context.Sql(" DELETE FROM Product WHERE AnswerID = @answerid ")
                    .Parameter("answerid", answerID)
                    .Execute() > 0;
            }
        }
	}
	
}
	
