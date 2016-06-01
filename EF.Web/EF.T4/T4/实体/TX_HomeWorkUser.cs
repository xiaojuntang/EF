
using System;
using System.Collections.Generic;
namespace EF.Domain
{	
	/// <summary>
	/// 实体-TX_HomeWorkUser 
	/// </summary>
	public partial class TX_HomeWorkUser    
	{	
		/// <summary> ///   /// <summary> public int ID { get; set; }
          /// <summary> /// 作业ID  /// <summary> public int HomeWorkID { get; set; }
          /// <summary> /// QQID  /// <summary> public string OpenID { get; set; }
          /// <summary> /// 开始日期  /// <summary> public DateTime StartDate { get; set; }
          /// <summary> /// 结束日期  /// <summary> public DateTime EndDate { get; set; }
          /// <summary> /// 总时长  /// <summary> public string AnswerTime { get; set; }
          /// <summary> /// 平均时长  /// <summary> public string AnswerAvgTime { get; set; }
	}
}
	
