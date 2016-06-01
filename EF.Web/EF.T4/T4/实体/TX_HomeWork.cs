
using System;
using System.Collections.Generic;
namespace EF.Domain
{	
	/// <summary>
	/// 实体-TX_HomeWork 
	/// </summary>
	public partial class TX_HomeWork    
	{	
		/// <summary> /// 作业ID  /// <summary> public int HomeWorkID { get; set; }
          /// <summary> /// 腾讯QQID  /// <summary> public string OpenID { get; set; }
          /// <summary> /// 创建日期  /// <summary> public DateTime CreateDate { get; set; }
          /// <summary> /// 备注  /// <summary> public string Comment { get; set; }
          /// <summary> /// 作业名称  /// <summary> public string HomeWorkName { get; set; }
          /// <summary> /// 学段科目ID  /// <summary> public int BankID { get; set; }
          /// <summary> /// 教材ID  /// <summary> public int TeachMaterialID { get; set; }
          /// <summary> /// 教材名称  /// <summary> public string TeachMaterialName { get; set; }
          /// <summary> /// 试题类型列表  /// <summary> public string QuesTypeIDs { get; set; }
          /// <summary> /// 试题类型名称  /// <summary> public string QuesTypeNames { get; set; }
          /// <summary> /// 知识点  /// <summary> public string CategoryNames { get; set; }
          /// <summary> /// 是否删除 1删除  /// <summary> public int Deleted { get; set; }
          /// <summary> /// 目录ID NodeID  /// <summary> public int GradeID { get; set; }
          /// <summary> /// 目录名称  /// <summary> public string GradeName { get; set; }
          /// <summary> /// 章节名称  /// <summary> public string ChapterName { get; set; }
          /// <summary> /// 系统标识  /// <summary> public int TRType { get; set; }
          /// <summary> /// 腾讯ID  /// <summary> public string TencentID { get; set; }
	}
}
	
