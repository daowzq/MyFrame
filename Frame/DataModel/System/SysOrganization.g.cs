// Business class SysOrganization generated from SysOrganization
// Creator: WGM
// Created Date: [2015-04-04]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysOrganization")]
	public partial class SysOrganization : ModelBase<SysOrganization>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_Code = "Code";
		public static string Prop_Name = "Name";
		public static string Prop_ParentID = "ParentID";
		public static string Prop_Path = "Path";
		public static string Prop_OrgType = "OrgType";
		public static string Prop_State = "State";
		public static string Prop_SortIndex = "SortIndex";
		public static string Prop_CreateID = "CreateID";
		public static string Prop_CreateName = "CreateName";
		public static string Prop_CreateTime = "CreateTime";

		#endregion

		#region Private_Variables

		private string _id;
		private string _code;
		private string _name;
		private string _parentID;
		private string _path;
		private string _orgType;
		private string _state;
		private int? _sortIndex;
		private string _createID;
		private string _createName;
		private DateTime? _createTime;


		#endregion

		#region Constructors

		public SysOrganization()
		{
		}

		public SysOrganization(
			string p_id,
			string p_code,
			string p_name,
			string p_parentID,
			string p_path,
			string p_orgType,
			string p_state,
			int? p_sortIndex,
			string p_createID,
			string p_createName,
			DateTime? p_createTime)
		{
			_id = p_id;
			_code = p_code;
			_name = p_name;
			_parentID = p_parentID;
			_path = p_path;
			_orgType = p_orgType;
			_state = p_state;
			_sortIndex = p_sortIndex;
			_createID = p_createID;
			_createName = p_createName;
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

		[Property("Code", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string Code
		{
			get { return _code; }
			set
			{
				if ((_code == null) || (value == null) || (!value.Equals(_code)))
				{
                    object oldValue = _code;
					_code = value;
					RaisePropertyChanged(SysOrganization.Prop_Code, oldValue, value);
				}
			}

		}

		[Property("Name", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string Name
		{
			get { return _name; }
			set
			{
				if ((_name == null) || (value == null) || (!value.Equals(_name)))
				{
                    object oldValue = _name;
					_name = value;
					RaisePropertyChanged(SysOrganization.Prop_Name, oldValue, value);
				}
			}

		}

		[Property("ParentID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string ParentID
		{
			get { return _parentID; }
			set
			{
				if ((_parentID == null) || (value == null) || (!value.Equals(_parentID)))
				{
                    object oldValue = _parentID;
					_parentID = value;
					RaisePropertyChanged(SysOrganization.Prop_ParentID, oldValue, value);
				}
			}

		}

		[Property("Path", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public string Path
		{
			get { return _path; }
			set
			{
				if ((_path == null) || (value == null) || (!value.Equals(_path)))
				{
                    object oldValue = _path;
					_path = value;
					RaisePropertyChanged(SysOrganization.Prop_Path, oldValue, value);
				}
			}

		}

		[Property("OrgType", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string OrgType
		{
			get { return _orgType; }
			set
			{
				if ((_orgType == null) || (value == null) || (!value.Equals(_orgType)))
				{
                    object oldValue = _orgType;
					_orgType = value;
					RaisePropertyChanged(SysOrganization.Prop_OrgType, oldValue, value);
				}
			}

		}

		[Property("State", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 10)]
		public string State
		{
			get { return _state; }
			set
			{
				if ((_state == null) || (value == null) || (!value.Equals(_state)))
				{
                    object oldValue = _state;
					_state = value;
					RaisePropertyChanged(SysOrganization.Prop_State, oldValue, value);
				}
			}

		}

		[Property("SortIndex", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public int? SortIndex
		{
			get { return _sortIndex; }
			set
			{
				if (value != _sortIndex)
				{
                    object oldValue = _sortIndex;
					_sortIndex = value;
					RaisePropertyChanged(SysOrganization.Prop_SortIndex, oldValue, value);
				}
			}

		}

		[Property("CreateID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string CreateID
		{
			get { return _createID; }
			set
			{
				if ((_createID == null) || (value == null) || (!value.Equals(_createID)))
				{
                    object oldValue = _createID;
					_createID = value;
					RaisePropertyChanged(SysOrganization.Prop_CreateID, oldValue, value);
				}
			}

		}

		[Property("CreateName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string CreateName
		{
			get { return _createName; }
			set
			{
				if ((_createName == null) || (value == null) || (!value.Equals(_createName)))
				{
                    object oldValue = _createName;
					_createName = value;
					RaisePropertyChanged(SysOrganization.Prop_CreateName, oldValue, value);
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
					RaisePropertyChanged(SysOrganization.Prop_CreateTime, oldValue, value);
				}
			}

		}

		#endregion
	} // SysOrganization
}

