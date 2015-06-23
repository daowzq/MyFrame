// Business class SysGroupAuth generated from SysGroupAuth
// Creator: WGM
// Created Date: [2015-05-31]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysGroupAuth")]
	public partial class SysGroupAuth : ModelBase<SysGroupAuth>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_GroupID = "GroupID";
		public static string Prop_GroupName = "GroupName";
		public static string Prop_ModuleID = "ModuleID";
		public static string Prop_ModuleName = "ModuleName";
		public static string Prop_CreateTime = "CreateTime";

		#endregion

		#region Private_Variables

		private string _id;
		private string _groupID;
		private string _groupName;
		private string _moduleID;
		private string _moduleName;
		private DateTime? _createTime;


		#endregion

		#region Constructors

		public SysGroupAuth()
		{
		}

		public SysGroupAuth(
			string p_id,
			string p_groupID,
			string p_groupName,
			string p_moduleID,
			string p_moduleName,
			DateTime? p_createTime)
		{
			_id = p_id;
			_groupID = p_groupID;
			_groupName = p_groupName;
			_moduleID = p_moduleID;
			_moduleName = p_moduleName;
			_createTime = p_createTime;
		}

		#endregion

		#region Properties

		[PrimaryKey("ID", Generator = PrimaryKeyType.Custom, CustomGenerator = typeof(IDGenerator), Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public string ID
		{
			get { return _id; }
			set { _id = value; } // 处理列表编辑时去掉注释

		}

		[Property("GroupID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 36)]
		public string GroupID
		{
			get { return _groupID; }
			set
			{
				if ((_groupID == null) || (value == null) || (!value.Equals(_groupID)))
				{
                    object oldValue = _groupID;
					_groupID = value;
					RaisePropertyChanged(SysGroupAuth.Prop_GroupID, oldValue, value);
				}
			}

		}

		[Property("GroupName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string GroupName
		{
			get { return _groupName; }
			set
			{
				if ((_groupName == null) || (value == null) || (!value.Equals(_groupName)))
				{
                    object oldValue = _groupName;
					_groupName = value;
					RaisePropertyChanged(SysGroupAuth.Prop_GroupName, oldValue, value);
				}
			}

		}

		[Property("ModuleID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 36)]
		public string ModuleID
		{
			get { return _moduleID; }
			set
			{
				if ((_moduleID == null) || (value == null) || (!value.Equals(_moduleID)))
				{
                    object oldValue = _moduleID;
					_moduleID = value;
					RaisePropertyChanged(SysGroupAuth.Prop_ModuleID, oldValue, value);
				}
			}

		}

		[Property("ModuleName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string ModuleName
		{
			get { return _moduleName; }
			set
			{
				if ((_moduleName == null) || (value == null) || (!value.Equals(_moduleName)))
				{
                    object oldValue = _moduleName;
					_moduleName = value;
					RaisePropertyChanged(SysGroupAuth.Prop_ModuleName, oldValue, value);
				}
			}

		}

		[Property("CreateTime", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public DateTime? CreateTime
		{
			get { return _createTime; }
			set
			{
				if (value != _createTime)
				{
                    object oldValue = _createTime;
					_createTime = value;
					RaisePropertyChanged(SysGroupAuth.Prop_CreateTime, oldValue, value);
				}
			}

		}

		#endregion
	} // SysGroupAuth
}

