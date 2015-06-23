// Business class SysOrgAuth generated from SysOrgAuth
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
	[ActiveRecord("SysOrgAuth")]
	public partial class SysOrgAuth : ModelBase<SysOrgAuth>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_OrgID = "OrgID";
		public static string Prop_OrgName = "OrgName";
		public static string Prop_ModuleID = "ModuleID";
		public static string Prop_ModuleName = "ModuleName";
		public static string Prop_CreateTime = "CreateTime";

		#endregion

		#region Private_Variables

		private string _id;
		private string _orgID;
		private string _orgName;
		private string _moduleID;
		private string _moduleName;
		private DateTime? _createTime;


		#endregion

		#region Constructors

		public SysOrgAuth()
		{
		}

		public SysOrgAuth(
			string p_id,
			string p_orgID,
			string p_orgName,
			string p_moduleID,
			string p_moduleName,
			DateTime? p_createTime)
		{
			_id = p_id;
			_orgID = p_orgID;
			_orgName = p_orgName;
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

		[Property("OrgID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 36)]
		public string OrgID
		{
			get { return _orgID; }
			set
			{
				if ((_orgID == null) || (value == null) || (!value.Equals(_orgID)))
				{
                    object oldValue = _orgID;
					_orgID = value;
					RaisePropertyChanged(SysOrgAuth.Prop_OrgID, oldValue, value);
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
					RaisePropertyChanged(SysOrgAuth.Prop_OrgName, oldValue, value);
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
					RaisePropertyChanged(SysOrgAuth.Prop_ModuleID, oldValue, value);
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
					RaisePropertyChanged(SysOrgAuth.Prop_ModuleName, oldValue, value);
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
					RaisePropertyChanged(SysOrgAuth.Prop_CreateTime, oldValue, value);
				}
			}

		}

		#endregion
	} // SysOrgAuth
}

