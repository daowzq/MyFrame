// Business class SysLog generated from SysLog
// Creator: WGM
// Created Date: [2015-03-29]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysLog")]
	public partial class SysLog : ModelBase<SysLog>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_PageName = "PageName";
		public static string Prop_ErrorLevel = "ErrorLevel";
		public static string Prop_ExceptionMsg = "ExceptionMsg";
		public static string Prop_StackTrace = "StackTrace";
		public static string Prop_LoginUserId = "LoginUserId";
		public static string Prop_LoginUserName = "LoginUserName";
		public static string Prop_LoginIP = "LoginIP";
		public static string Prop_Ext1 = "Ext1";
		public static string Prop_CreateTime = "CreateTime";

		#endregion

		#region Private_Variables

		private string _id;
		private string _pageName;
		private string _errorLevel;
		private string _exceptionMsg;
		private string _stackTrace;
		private string _loginUserId;
		private string _loginUserName;
		private string _loginIP;
		private string _ext1;
		private DateTime? _createTime;


		#endregion

		#region Constructors

		public SysLog()
		{
		}

		public SysLog(
			string p_id,
			string p_pageName,
			string p_errorLevel,
			string p_exceptionMsg,
			string p_stackTrace,
			string p_loginUserId,
			string p_loginUserName,
			string p_loginIP,
			string p_ext1,
			DateTime? p_createTime)
		{
			_id = p_id;
			_pageName = p_pageName;
			_errorLevel = p_errorLevel;
			_exceptionMsg = p_exceptionMsg;
			_stackTrace = p_stackTrace;
			_loginUserId = p_loginUserId;
			_loginUserName = p_loginUserName;
			_loginIP = p_loginIP;
			_ext1 = p_ext1;
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

		[Property("PageName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string PageName
		{
			get { return _pageName; }
			set
			{
				if ((_pageName == null) || (value == null) || (!value.Equals(_pageName)))
				{
                    object oldValue = _pageName;
					_pageName = value;
					RaisePropertyChanged(SysLog.Prop_PageName, oldValue, value);
				}
			}

		}

		[Property("ErrorLevel", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string ErrorLevel
		{
			get { return _errorLevel; }
			set
			{
				if ((_errorLevel == null) || (value == null) || (!value.Equals(_errorLevel)))
				{
                    object oldValue = _errorLevel;
					_errorLevel = value;
					RaisePropertyChanged(SysLog.Prop_ErrorLevel, oldValue, value);
				}
			}

		}

		[Property("ExceptionMsg", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 3000)]
		public string ExceptionMsg
		{
			get { return _exceptionMsg; }
			set
			{
				if ((_exceptionMsg == null) || (value == null) || (!value.Equals(_exceptionMsg)))
				{
                    object oldValue = _exceptionMsg;
					_exceptionMsg = value;
					RaisePropertyChanged(SysLog.Prop_ExceptionMsg, oldValue, value);
				}
			}

		}

		[Property("StackTrace", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public string StackTrace
		{
			get { return _stackTrace; }
			set
			{
				if ((_stackTrace == null) || (value == null) || (!value.Equals(_stackTrace)))
				{
                    object oldValue = _stackTrace;
					_stackTrace = value;
					RaisePropertyChanged(SysLog.Prop_StackTrace, oldValue, value);
				}
			}

		}

		[Property("LoginUserId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string LoginUserId
		{
			get { return _loginUserId; }
			set
			{
				if ((_loginUserId == null) || (value == null) || (!value.Equals(_loginUserId)))
				{
                    object oldValue = _loginUserId;
					_loginUserId = value;
					RaisePropertyChanged(SysLog.Prop_LoginUserId, oldValue, value);
				}
			}

		}

		[Property("LoginUserName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
		public string LoginUserName
		{
			get { return _loginUserName; }
			set
			{
				if ((_loginUserName == null) || (value == null) || (!value.Equals(_loginUserName)))
				{
                    object oldValue = _loginUserName;
					_loginUserName = value;
					RaisePropertyChanged(SysLog.Prop_LoginUserName, oldValue, value);
				}
			}

		}

		[Property("LoginIP", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
		public string LoginIP
		{
			get { return _loginIP; }
			set
			{
				if ((_loginIP == null) || (value == null) || (!value.Equals(_loginIP)))
				{
                    object oldValue = _loginIP;
					_loginIP = value;
					RaisePropertyChanged(SysLog.Prop_LoginIP, oldValue, value);
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
					RaisePropertyChanged(SysLog.Prop_Ext1, oldValue, value);
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
					RaisePropertyChanged(SysLog.Prop_CreateTime, oldValue, value);
				}
			}

		}

		#endregion
	} // SysLog
}

