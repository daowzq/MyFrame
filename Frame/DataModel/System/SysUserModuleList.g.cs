// Business class SysUserModuleList generated from SysUserModuleList
// Creator: WGM
// Created Date: [2015-06-13]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysUserModuleList")]
	public partial class SysUserModuleList : ModelBase<SysUserModuleList>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_UserID = "UserID";
		public static string Prop_WorkNo = "WorkNo";
		public static string Prop_UserName = "UserName";
		public static string Prop_ModuleID = "ModuleID";
		public static string Prop_ModuleName = "ModuleName";
		public static string Prop_ModulePath = "ModulePath";
		public static string Prop_CreateTime = "CreateTime";

		#endregion

		#region Private_Variables

		private string _id;
		private string _userID;
		private string _workNo;
		private string _userName;
		private string _moduleID;
		private string _moduleName;
		private string _modulePath;
		private DateTime? _createTime;


		#endregion

		#region Constructors

		public SysUserModuleList()
		{
		}

		public SysUserModuleList(
			string p_id,
			string p_userID,
			string p_workNo,
			string p_userName,
			string p_moduleID,
			string p_moduleName,
			string p_modulePath,
			DateTime? p_createTime)
		{
			_id = p_id;
			_userID = p_userID;
			_workNo = p_workNo;
			_userName = p_userName;
			_moduleID = p_moduleID;
			_moduleName = p_moduleName;
			_modulePath = p_modulePath;
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

		[Property("UserID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string UserID
		{
			get { return _userID; }
			set
			{
				if ((_userID == null) || (value == null) || (!value.Equals(_userID)))
				{
                    object oldValue = _userID;
					_userID = value;
					RaisePropertyChanged(SysUserModuleList.Prop_UserID, oldValue, value);
				}
			}

		}

		[Property("WorkNo", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string WorkNo
		{
			get { return _workNo; }
			set
			{
				if ((_workNo == null) || (value == null) || (!value.Equals(_workNo)))
				{
                    object oldValue = _workNo;
					_workNo = value;
					RaisePropertyChanged(SysUserModuleList.Prop_WorkNo, oldValue, value);
				}
			}

		}

		[Property("UserName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string UserName
		{
			get { return _userName; }
			set
			{
				if ((_userName == null) || (value == null) || (!value.Equals(_userName)))
				{
                    object oldValue = _userName;
					_userName = value;
					RaisePropertyChanged(SysUserModuleList.Prop_UserName, oldValue, value);
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
					RaisePropertyChanged(SysUserModuleList.Prop_ModuleID, oldValue, value);
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
					RaisePropertyChanged(SysUserModuleList.Prop_ModuleName, oldValue, value);
				}
			}

		}

		[Property("ModulePath", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
		public string ModulePath
		{
			get { return _modulePath; }
			set
			{
				if ((_modulePath == null) || (value == null) || (!value.Equals(_modulePath)))
				{
                    object oldValue = _modulePath;
					_modulePath = value;
					RaisePropertyChanged(SysUserModuleList.Prop_ModulePath, oldValue, value);
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
					RaisePropertyChanged(SysUserModuleList.Prop_CreateTime, oldValue, value);
				}
			}

		}

		#endregion
	} // SysUserModuleList
}

