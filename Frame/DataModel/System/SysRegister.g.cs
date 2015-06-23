// Business class SysRegister generated from SysRegister
// Creator: WGM
// Created Date: [2015-05-30]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysRegister")]
	public partial class SysRegister : ModelBase<SysRegister>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_Name = "Name";
		public static string Prop_RegisterKey = "RegisterKey";
		public static string Prop_RegisterValue = "RegisterValue";
		public static string Prop_Remark = "Remark";
		public static string Prop_ParentID = "ParentID";
		public static string Prop_Path = "Path";
		public static string Prop_CreateTime = "CreateTime";
		public static string Prop_CreateUserID = "CreateUserID";
		public static string Prop_CreateName = "CreateName";

		#endregion

		#region Private_Variables

		private string _id;
		private string _name;
		private string _registerKey;
		private string _registerValue;
		private string _remark;
		private string _parentID;
		private string _path;
		private DateTime? _createTime;
		private string _createUserID;
		private string _createName;


		#endregion

		#region Constructors

		public SysRegister()
		{
		}

		public SysRegister(
			string p_id,
			string p_name,
			string p_registerKey,
			string p_registerValue,
			string p_remark,
			string p_parentID,
			string p_path,
			DateTime? p_createTime,
			string p_createUserID,
			string p_createName)
		{
			_id = p_id;
			_name = p_name;
			_registerKey = p_registerKey;
			_registerValue = p_registerValue;
			_remark = p_remark;
			_parentID = p_parentID;
			_path = p_path;
			_createTime = p_createTime;
			_createUserID = p_createUserID;
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

		[Property("Name", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string Name
		{
			get { return _name; }
			set
			{
				if ((_name == null) || (value == null) || (!value.Equals(_name)))
				{
                    object oldValue = _name;
					_name = value;
					RaisePropertyChanged(SysRegister.Prop_Name, oldValue, value);
				}
			}

		}

		[Property("RegisterKey", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
		public string RegisterKey
		{
			get { return _registerKey; }
			set
			{
				if ((_registerKey == null) || (value == null) || (!value.Equals(_registerKey)))
				{
                    object oldValue = _registerKey;
					_registerKey = value;
					RaisePropertyChanged(SysRegister.Prop_RegisterKey, oldValue, value);
				}
			}

		}

		[Property("RegisterValue", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
		public string RegisterValue
		{
			get { return _registerValue; }
			set
			{
				if ((_registerValue == null) || (value == null) || (!value.Equals(_registerValue)))
				{
                    object oldValue = _registerValue;
					_registerValue = value;
					RaisePropertyChanged(SysRegister.Prop_RegisterValue, oldValue, value);
				}
			}

		}

		[Property("Remark", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string Remark
		{
			get { return _remark; }
			set
			{
				if ((_remark == null) || (value == null) || (!value.Equals(_remark)))
				{
                    object oldValue = _remark;
					_remark = value;
					RaisePropertyChanged(SysRegister.Prop_Remark, oldValue, value);
				}
			}

		}

		[Property("ParentID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 36)]
		public string ParentID
		{
			get { return _parentID; }
			set
			{
				if ((_parentID == null) || (value == null) || (!value.Equals(_parentID)))
				{
                    object oldValue = _parentID;
					_parentID = value;
					RaisePropertyChanged(SysRegister.Prop_ParentID, oldValue, value);
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
					RaisePropertyChanged(SysRegister.Prop_Path, oldValue, value);
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
					RaisePropertyChanged(SysRegister.Prop_CreateTime, oldValue, value);
				}
			}

		}

		[Property("CreateUserID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string CreateUserID
		{
			get { return _createUserID; }
			set
			{
				if ((_createUserID == null) || (value == null) || (!value.Equals(_createUserID)))
				{
                    object oldValue = _createUserID;
					_createUserID = value;
					RaisePropertyChanged(SysRegister.Prop_CreateUserID, oldValue, value);
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
					RaisePropertyChanged(SysRegister.Prop_CreateName, oldValue, value);
				}
			}

		}

		#endregion
	} // SysRegister
}

