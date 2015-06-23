// Business class SysModule generated from SysModule
// Creator: WGM
// Created Date: [2015-03-14]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;
using Razor.Data;

namespace DataModel
{
    [ActiveRecord("SysModule")]
    public partial class SysModule : ModelBase<SysModule>
    {
        #region Property_Names

        public static string Prop_ID = "ID";
        public static string Prop_Code = "Code";
        public static string Prop_Name = "Name";
        public static string Prop_Type = "Type";
        public static string Prop_ParentID = "ParentID";
        public static string Prop_Path = "Path";
        public static string Prop_PathLevel = "PathLevel";
        public static string Prop_IsLeaf = "IsLeaf";
        public static string Prop_Url = "Url";
        public static string Prop_Icon = "Icon";
        public static string Prop_Description = "Description";
        public static string Prop_Status = "Status";
        public static string Prop_IsSystem = "IsSystem";
        public static string Prop_SortIndex = "SortIndex";
        public static string Prop_IsEntityPage = "IsEntityPage";
        public static string Prop_IsQuickSearch = "IsQuickSearch";
        public static string Prop_IsQuickCreate = "IsQuickCreate";
        public static string Prop_IsRecyclable = "IsRecyclable";
        public static string Prop_Ext1 = "Ext1";
        public static string Prop_LastModifiedDate = "LastModifiedDate";
        public static string Prop_CreateDate = "CreateDate";

        #endregion

        #region Private_Variables

        private string _id;
        private string _code;
        private string _name;
        private int? _type;
        private string _parentID;
        private string _path;
        private int? _pathLevel;
        private bool? _isLeaf;
        private string _url;
        private string _icon;
        private string _description;
        private byte? _status;
        private byte? _isSystem;
        private int? _sortIndex;
        private bool? _isEntityPage;
        private bool? _isQuickSearch;
        private bool? _isQuickCreate;
        private bool? _isRecyclable;
        private string _ext1;
        private DateTime? _lastModifiedDate;
        private DateTime? _createDate;


        #endregion

        #region Constructors

        public SysModule()
        {
        }

        public SysModule(
            string p_id,
            string p_code,
            string p_name,
            int? p_type,
            string p_parentID,
            string p_path,
            int? p_pathLevel,
            bool? p_isLeaf,
            string p_url,
            string p_icon,
            string p_description,
            byte? p_status,
            byte? p_isSystem,
            int? p_sortIndex,
            bool? p_isEntityPage,
            bool? p_isQuickSearch,
            bool? p_isQuickCreate,
            bool? p_isRecyclable,
            string p_ext1,
            DateTime? p_lastModifiedDate,
            DateTime? p_createDate)
        {
            _id = p_id;
            _code = p_code;
            _name = p_name;
            _type = p_type;
            _parentID = p_parentID;
            _path = p_path;
            _pathLevel = p_pathLevel;
            _isLeaf = p_isLeaf;
            _url = p_url;
            _icon = p_icon;
            _description = p_description;
            _status = p_status;
            _isSystem = p_isSystem;
            _sortIndex = p_sortIndex;
            _isEntityPage = p_isEntityPage;
            _isQuickSearch = p_isQuickSearch;
            _isQuickCreate = p_isQuickCreate;
            _isRecyclable = p_isRecyclable;
            _ext1 = p_ext1;
            _lastModifiedDate = p_lastModifiedDate;
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
                    RaisePropertyChanged(SysModule.Prop_Code, oldValue, value);
                }
            }

        }

        [Property("Name", Access = PropertyAccess.NosetterCamelcaseUnderscore, NotNull = true, Length = 50)]
        public string Name
        {
            get { return _name; }
            set
            {
                if ((_name == null) || (value == null) || (!value.Equals(_name)))
                {
                    object oldValue = _name;
                    _name = value;
                    RaisePropertyChanged(SysModule.Prop_Name, oldValue, value);
                }
            }

        }

        [Property("Type", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public int? Type
        {
            get { return _type; }
            set
            {
                if (value != _type)
                {
                    object oldValue = _type;
                    _type = value;
                    RaisePropertyChanged(SysModule.Prop_Type, oldValue, value);
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
                    RaisePropertyChanged(SysModule.Prop_ParentID, oldValue, value);
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
                    RaisePropertyChanged(SysModule.Prop_Path, oldValue, value);
                }
            }

        }

        [Property("PathLevel", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public int? PathLevel
        {
            get { return _pathLevel; }
            set
            {
                if (value != _pathLevel)
                {
                    object oldValue = _pathLevel;
                    _pathLevel = value;
                    RaisePropertyChanged(SysModule.Prop_PathLevel, oldValue, value);
                }
            }

        }

        [Property("IsLeaf", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public bool? IsLeaf
        {
            get { return _isLeaf; }
            set
            {
                if (value != _isLeaf)
                {
                    object oldValue = _isLeaf;
                    _isLeaf = value;
                    RaisePropertyChanged(SysModule.Prop_IsLeaf, oldValue, value);
                }
            }

        }

        [Property("Url", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 500)]
        public string Url
        {
            get { return _url; }
            set
            {
                if ((_url == null) || (value == null) || (!value.Equals(_url)))
                {
                    object oldValue = _url;
                    _url = value;
                    RaisePropertyChanged(SysModule.Prop_Url, oldValue, value);
                }
            }

        }

        [Property("Icon", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 500)]
        public string Icon
        {
            get { return _icon; }
            set
            {
                if ((_icon == null) || (value == null) || (!value.Equals(_icon)))
                {
                    object oldValue = _icon;
                    _icon = value;
                    RaisePropertyChanged(SysModule.Prop_Icon, oldValue, value);
                }
            }

        }

        [Property("Description", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 500)]
        public string Description
        {
            get { return _description; }
            set
            {
                if ((_description == null) || (value == null) || (!value.Equals(_description)))
                {
                    object oldValue = _description;
                    _description = value;
                    RaisePropertyChanged(SysModule.Prop_Description, oldValue, value);
                }
            }

        }

        [Property("Status", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public byte? Status
        {
            get { return _status; }
            set
            {
                if (value != _status)
                {
                    object oldValue = _status;
                    _status = value;
                    RaisePropertyChanged(SysModule.Prop_Status, oldValue, value);
                }
            }

        }

        [Property("IsSystem", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public byte? IsSystem
        {
            get { return _isSystem; }
            set
            {
                if (value != _isSystem)
                {
                    object oldValue = _isSystem;
                    _isSystem = value;
                    RaisePropertyChanged(SysModule.Prop_IsSystem, oldValue, value);
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
                    RaisePropertyChanged(SysModule.Prop_SortIndex, oldValue, value);
                }
            }

        }

        [Property("IsEntityPage", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public bool? IsEntityPage
        {
            get { return _isEntityPage; }
            set
            {
                if (value != _isEntityPage)
                {
                    object oldValue = _isEntityPage;
                    _isEntityPage = value;
                    RaisePropertyChanged(SysModule.Prop_IsEntityPage, oldValue, value);
                }
            }

        }

        [Property("IsQuickSearch", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public bool? IsQuickSearch
        {
            get { return _isQuickSearch; }
            set
            {
                if (value != _isQuickSearch)
                {
                    object oldValue = _isQuickSearch;
                    _isQuickSearch = value;
                    RaisePropertyChanged(SysModule.Prop_IsQuickSearch, oldValue, value);
                }
            }

        }

        [Property("IsQuickCreate", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public bool? IsQuickCreate
        {
            get { return _isQuickCreate; }
            set
            {
                if (value != _isQuickCreate)
                {
                    object oldValue = _isQuickCreate;
                    _isQuickCreate = value;
                    RaisePropertyChanged(SysModule.Prop_IsQuickCreate, oldValue, value);
                }
            }

        }

        [Property("IsRecyclable", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public bool? IsRecyclable
        {
            get { return _isRecyclable; }
            set
            {
                if (value != _isRecyclable)
                {
                    object oldValue = _isRecyclable;
                    _isRecyclable = value;
                    RaisePropertyChanged(SysModule.Prop_IsRecyclable, oldValue, value);
                }
            }

        }

        [Property("Ext1", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 4000)]
        public string Ext1
        {
            get { return _ext1; }
            set
            {
                if ((_ext1 == null) || (value == null) || (!value.Equals(_ext1)))
                {
                    object oldValue = _ext1;
                    _ext1 = value;
                    RaisePropertyChanged(SysModule.Prop_Ext1, oldValue, value);
                }
            }

        }

        [Property("LastModifiedDate", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public DateTime? LastModifiedDate
        {
            get { return _lastModifiedDate; }
            set
            {
                if (value != _lastModifiedDate)
                {
                    object oldValue = _lastModifiedDate;
                    _lastModifiedDate = value;
                    RaisePropertyChanged(SysModule.Prop_LastModifiedDate, oldValue, value);
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
                    RaisePropertyChanged(SysModule.Prop_CreateDate, oldValue, value);
                }
            }

        }

        #endregion
    } // SysModule
}

