// Business class SysDict generated from SysDict
// Creator: WGM
// Created Date: [2015-05-07]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysDict")]
	public partial class SysDict : ModelBase<SysDict>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_Name = "Name";
		public static string Prop_Code = "Code";
		public static string Prop_Value = "Value";
		public static string Prop_ParentID = "ParentID";
		public static string Prop_Path = "Path";
		public static string Prop_SortIndex = "SortIndex";
		public static string Prop_Remarks = "Remarks";
		public static string Prop_CreateDate = "CreateDate";

		#endregion

		#region Private_Variables

		private string _id;
		private string _name;
		private string _code;
		private string _value;
		private string _parentID;
		private string _path;
		private int? _sortIndex;
		private string _remarks;
		private DateTime? _createDate;


		#endregion

		#region Constructors

		public SysDict()
		{
		}

		public SysDict(
			string p_id,
			string p_name,
			string p_code,
			string p_value,
			string p_parentID,
			string p_path,
			int? p_sortIndex,
			string p_remarks,
			DateTime? p_createDate)
		{
			_id = p_id;
			_name = p_name;
			_code = p_code;
			_value = p_value;
			_parentID = p_parentID;
			_path = p_path;
			_sortIndex = p_sortIndex;
			_remarks = p_remarks;
			_createDate = p_createDate;
		}

		#endregion

		#region Properties

		[PrimaryKey("ID", Generator = PrimaryKeyType.Custom, CustomGenerator = typeof(IDGenerator), Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public string ID
		{
			get { return _id; }
			set { _id = value; } // 处理列表编辑时去掉注释

		}

		[Property("Name", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 200)]
		public string Name
		{
			get { return _name; }
			set
			{
				if ((_name == null) || (value == null) || (!value.Equals(_name)))
				{
                    object oldValue = _name;
					_name = value;
					RaisePropertyChanged(SysDict.Prop_Name, oldValue, value);
				}
			}

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
					RaisePropertyChanged(SysDict.Prop_Code, oldValue, value);
				}
			}

		}

		[Property("Value", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 200)]
		public string Value
		{
			get { return _value; }
			set
			{
				if ((_value == null) || (value == null) || (!value.Equals(_value)))
				{
                    object oldValue = _value;
					_value = value;
					RaisePropertyChanged(SysDict.Prop_Value, oldValue, value);
				}
			}

		}

		[Property("ParentID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string ParentID
		{
			get { return _parentID; }
			set
			{
				if ((_parentID == null) || (value == null) || (!value.Equals(_parentID)))
				{
                    object oldValue = _parentID;
					_parentID = value;
					RaisePropertyChanged(SysDict.Prop_ParentID, oldValue, value);
				}
			}

		}

		[Property("Path", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
		public string Path
		{
			get { return _path; }
			set
			{
				if ((_path == null) || (value == null) || (!value.Equals(_path)))
				{
                    object oldValue = _path;
					_path = value;
					RaisePropertyChanged(SysDict.Prop_Path, oldValue, value);
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
					RaisePropertyChanged(SysDict.Prop_SortIndex, oldValue, value);
				}
			}

		}

		[Property("Remarks", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 500)]
		public string Remarks
		{
			get { return _remarks; }
			set
			{
				if ((_remarks == null) || (value == null) || (!value.Equals(_remarks)))
				{
                    object oldValue = _remarks;
					_remarks = value;
					RaisePropertyChanged(SysDict.Prop_Remarks, oldValue, value);
				}
			}

		}

		[Property("CreateDate", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public DateTime? CreateDate
		{
			get { return _createDate; }
			set
			{
				if (value != _createDate)
				{
                    object oldValue = _createDate;
					_createDate = value;
					RaisePropertyChanged(SysDict.Prop_CreateDate, oldValue, value);
				}
			}

		}

		#endregion
	} // SysDict
}

