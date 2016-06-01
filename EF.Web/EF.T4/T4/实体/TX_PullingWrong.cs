
using System;
using System.Collections.Generic;
namespace EF.Domain
{	
	/// <summary>
	/// 实体-TX_PullingWrong 
	/// </summary>
	public partial class TX_PullingWrong    
	{	
		/// <summary> /// 错题ID  /// <summary> public int WrongID { get; set; }
          /// <summary> /// QQID  /// <summary> public string OpenId { get; set; }
          /// <summary> /// 试题ID  /// <summary> public int QuesId { get; set; }
          /// <summary> /// 错误类型  /// <summary> public string WrongType { get; set; }
          /// <summary> /// 备注  /// <summary> public string Remarks { get; set; }
          /// <summary> /// 提交日期  /// <summary> public DateTime WrongDate { get; set; }
	}
}
	
