// Business class SysOrgUser generated from SysOrgUser
// Creator: WGM
// Created Date: [2015-05-01]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysOrgUser")]
	public partial class SysOrgUser : ModelBase<SysOrgUser>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_OrgID = "OrgID";
		public static string Prop_OrgName = "OrgName";
		public static string Prop_UserID = "UserID";
		public static string Prop_UserName = "UserName";
		public static string Prop_CreateTime = "CreateTime";

		#endregion

		#region Private_Variables

		private string _id;
		private string _orgID;
		private string _orgName;
		private string _userID;
		private string _userName;
		private DateTime? _createTime;


		#endregion

		#region Constructors

		public SysOrgUser()
		{
		}

		public SysOrgUser(
			string p_id,
			string p_orgID,
			string p_orgName,
			string p_userID,
			string p_userName,
			DateTime? p_createTime)
		{
			_id = p_id;
			_orgID = p_orgID;
			_orgName = p_orgName;
			_userID = p_userID;
			_userName = p_userName;
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

		[Property("OrgID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string OrgID
		{
			get { return _orgID; }
			set
			{
				if ((_orgID == null) || (value == null) || (!value.Equals(_orgID)))
				{
                    object oldValue = _orgID;
					_orgID = value;
					RaisePropertyChanged(SysOrgUser.Prop_OrgID, oldValue, value);
				}
			}

		}

		[Property("OrgName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string OrgName
		{
			get { return _orgName; }
			set
			{
				if ((_orgName == null) || (value == null) || (!value.Equals(_orgName)))
				{
                    object oldValue = _orgName;
					_orgName = value;
					RaisePropertyChanged(SysOrgUser.Prop_OrgName, oldValue, value);
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
					RaisePropertyChanged(SysOrgUser.Prop_UserID, oldValue, value);
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
					RaisePropertyChanged(SysOrgUser.Prop_UserName, oldValue, value);
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
					RaisePropertyChanged(SysOrgUser.Prop_CreateTime, oldValue, value);
				}
			}

		}

		#endregion
	} // SysOrgUser
}

