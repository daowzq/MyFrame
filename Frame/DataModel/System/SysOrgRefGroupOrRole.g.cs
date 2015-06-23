// Business class SysOrgRefGroupOrRole generated from SysOrgRefGroupOrRole
// Creator: WGM
// Created Date: [2015-05-02]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysOrgRefGroupOrRole")]
	public partial class SysOrgRefGroupOrRole : ModelBase<SysOrgRefGroupOrRole>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_OrgID = "OrgID";
		public static string Prop_OrgName = "OrgName";
		public static string Prop_GroupOrRoleID = "GroupOrRoleID";
		public static string Prop_GroupOrRoleName = "GroupOrRoleName";

		#endregion

		#region Private_Variables

		private string _id;
		private string _orgID;
		private string _orgName;
		private string _groupOrRoleID;
		private string _groupOrRoleName;


		#endregion

		#region Constructors

		public SysOrgRefGroupOrRole()
		{
		}

		public SysOrgRefGroupOrRole(
			string p_id,
			string p_orgID,
			string p_orgName,
			string p_groupOrRoleID,
			string p_groupOrRoleName)
		{
			_id = p_id;
			_orgID = p_orgID;
			_orgName = p_orgName;
			_groupOrRoleID = p_groupOrRoleID;
			_groupOrRoleName = p_groupOrRoleName;
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
					RaisePropertyChanged(SysOrgRefGroupOrRole.Prop_OrgID, oldValue, value);
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
					RaisePropertyChanged(SysOrgRefGroupOrRole.Prop_OrgName, oldValue, value);
				}
			}

		}

		[Property("GroupOrRoleID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string GroupOrRoleID
		{
			get { return _groupOrRoleID; }
			set
			{
				if ((_groupOrRoleID == null) || (value == null) || (!value.Equals(_groupOrRoleID)))
				{
                    object oldValue = _groupOrRoleID;
					_groupOrRoleID = value;
					RaisePropertyChanged(SysOrgRefGroupOrRole.Prop_GroupOrRoleID, oldValue, value);
				}
			}

		}

		[Property("GroupOrRoleName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string GroupOrRoleName
		{
			get { return _groupOrRoleName; }
			set
			{
				if ((_groupOrRoleName == null) || (value == null) || (!value.Equals(_groupOrRoleName)))
				{
                    object oldValue = _groupOrRoleName;
					_groupOrRoleName = value;
					RaisePropertyChanged(SysOrgRefGroupOrRole.Prop_GroupOrRoleName, oldValue, value);
				}
			}

		}

		#endregion
	} // SysOrgRefGroupOrRole
}

