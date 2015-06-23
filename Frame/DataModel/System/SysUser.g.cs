// Business class SysUser generated from SysUser
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
	[ActiveRecord("SysUser")]
	public partial class SysUser : ModelBase<SysUser>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_WorkNo = "WorkNo";
		public static string Prop_Name = "Name";
		public static string Prop_EnglishName = "EnglishName";
		public static string Prop_LoginName = "LoginName";
		public static string Prop_LoginPwd = "LoginPwd";
		public static string Prop_State = "State";
		public static string Prop_Email = "Email";
		public static string Prop_Phone = "Phone";
		public static string Prop_TelNo = "TelNo";
		public static string Prop_QQ = "QQ";
		public static string Prop_WeChat = "WeChat";
		public static string Prop_WorkInDate = "WorkInDate";
		public static string Prop_WorkOutDate = "WorkOutDate";
		public static string Prop_Ext1 = "Ext1";
		public static string Prop_ExtJson = "ExtJson";
		public static string Prop_CreateTime = "CreateTime";
		public static string Prop_CreateUserId = "CreateUserId";
		public static string Prop_CreateUserName = "CreateUserName";

		#endregion

		#region Private_Variables

		private string _id;
		private string _workNo;
		private string _name;
		private string _englishName;
		private string _loginName;
		private string _loginPwd;
		private string _state;
		private string _email;
		private string _phone;
		private string _telNo;
		private string _qQ;
		private string _weChat;
		private DateTime? _workInDate;
		private DateTime? _workOutDate;
		private string _ext1;
		private string _extJson;
		private DateTime? _createTime;
		private string _createUserId;
		private string _createUserName;


		#endregion

		#region Constructors

		public SysUser()
		{
		}

		public SysUser(
			string p_id,
			string p_workNo,
			string p_name,
			string p_englishName,
			string p_loginName,
			string p_loginPwd,
			string p_state,
			string p_email,
			string p_phone,
			string p_telNo,
			string p_qQ,
			string p_weChat,
			DateTime? p_workInDate,
			DateTime? p_workOutDate,
			string p_ext1,
			string p_extJson,
			DateTime? p_createTime,
			string p_createUserId,
			string p_createUserName)
		{
			_id = p_id;
			_workNo = p_workNo;
			_name = p_name;
			_englishName = p_englishName;
			_loginName = p_loginName;
			_loginPwd = p_loginPwd;
			_state = p_state;
			_email = p_email;
			_phone = p_phone;
			_telNo = p_telNo;
			_qQ = p_qQ;
			_weChat = p_weChat;
			_workInDate = p_workInDate;
			_workOutDate = p_workOutDate;
			_ext1 = p_ext1;
			_extJson = p_extJson;
			_createTime = p_createTime;
			_createUserId = p_createUserId;
			_createUserName = p_createUserName;
		}

		#endregion

		#region Properties

		[PrimaryKey("ID", Generator = PrimaryKeyType.Custom, CustomGenerator = typeof(IDGenerator), Access = PropertyAccess.NosetterLowercaseUnderscore)]
		public string ID
		{
			get { return _id; }
			set { _id = value; } // 处理列表编辑时去掉注释

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
					RaisePropertyChanged(SysUser.Prop_WorkNo, oldValue, value);
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
					RaisePropertyChanged(SysUser.Prop_Name, oldValue, value);
				}
			}

		}

		[Property("EnglishName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string EnglishName
		{
			get { return _englishName; }
			set
			{
				if ((_englishName == null) || (value == null) || (!value.Equals(_englishName)))
				{
                    object oldValue = _englishName;
					_englishName = value;
					RaisePropertyChanged(SysUser.Prop_EnglishName, oldValue, value);
				}
			}

		}

		[Property("LoginName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string LoginName
		{
			get { return _loginName; }
			set
			{
				if ((_loginName == null) || (value == null) || (!value.Equals(_loginName)))
				{
                    object oldValue = _loginName;
					_loginName = value;
					RaisePropertyChanged(SysUser.Prop_LoginName, oldValue, value);
				}
			}

		}

		[Property("LoginPwd", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
		public string LoginPwd
		{
			get { return _loginPwd; }
			set
			{
				if ((_loginPwd == null) || (value == null) || (!value.Equals(_loginPwd)))
				{
                    object oldValue = _loginPwd;
					_loginPwd = value;
					RaisePropertyChanged(SysUser.Prop_LoginPwd, oldValue, value);
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
					RaisePropertyChanged(SysUser.Prop_State, oldValue, value);
				}
			}

		}

		[Property("Email", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string Email
		{
			get { return _email; }
			set
			{
				if ((_email == null) || (value == null) || (!value.Equals(_email)))
				{
                    object oldValue = _email;
					_email = value;
					RaisePropertyChanged(SysUser.Prop_Email, oldValue, value);
				}
			}

		}

		[Property("Phone", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 20)]
		public string Phone
		{
			get { return _phone; }
			set
			{
				if ((_phone == null) || (value == null) || (!value.Equals(_phone)))
				{
                    object oldValue = _phone;
					_phone = value;
					RaisePropertyChanged(SysUser.Prop_Phone, oldValue, value);
				}
			}

		}

		[Property("TelNo", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string TelNo
		{
			get { return _telNo; }
			set
			{
				if ((_telNo == null) || (value == null) || (!value.Equals(_telNo)))
				{
                    object oldValue = _telNo;
					_telNo = value;
					RaisePropertyChanged(SysUser.Prop_TelNo, oldValue, value);
				}
			}

		}

		[Property("QQ", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string QQ
		{
			get { return _qQ; }
			set
			{
				if ((_qQ == null) || (value == null) || (!value.Equals(_qQ)))
				{
                    object oldValue = _qQ;
					_qQ = value;
					RaisePropertyChanged(SysUser.Prop_QQ, oldValue, value);
				}
			}

		}

		[Property("WeChat", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string WeChat
		{
			get { return _weChat; }
			set
			{
				if ((_weChat == null) || (value == null) || (!value.Equals(_weChat)))
				{
                    object oldValue = _weChat;
					_weChat = value;
					RaisePropertyChanged(SysUser.Prop_WeChat, oldValue, value);
				}
			}

		}

		[Property("WorkInDate", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public DateTime? WorkInDate
		{
			get { return _workInDate; }
			set
			{
				if (value != _workInDate)
				{
                    object oldValue = _workInDate;
					_workInDate = value;
					RaisePropertyChanged(SysUser.Prop_WorkInDate, oldValue, value);
				}
			}

		}

		[Property("WorkOutDate", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public DateTime? WorkOutDate
		{
			get { return _workOutDate; }
			set
			{
				if (value != _workOutDate)
				{
                    object oldValue = _workOutDate;
					_workOutDate = value;
					RaisePropertyChanged(SysUser.Prop_WorkOutDate, oldValue, value);
				}
			}

		}

		[Property("Ext1", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
		public string Ext1
		{
			get { return _ext1; }
			set
			{
				if ((_ext1 == null) || (value == null) || (!value.Equals(_ext1)))
				{
                    object oldValue = _ext1;
					_ext1 = value;
					RaisePropertyChanged(SysUser.Prop_Ext1, oldValue, value);
				}
			}

		}

		[Property("ExtJson", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 3000)]
		public string ExtJson
		{
			get { return _extJson; }
			set
			{
				if ((_extJson == null) || (value == null) || (!value.Equals(_extJson)))
				{
                    object oldValue = _extJson;
					_extJson = value;
					RaisePropertyChanged(SysUser.Prop_ExtJson, oldValue, value);
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
					RaisePropertyChanged(SysUser.Prop_CreateTime, oldValue, value);
				}
			}

		}

		[Property("CreateUserId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string CreateUserId
		{
			get { return _createUserId; }
			set
			{
				if ((_createUserId == null) || (value == null) || (!value.Equals(_createUserId)))
				{
                    object oldValue = _createUserId;
					_createUserId = value;
					RaisePropertyChanged(SysUser.Prop_CreateUserId, oldValue, value);
				}
			}

		}

		[Property("CreateUserName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string CreateUserName
		{
			get { return _createUserName; }
			set
			{
				if ((_createUserName == null) || (value == null) || (!value.Equals(_createUserName)))
				{
                    object oldValue = _createUserName;
					_createUserName = value;
					RaisePropertyChanged(SysUser.Prop_CreateUserName, oldValue, value);
				}
			}

		}

		#endregion
	} // SysUser
}

