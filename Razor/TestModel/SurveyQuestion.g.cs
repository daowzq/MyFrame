// Business class SurveyQuestion generated from SurveyQuestion
// Creator: Ray
// Created Date: [2013-10-23]

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Castle.ActiveRecord;
using Razor.DataHelper;

namespace TestModel
{
    [ActiveRecord("SurveyQuestion")]
    public partial class SurveyQuestion : EntityBase<SurveyQuestion>
    {
        #region Property_Names

        public static string Prop_Id = "Id";
        public static string Prop_SurveyTypeId = "SurveyTypeId";
        public static string Prop_SurveyTypeName = "SurveyTypeName";
        public static string Prop_SurveyTitile = "SurveyTitile";
        public static string Prop_TypeCode = "TypeCode";
        public static string Prop_Description = "Description";
        public static string Prop_StartTime = "StartTime";
        public static string Prop_EndTime = "EndTime";
        public static string Prop_NoticeWay = "NoticeWay";
        public static string Prop_RemindWay = "RemindWay";
        public static string Prop_EffectiveCount = "EffectiveCount";
        public static string Prop_EffectiveRate = "EffectiveRate";
        public static string Prop_AwardRate = "AwardRate";
        public static string Prop_IsNoName = "IsNoName";
        public static string Prop_IsSendRandom = "IsSendRandom";
        public static string Prop_TemplateId = "TemplateId";
        public static string Prop_TemplateName = "TemplateName";
        public static string Prop_AddFilesId = "AddFilesId";
        public static string Prop_AddFilesName = "AddFilesName";
        public static string Prop_WorkFlowCode = "WorkFlowCode";
        public static string Prop_WorkFlowName = "WorkFlowName";
        public static string Prop_WorkFlowState = "WorkFlowState";
        public static string Prop_WorlFlowResult = "WorlFlowResult";
        public static string Prop_UrgencyDegree = "UrgencyDegree";
        public static string Prop_SetTimeout = "SetTimeout";
        public static string Prop_RecyleDay = "RecyleDay";
        public static string Prop_TimePoint = "TimePoint";
        public static string Prop_CompanyId = "CompanyId";
        public static string Prop_CompanyName = "CompanyName";
        public static string Prop_State = "State";
        public static string Prop_IsFixed = "IsFixed";
        public static string Prop_DeptId = "DeptId";
        public static string Prop_DeptName = "DeptName";
        public static string Prop_CreateId = "CreateId";
        public static string Prop_Score = "Score";
        public static string Prop_ReaderObj = "ReaderObj";
        public static string Prop_CreateName = "CreateName";
        public static string Prop_CreateTime = "CreateTime";
        public static string Prop_TurnSurveyId = "TurnSurveyId";
        public static string Prop_GrantCorpId = "GrantCorpId";
        public static string Prop_GrantCorpName = "GrantCorpName";
        public static string Prop_OARef = "OARef";

        #endregion

        #region Private_Variables

        private string _id;
        private string _surveyTypeId;
        private string _surveyTypeName;
        private string _surveyTitile;
        private string _typeCode;
        private string _description;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private string _noticeWay;
        private string _remindWay;
        private int? _effectiveCount;
        private int? _effectiveRate;
        private int? _awardRate;
        private string _isNoName;
        private string _isSendRandom;
        private string _templateId;
        private string _templateName;
        private string _addFilesId;
        private string _addFilesName;
        private string _workFlowCode;
        private string _workFlowName;
        private string _workFlowState;
        private string _worlFlowResult;
        private string _urgencyDegree;
        private DateTime? _setTimeout;
        private int? _recyleDay;
        private string _timePoint;
        private string _companyId;
        private string _companyName;
        private string _state;
        private string _isFixed;
        private string _deptId;
        private string _deptName;
        private string _createId;
        private int? _score;
        private string _readerObj;
        private string _createName;
        private DateTime? _createTime;
        private string _turnSurveyId;
        private string _grantCorpId;
        private string _grantCorpName;
        private string _oARef;


        #endregion

        #region Constructors

        public SurveyQuestion()
        {
        }

        public SurveyQuestion(
            string p_id,
            string p_surveyTypeId,
            string p_surveyTypeName,
            string p_surveyTitile,
            string p_typeCode,
            string p_description,
            DateTime? p_startTime,
            DateTime? p_endTime,
            string p_noticeWay,
            string p_remindWay,
            int? p_effectiveCount,
            int? p_effectiveRate,
            int? p_awardRate,
            string p_isNoName,
            string p_isSendRandom,
            string p_templateId,
            string p_templateName,
            string p_addFilesId,
            string p_addFilesName,
            string p_workFlowCode,
            string p_workFlowName,
            string p_workFlowState,
            string p_worlFlowResult,
            string p_urgencyDegree,
            DateTime? p_setTimeout,
            int? p_recyleDay,
            string p_timePoint,
            string p_companyId,
            string p_companyName,
            string p_state,
            string p_isFixed,
            string p_deptId,
            string p_deptName,
            string p_createId,
            int? p_score,
            string p_readerObj,
            string p_createName,
            DateTime? p_createTime,
            string p_turnSurveyId,
            string p_grantCorpId,
            string p_grantCorpName,
            string p_oARef)
        {
            _id = p_id;
            _surveyTypeId = p_surveyTypeId;
            _surveyTypeName = p_surveyTypeName;
            _surveyTitile = p_surveyTitile;
            _typeCode = p_typeCode;
            _description = p_description;
            _startTime = p_startTime;
            _endTime = p_endTime;
            _noticeWay = p_noticeWay;
            _remindWay = p_remindWay;
            _effectiveCount = p_effectiveCount;
            _effectiveRate = p_effectiveRate;
            _awardRate = p_awardRate;
            _isNoName = p_isNoName;
            _isSendRandom = p_isSendRandom;
            _templateId = p_templateId;
            _templateName = p_templateName;
            _addFilesId = p_addFilesId;
            _addFilesName = p_addFilesName;
            _workFlowCode = p_workFlowCode;
            _workFlowName = p_workFlowName;
            _workFlowState = p_workFlowState;
            _worlFlowResult = p_worlFlowResult;
            _urgencyDegree = p_urgencyDegree;
            _setTimeout = p_setTimeout;
            _recyleDay = p_recyleDay;
            _timePoint = p_timePoint;
            _companyId = p_companyId;
            _companyName = p_companyName;
            _state = p_state;
            _isFixed = p_isFixed;
            _deptId = p_deptId;
            _deptName = p_deptName;
            _createId = p_createId;
            _score = p_score;
            _readerObj = p_readerObj;
            _createName = p_createName;
            _createTime = p_createTime;
            _turnSurveyId = p_turnSurveyId;
            _grantCorpId = p_grantCorpId;
            _grantCorpName = p_grantCorpName;
            _oARef = p_oARef;
        }

        #endregion

        #region Properties

        [PrimaryKey("Id", Generator = PrimaryKeyType.Custom, CustomGenerator = typeof(RazorIdentifierGenerator), Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public string Id
        {
            get { return _id; }
            set { _id = value; } // 处理列表编辑时去掉注释

        }

        [Property("SurveyTypeId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 36)]
        public string SurveyTypeId
        {
            get { return _surveyTypeId; }
            set
            {
                if ((_surveyTypeId == null) || (value == null) || (!value.Equals(_surveyTypeId)))
                {
                    object oldValue = _surveyTypeId;
                    _surveyTypeId = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_SurveyTypeId, oldValue, value);
                }
            }

        }

        [Property("SurveyTypeName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
        public string SurveyTypeName
        {
            get { return _surveyTypeName; }
            set
            {
                if ((_surveyTypeName == null) || (value == null) || (!value.Equals(_surveyTypeName)))
                {
                    object oldValue = _surveyTypeName;
                    _surveyTypeName = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_SurveyTypeName, oldValue, value);
                }
            }

        }

        [Property("SurveyTitile", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 200)]
        public string SurveyTitile
        {
            get { return _surveyTitile; }
            set
            {
                if ((_surveyTitile == null) || (value == null) || (!value.Equals(_surveyTitile)))
                {
                    object oldValue = _surveyTitile;
                    _surveyTitile = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_SurveyTitile, oldValue, value);
                }
            }

        }

        [Property("TypeCode", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string TypeCode
        {
            get { return _typeCode; }
            set
            {
                if ((_typeCode == null) || (value == null) || (!value.Equals(_typeCode)))
                {
                    object oldValue = _typeCode;
                    _typeCode = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_TypeCode, oldValue, value);
                }
            }

        }

        [Property("Description", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 2000)]
        public string Description
        {
            get { return _description; }
            set
            {
                if ((_description == null) || (value == null) || (!value.Equals(_description)))
                {
                    object oldValue = _description;
                    _description = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_Description, oldValue, value);
                }
            }

        }

        [Property("StartTime", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public DateTime? StartTime
        {
            get { return _startTime; }
            set
            {
                if (value != _startTime)
                {
                    object oldValue = _startTime;
                    _startTime = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_StartTime, oldValue, value);
                }
            }

        }

        [Property("EndTime", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public DateTime? EndTime
        {
            get { return _endTime; }
            set
            {
                if (value != _endTime)
                {
                    object oldValue = _endTime;
                    _endTime = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_EndTime, oldValue, value);
                }
            }

        }

        [Property("NoticeWay", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 20)]
        public string NoticeWay
        {
            get { return _noticeWay; }
            set
            {
                if ((_noticeWay == null) || (value == null) || (!value.Equals(_noticeWay)))
                {
                    object oldValue = _noticeWay;
                    _noticeWay = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_NoticeWay, oldValue, value);
                }
            }

        }

        [Property("RemindWay", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string RemindWay
        {
            get { return _remindWay; }
            set
            {
                if ((_remindWay == null) || (value == null) || (!value.Equals(_remindWay)))
                {
                    object oldValue = _remindWay;
                    _remindWay = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_RemindWay, oldValue, value);
                }
            }

        }

        [Property("EffectiveCount", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public int? EffectiveCount
        {
            get { return _effectiveCount; }
            set
            {
                if (value != _effectiveCount)
                {
                    object oldValue = _effectiveCount;
                    _effectiveCount = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_EffectiveCount, oldValue, value);
                }
            }

        }

        [Property("EffectiveRate", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public int? EffectiveRate
        {
            get { return _effectiveRate; }
            set
            {
                if (value != _effectiveRate)
                {
                    object oldValue = _effectiveRate;
                    _effectiveRate = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_EffectiveRate, oldValue, value);
                }
            }

        }

        [Property("AwardRate", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public int? AwardRate
        {
            get { return _awardRate; }
            set
            {
                if (value != _awardRate)
                {
                    object oldValue = _awardRate;
                    _awardRate = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_AwardRate, oldValue, value);
                }
            }

        }

        [Property("IsNoName", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public string IsNoName
        {
            get { return _isNoName; }
            set
            {
                if ((_isNoName == null) || (value == null) || (!value.Equals(_isNoName)))
                {
                    object oldValue = _isNoName;
                    _isNoName = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_IsNoName, oldValue, value);
                }
            }

        }

        [Property("IsSendRandom", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public string IsSendRandom
        {
            get { return _isSendRandom; }
            set
            {
                if ((_isSendRandom == null) || (value == null) || (!value.Equals(_isSendRandom)))
                {
                    object oldValue = _isSendRandom;
                    _isSendRandom = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_IsSendRandom, oldValue, value);
                }
            }

        }

        [Property("TemplateId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
        public string TemplateId
        {
            get { return _templateId; }
            set
            {
                if ((_templateId == null) || (value == null) || (!value.Equals(_templateId)))
                {
                    object oldValue = _templateId;
                    _templateId = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_TemplateId, oldValue, value);
                }
            }

        }

        [Property("TemplateName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
        public string TemplateName
        {
            get { return _templateName; }
            set
            {
                if ((_templateName == null) || (value == null) || (!value.Equals(_templateName)))
                {
                    object oldValue = _templateName;
                    _templateName = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_TemplateName, oldValue, value);
                }
            }

        }

        [Property("AddFilesId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
        public string AddFilesId
        {
            get { return _addFilesId; }
            set
            {
                if ((_addFilesId == null) || (value == null) || (!value.Equals(_addFilesId)))
                {
                    object oldValue = _addFilesId;
                    _addFilesId = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_AddFilesId, oldValue, value);
                }
            }

        }

        [Property("AddFilesName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 1000)]
        public string AddFilesName
        {
            get { return _addFilesName; }
            set
            {
                if ((_addFilesName == null) || (value == null) || (!value.Equals(_addFilesName)))
                {
                    object oldValue = _addFilesName;
                    _addFilesName = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_AddFilesName, oldValue, value);
                }
            }

        }

        [Property("WorkFlowCode", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string WorkFlowCode
        {
            get { return _workFlowCode; }
            set
            {
                if ((_workFlowCode == null) || (value == null) || (!value.Equals(_workFlowCode)))
                {
                    object oldValue = _workFlowCode;
                    _workFlowCode = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_WorkFlowCode, oldValue, value);
                }
            }

        }

        [Property("WorkFlowName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string WorkFlowName
        {
            get { return _workFlowName; }
            set
            {
                if ((_workFlowName == null) || (value == null) || (!value.Equals(_workFlowName)))
                {
                    object oldValue = _workFlowName;
                    _workFlowName = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_WorkFlowName, oldValue, value);
                }
            }

        }

        [Property("WorkFlowState", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string WorkFlowState
        {
            get { return _workFlowState; }
            set
            {
                if ((_workFlowState == null) || (value == null) || (!value.Equals(_workFlowState)))
                {
                    object oldValue = _workFlowState;
                    _workFlowState = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_WorkFlowState, oldValue, value);
                }
            }

        }

        [Property("WorlFlowResult", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string WorlFlowResult
        {
            get { return _worlFlowResult; }
            set
            {
                if ((_worlFlowResult == null) || (value == null) || (!value.Equals(_worlFlowResult)))
                {
                    object oldValue = _worlFlowResult;
                    _worlFlowResult = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_WorlFlowResult, oldValue, value);
                }
            }

        }

        [Property("UrgencyDegree", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string UrgencyDegree
        {
            get { return _urgencyDegree; }
            set
            {
                if ((_urgencyDegree == null) || (value == null) || (!value.Equals(_urgencyDegree)))
                {
                    object oldValue = _urgencyDegree;
                    _urgencyDegree = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_UrgencyDegree, oldValue, value);
                }
            }

        }

        [Property("SetTimeout", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public DateTime? SetTimeout
        {
            get { return _setTimeout; }
            set
            {
                if (value != _setTimeout)
                {
                    object oldValue = _setTimeout;
                    _setTimeout = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_SetTimeout, oldValue, value);
                }
            }

        }

        [Property("RecyleDay", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public int? RecyleDay
        {
            get { return _recyleDay; }
            set
            {
                if (value != _recyleDay)
                {
                    object oldValue = _recyleDay;
                    _recyleDay = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_RecyleDay, oldValue, value);
                }
            }

        }

        [Property("TimePoint", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string TimePoint
        {
            get { return _timePoint; }
            set
            {
                if ((_timePoint == null) || (value == null) || (!value.Equals(_timePoint)))
                {
                    object oldValue = _timePoint;
                    _timePoint = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_TimePoint, oldValue, value);
                }
            }

        }

        [Property("CompanyId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 36)]
        public string CompanyId
        {
            get { return _companyId; }
            set
            {
                if ((_companyId == null) || (value == null) || (!value.Equals(_companyId)))
                {
                    object oldValue = _companyId;
                    _companyId = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_CompanyId, oldValue, value);
                }
            }

        }

        [Property("CompanyName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                if ((_companyName == null) || (value == null) || (!value.Equals(_companyName)))
                {
                    object oldValue = _companyName;
                    _companyName = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_CompanyName, oldValue, value);
                }
            }

        }

        [Property("State", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public string State
        {
            get { return _state; }
            set
            {
                if ((_state == null) || (value == null) || (!value.Equals(_state)))
                {
                    object oldValue = _state;
                    _state = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_State, oldValue, value);
                }
            }

        }

        [Property("IsFixed", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public string IsFixed
        {
            get { return _isFixed; }
            set
            {
                if ((_isFixed == null) || (value == null) || (!value.Equals(_isFixed)))
                {
                    object oldValue = _isFixed;
                    _isFixed = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_IsFixed, oldValue, value);
                }
            }

        }

        [Property("DeptId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 36)]
        public string DeptId
        {
            get { return _deptId; }
            set
            {
                if ((_deptId == null) || (value == null) || (!value.Equals(_deptId)))
                {
                    object oldValue = _deptId;
                    _deptId = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_DeptId, oldValue, value);
                }
            }

        }

        [Property("DeptName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string DeptName
        {
            get { return _deptName; }
            set
            {
                if ((_deptName == null) || (value == null) || (!value.Equals(_deptName)))
                {
                    object oldValue = _deptName;
                    _deptName = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_DeptName, oldValue, value);
                }
            }

        }

        [Property("CreateId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 36)]
        public string CreateId
        {
            get { return _createId; }
            set
            {
                if ((_createId == null) || (value == null) || (!value.Equals(_createId)))
                {
                    object oldValue = _createId;
                    _createId = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_CreateId, oldValue, value);
                }
            }

        }

        [Property("Score", Access = PropertyAccess.NosetterCamelcaseUnderscore)]
        public int? Score
        {
            get { return _score; }
            set
            {
                if (value != _score)
                {
                    object oldValue = _score;
                    _score = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_Score, oldValue, value);
                }
            }

        }

        [Property("ReaderObj", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string ReaderObj
        {
            get { return _readerObj; }
            set
            {
                if ((_readerObj == null) || (value == null) || (!value.Equals(_readerObj)))
                {
                    object oldValue = _readerObj;
                    _readerObj = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_ReaderObj, oldValue, value);
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
                    RaisePropertyChanged(SurveyQuestion.Prop_CreateName, oldValue, value);
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
                    RaisePropertyChanged(SurveyQuestion.Prop_CreateTime, oldValue, value);
                }
            }

        }

        [Property("TurnSurveyId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string TurnSurveyId
        {
            get { return _turnSurveyId; }
            set
            {
                if ((_turnSurveyId == null) || (value == null) || (!value.Equals(_turnSurveyId)))
                {
                    object oldValue = _turnSurveyId;
                    _turnSurveyId = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_TurnSurveyId, oldValue, value);
                }
            }

        }

        [Property("GrantCorpId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 2000)]
        public string GrantCorpId
        {
            get { return _grantCorpId; }
            set
            {
                if ((_grantCorpId == null) || (value == null) || (!value.Equals(_grantCorpId)))
                {
                    object oldValue = _grantCorpId;
                    _grantCorpId = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_GrantCorpId, oldValue, value);
                }
            }

        }

        [Property("GrantCorpName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 2000)]
        public string GrantCorpName
        {
            get { return _grantCorpName; }
            set
            {
                if ((_grantCorpName == null) || (value == null) || (!value.Equals(_grantCorpName)))
                {
                    object oldValue = _grantCorpName;
                    _grantCorpName = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_GrantCorpName, oldValue, value);
                }
            }

        }

        [Property("OARef", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string OARef
        {
            get { return _oARef; }
            set
            {
                if ((_oARef == null) || (value == null) || (!value.Equals(_oARef)))
                {
                    object oldValue = _oARef;
                    _oARef = value;
                    RaisePropertyChanged(SurveyQuestion.Prop_OARef, oldValue, value);
                }
            }

        }

        #endregion
    } // SurveyQuestion
}

