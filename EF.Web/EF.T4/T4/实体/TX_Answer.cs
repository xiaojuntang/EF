
using System;
using System.Collections.Generic;
namespace EF.Domain
{	
	/// <summary>
	/// 实体-TX_Answer 
	/// </summary>
	public partial class TX_Answer    
	{	
		/// <summary> /// 答案ID  /// <summary> public int AnswerID { get; set; }
          /// <summary> /// 作业ID  /// <summary> public int HomeWorkID { get; set; }
          /// <summary> /// QQID  /// <summary> public string OpenID { get; set; }
          /// <summary> /// 试题ID  /// <summary> public int QuesID { get; set; }
          /// <summary> /// 试题类型  /// <summary> public int QuesTypeID { get; set; }
          /// <summary> /// 正确答案 客观题全是A  /// <summary> public string QuesAnswer { get; set; }
          /// <summary> /// 用户答案  /// <summary> public string StudentAnswer { get; set; }
          /// <summary> /// 提交日期  /// <summary> public DateTime CommitDate { get; set; }
          /// <summary> /// 知识点ID  /// <summary> public int CategoryID { get; set; }
          /// <summary> /// 知识点名称  /// <summary> public string CategoryName { get; set; }
          /// <summary> /// 分数  /// <summary> public decimal Score { get; set; }
          /// <summary> /// 父试题ID  /// <summary> public int ParentQuesID { get; set; }
          /// <summary> /// 试题数量  /// <summary> public int QuesNumber { get; set; }
          /// <summary> /// 腾讯ID  /// <summary> public string TencentID { get; set; }
          /// <summary> /// 试题顺序  /// <summary> public int OrderNumber { get; set; }
	}
}
	
