// Business class SysUserAuth generated from SysUserAuth
// Creator: WGM
// Created Date: [2015-05-03]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysUserAuth")]
	public partial class SysUserAuth : ModelBase<SysUserAuth>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_ModuleID = "ModuleID";
		public static string Prop_ModuleName = "ModuleName";
		public static string Prop_UserID = "UserID";
		public static string Prop_UserName = "UserName";
		public static string Prop_WorkNo = "WorkNo";
		public static string Prop_CreateTime = "CreateTime";

		#endregion

		#region Private_Variables

		private string _id;
		private string _moduleID;
		private string _moduleName;
		private string _userID;
		private string _userName;
		private string _workNo;
		private DateTime? _createTime;


		#endregion

		#region Constructors

		public SysUserAuth()
		{
		}

		public SysUserAuth(
			string p_id,
			string p_moduleID,
			string p_moduleName,
			string p_userID,
			string p_userName,
			string p_workNo,
			DateTime? p_createTime)
		{
			_id = p_id;
			_moduleID = p_moduleID;
			_moduleName = p_moduleName;
			_userID = p_userID;
			_userName = p_userName;
			_workNo = p_workNo;
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

		[Property("ModuleID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string ModuleID
		{
			get { return _moduleID; }
			set
			{
				if ((_moduleID == null) || (value == null) || (!value.Equals(_moduleID)))
				{
                    object oldValue = _moduleID;
					_moduleID = value;
					RaisePropertyChanged(SysUserAuth.Prop_ModuleID, oldValue, value);
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
					RaisePropertyChanged(SysUserAuth.Prop_ModuleName, oldValue, value);
				}
			}

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
					RaisePropertyChanged(SysUserAuth.Prop_UserID, oldValue, value);
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
					RaisePropertyChanged(SysUserAuth.Prop_UserName, oldValue, value);
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
					RaisePropertyChanged(SysUserAuth.Prop_WorkNo, oldValue, value);
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
					RaisePropertyChanged(SysUserAuth.Prop_CreateTime, oldValue, value);
				}
			}

		}

		#endregion
	} // SysUserAuth
}

