// Business class SysGroupUser generated from SysGroupUser
// Creator: WGM
// Created Date: [2015-04-02]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysGroupUser")]
	public partial class SysGroupUser : ModelBase<SysGroupUser>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_SysUserID = "SysUserID";
		public static string Prop_SysUserName = "SysUserName";
		public static string Prop_SysGroupID = "SysGroupID";
		public static string Prop_SysGroupName = "SysGroupName";
		public static string Prop_CreateTime = "CreateTime";

		#endregion

		#region Private_Variables

		private string _id;
		private string _sysUserID;
		private string _sysUserName;
		private string _sysGroupID;
		private string _sysGroupName;
		private DateTime? _createTime;


		#endregion

		#region Constructors

		public SysGroupUser()
		{
		}

		public SysGroupUser(
			string p_id,
			string p_sysUserID,
			string p_sysUserName,
			string p_sysGroupID,
			string p_sysGroupName,
			DateTime? p_createTime)
		{
			_id = p_id;
			_sysUserID = p_sysUserID;
			_sysUserName = p_sysUserName;
			_sysGroupID = p_sysGroupID;
			_sysGroupName = p_sysGroupName;
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

		[Property("SysUserID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string SysUserID
		{
			get { return _sysUserID; }
			set
			{
				if ((_sysUserID == null) || (value == null) || (!value.Equals(_sysUserID)))
				{
                    object oldValue = _sysUserID;
					_sysUserID = value;
					RaisePropertyChanged(SysGroupUser.Prop_SysUserID, oldValue, value);
				}
			}

		}

		[Property("SysUserName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string SysUserName
		{
			get { return _sysUserName; }
			set
			{
				if ((_sysUserName == null) || (value == null) || (!value.Equals(_sysUserName)))
				{
                    object oldValue = _sysUserName;
					_sysUserName = value;
					RaisePropertyChanged(SysGroupUser.Prop_SysUserName, oldValue, value);
				}
			}

		}

		[Property("SysGroupID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string SysGroupID
		{
			get { return _sysGroupID; }
			set
			{
				if ((_sysGroupID == null) || (value == null) || (!value.Equals(_sysGroupID)))
				{
                    object oldValue = _sysGroupID;
					_sysGroupID = value;
					RaisePropertyChanged(SysGroupUser.Prop_SysGroupID, oldValue, value);
				}
			}

		}

		[Property("SysGroupName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string SysGroupName
		{
			get { return _sysGroupName; }
			set
			{
				if ((_sysGroupName == null) || (value == null) || (!value.Equals(_sysGroupName)))
				{
                    object oldValue = _sysGroupName;
					_sysGroupName = value;
					RaisePropertyChanged(SysGroupUser.Prop_SysGroupName, oldValue, value);
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
					RaisePropertyChanged(SysGroupUser.Prop_CreateTime, oldValue, value);
				}
			}

		}

		#endregion
	} // SysGroupUser
}

