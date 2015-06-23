// Business class SysGroupOrRole generated from SysGroupOrRole
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
	[ActiveRecord("SysGroupOrRole")]
	public partial class SysGroupOrRole : ModelBase<SysGroupOrRole>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_GroupCode = "GroupCode";
		public static string Prop_GroupName = "GroupName";
		public static string Prop_ParentID = "ParentID";
		public static string Prop_Path = "Path";
		public static string Prop_Type = "Type";
		public static string Prop_State = "State";
		public static string Prop_SortIndex = "SortIndex";
		public static string Prop_Remark = "Remark";
		public static string Prop_CreateTime = "CreateTime";
		public static string Prop_CreateID = "CreateID";
		public static string Prop_CreateName = "CreateName";

		#endregion

		#region Private_Variables

		private string _id;
		private string _groupCode;
		private string _groupName;
		private string _parentID;
		private string _path;
		private string _type;
		private string _state;
		private int? _sortIndex;
		private string _remark;
		private DateTime? _createTime;
		private string _createID;
		private string _createName;


		#endregion

		#region Constructors

		public SysGroupOrRole()
		{
		}

		public SysGroupOrRole(
			string p_id,
			string p_groupCode,
			string p_groupName,
			string p_parentID,
			string p_path,
			string p_type,
			string p_state,
			int? p_sortIndex,
			string p_remark,
			DateTime? p_createTime,
			string p_createID,
			string p_createName)
		{
			_id = p_id;
			_groupCode = p_groupCode;
			_groupName = p_groupName;
			_parentID = p_parentID;
			_path = p_path;
			_type = p_type;
			_state = p_state;
			_sortIndex = p_sortIndex;
			_remark = p_remark;
			_createTime = p_createTime;
			_createID = p_createID;
			_createName = p_createName;
		}

		#endregion

		#region Properties

		[PrimaryKey("ID", Generator = PrimaryKeyType.Custom, CustomGenerator = typeof(IDGenerator), Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public string ID
		{
			get { return _id; }
			set { _id = value; } // 处理列表编辑时去掉注释

		}

		[Property("GroupCode", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 10)]
		public string GroupCode
		{
			get { return _groupCode; }
			set
			{
				if ((_groupCode == null) || (value == null) || (!value.Equals(_groupCode)))
				{
                    object oldValue = _groupCode;
					_groupCode = value;
					RaisePropertyChanged(SysGroupOrRole.Prop_GroupCode, oldValue, value);
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
					RaisePropertyChanged(SysGroupOrRole.Prop_GroupName, oldValue, value);
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
					RaisePropertyChanged(SysGroupOrRole.Prop_ParentID, oldValue, value);
				}
			}

		}

		[Property("Path", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 3000)]
		public string Path
		{
			get { return _path; }
			set
			{
				if ((_path == null) || (value == null) || (!value.Equals(_path)))
				{
                    object oldValue = _path;
					_path = value;
					RaisePropertyChanged(SysGroupOrRole.Prop_Path, oldValue, value);
				}
			}

		}

		[Property("Type", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string Type
		{
			get { return _type; }
			set
			{
				if ((_type == null) || (value == null) || (!value.Equals(_type)))
				{
                    object oldValue = _type;
					_type = value;
					RaisePropertyChanged(SysGroupOrRole.Prop_Type, oldValue, value);
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
					RaisePropertyChanged(SysGroupOrRole.Prop_State, oldValue, value);
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
					RaisePropertyChanged(SysGroupOrRole.Prop_SortIndex, oldValue, value);
				}
			}

		}

		[Property("Remark", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
		public string Remark
		{
			get { return _remark; }
			set
			{
				if ((_remark == null) || (value == null) || (!value.Equals(_remark)))
				{
                    object oldValue = _remark;
					_remark = value;
					RaisePropertyChanged(SysGroupOrRole.Prop_Remark, oldValue, value);
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
					RaisePropertyChanged(SysGroupOrRole.Prop_CreateTime, oldValue, value);
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
					RaisePropertyChanged(SysGroupOrRole.Prop_CreateID, oldValue, value);
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
					RaisePropertyChanged(SysGroupOrRole.Prop_CreateName, oldValue, value);
				}
			}

		}

		#endregion
	} // SysGroupOrRole
}

