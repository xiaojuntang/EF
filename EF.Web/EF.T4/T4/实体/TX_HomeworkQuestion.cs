
using System;
using System.Collections.Generic;
namespace EF.Domain
{	
	/// <summary>
	/// 实体-TX_HomeworkQuestion 
	/// </summary>
	public partial class TX_HomeworkQuestion    
	{	
		/// <summary> ///   /// <summary> public int HQID { get; set; }
          /// <summary> /// 作业ID  /// <summary> public int HomeWorkID { get; set; }
          /// <summary> /// 试题ID  /// <summary> public int QuesID { get; set; }
          /// <summary> /// 试题序号  /// <summary> public int OrderNumber { get; set; }
          /// <summary> /// 试题分数  /// <summary> public decimal QuesScores { get; set; }
          /// <summary> /// 父试题ID  /// <summary> public int ParentQuesID { get; set; }
	}
}
	
