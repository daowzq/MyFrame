// Business class SysFile generated from SysFile
// Creator: WGM
// Created Date: [2015-06-18]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;
	
namespace DataModel
{
	[ActiveRecord("SysFile")]
	public partial class SysFile : ModelBase<SysFile>
	{
		#region Property_Names

		public static string Prop_ID = "ID";
		public static string Prop_FileName = "FileName";
		public static string Prop_FileSuffix = "FileSuffix";
		public static string Prop_FileFullPath = "FileFullPath";
		public static string Prop_Length = "Length";
		public static string Prop_State = "State";
		public static string Prop_CreateID = "CreateID";
		public static string Prop_CreateName = "CreateName";
		public static string Prop_CreateTime = "CreateTime";

		#endregion

		#region Private_Variables

		private string _id;
		private string _fileName;
		private string _fileSuffix;
		private string _fileFullPath;
		private int? _length;
		private string _state;
		private string _createID;
		private string _createName;
		private DateTime? _createTime;


		#endregion

		#region Constructors

		public SysFile()
		{
		}

		public SysFile(
			string p_id,
			string p_fileName,
			string p_fileSuffix,
			string p_fileFullPath,
			int? p_length,
			string p_state,
			string p_createID,
			string p_createName,
			DateTime? p_createTime)
		{
			_id = p_id;
			_fileName = p_fileName;
			_fileSuffix = p_fileSuffix;
			_fileFullPath = p_fileFullPath;
			_length = p_length;
			_state = p_state;
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

		[Property("FileName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 200)]
		public string FileName
		{
			get { return _fileName; }
			set
			{
				if ((_fileName == null) || (value == null) || (!value.Equals(_fileName)))
				{
                    object oldValue = _fileName;
					_fileName = value;
					RaisePropertyChanged(SysFile.Prop_FileName, oldValue, value);
				}
			}

		}

		[Property("FileSuffix", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 10)]
		public string FileSuffix
		{
			get { return _fileSuffix; }
			set
			{
				if ((_fileSuffix == null) || (value == null) || (!value.Equals(_fileSuffix)))
				{
                    object oldValue = _fileSuffix;
					_fileSuffix = value;
					RaisePropertyChanged(SysFile.Prop_FileSuffix, oldValue, value);
				}
			}

		}

		[Property("FileFullPath", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 300)]
		public string FileFullPath
		{
			get { return _fileFullPath; }
			set
			{
				if ((_fileFullPath == null) || (value == null) || (!value.Equals(_fileFullPath)))
				{
                    object oldValue = _fileFullPath;
					_fileFullPath = value;
					RaisePropertyChanged(SysFile.Prop_FileFullPath, oldValue, value);
				}
			}

		}

		[Property("Length", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
		public int? Length
		{
			get { return _length; }
			set
			{
				if (value != _length)
				{
                    object oldValue = _length;
					_length = value;
					RaisePropertyChanged(SysFile.Prop_Length, oldValue, value);
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
					RaisePropertyChanged(SysFile.Prop_State, oldValue, value);
				}
			}

		}

		[Property("CreateID", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 36)]
		public string CreateID
		{
			get { return _createID; }
			set
			{
				if ((_createID == null) || (value == null) || (!value.Equals(_createID)))
				{
                    object oldValue = _createID;
					_createID = value;
					RaisePropertyChanged(SysFile.Prop_CreateID, oldValue, value);
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
					RaisePropertyChanged(SysFile.Prop_CreateName, oldValue, value);
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
					RaisePropertyChanged(SysFile.Prop_CreateTime, oldValue, value);
				}
			}

		}

		#endregion
	} // SysFile
}

