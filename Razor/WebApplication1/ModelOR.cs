using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Castle.ActiveRecord;

namespace Model
{
    [ActiveRecord("SurveyedResult")]
    public class SurveyedResult : ActiveRecordBase
    {
        #region Property_Names

        public static string Prop_Id = "Id";
        public static string Prop_SurveyId = "SurveyId";
        public static string Prop_SurveyName = "SurveyName";
        public static string Prop_QuestionId = "QuestionId";
        public static string Prop_QuestionName = "QuestionName";
        public static string Prop_QuestionItemId = "QuestionItemId";
        public static string Prop_QuestionItemName = "QuestionItemName";
        public static string Prop_QuestionContent = "QuestionContent";
        public static string Prop_QuestionItemContent = "QuestionItemContent";
        public static string Prop_UserId = "UserId";
        public static string Prop_UserName = "UserName";
        public static string Prop_CreateTime = "CreateTime";

        #endregion

        #region Private_Variables

        private string _id;
        private string _surveyId;
        private string _surveyName;
        private string _questionId;
        private string _questionName;
        private string _questionItemId;
        private string _questionItemName;
        private string _questionContent;
        private string _questionItemContent;
        private string _userId;
        private string _userName;
        private DateTime? _createTime;


        #endregion

        #region Constructors

        public SurveyedResult()
        {
        }

        public SurveyedResult(
            string p_id,
            string p_surveyId,
            string p_surveyName,
            string p_questionId,
            string p_questionName,
            string p_questionItemId,
            string p_questionItemName,
            string p_questionContent,
            string p_questionItemContent,
            string p_userId,
            string p_userName,
            DateTime? p_createTime)
        {
            _id = p_id;
            _surveyId = p_surveyId;
            _surveyName = p_surveyName;
            _questionId = p_questionId;
            _questionName = p_questionName;
            _questionItemId = p_questionItemId;
            _questionItemName = p_questionItemName;
            _questionContent = p_questionContent;
            _questionItemContent = p_questionItemContent;
            _userId = p_userId;
            _userName = p_userName;
            _createTime = p_createTime;
        }

        #endregion

        #region Properties

        [PrimaryKey("Id", Access = PropertyAccess.NosetterLowercaseUnderscore)]
        public string Id
        {
            get { return _id; }
            set { _id = value; } // 处理列表编辑时去掉注释

        }

        [Property("SurveyId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string SurveyId
        {
            get { return _surveyId; }
            set
            {
                if ((_surveyId == null) || (value == null) || (!value.Equals(_surveyId)))
                {
                    object oldValue = _surveyId;
                    _surveyId = value;
                }
            }

        }

        [Property("SurveyName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 500)]
        public string SurveyName
        {
            get { return _surveyName; }
            set
            {
                if ((_surveyName == null) || (value == null) || (!value.Equals(_surveyName)))
                {
                    object oldValue = _surveyName;
                    _surveyName = value;
                }
            }

        }

        [Property("QuestionId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 500)]
        public string QuestionId
        {
            get { return _questionId; }
            set
            {
                if ((_questionId == null) || (value == null) || (!value.Equals(_questionId)))
                {
                    object oldValue = _questionId;
                    _questionId = value;
                }
            }

        }

        [Property("QuestionName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 3000)]
        public string QuestionName
        {
            get { return _questionName; }
            set
            {
                if ((_questionName == null) || (value == null) || (!value.Equals(_questionName)))
                {
                    object oldValue = _questionName;
                    _questionName = value;
                }
            }

        }

        [Property("QuestionItemId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 2000)]
        public string QuestionItemId
        {
            get { return _questionItemId; }
            set
            {
                if ((_questionItemId == null) || (value == null) || (!value.Equals(_questionItemId)))
                {
                    object oldValue = _questionItemId;
                    _questionItemId = value;
                }
            }

        }

        [Property("QuestionItemName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 4000)]
        public string QuestionItemName
        {
            get { return _questionItemName; }
            set
            {
                if ((_questionItemName == null) || (value == null) || (!value.Equals(_questionItemName)))
                {
                    object oldValue = _questionItemName;
                    _questionItemName = value;
                }
            }

        }

        [Property("QuestionContent", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 2000)]
        public string QuestionContent
        {
            get { return _questionContent; }
            set
            {
                if ((_questionContent == null) || (value == null) || (!value.Equals(_questionContent)))
                {
                    object oldValue = _questionContent;
                    _questionContent = value;
                }
            }

        }

        [Property("QuestionItemContent", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 2000)]
        public string QuestionItemContent
        {
            get { return _questionItemContent; }
            set
            {
                if ((_questionItemContent == null) || (value == null) || (!value.Equals(_questionItemContent)))
                {
                    object oldValue = _questionItemContent;
                    _questionItemContent = value;
                }
            }

        }

        [Property("UserId", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 50)]
        public string UserId
        {
            get { return _userId; }
            set
            {
                if ((_userId == null) || (value == null) || (!value.Equals(_userId)))
                {
                    object oldValue = _userId;
                    _userId = value;
                }
            }

        }

        [Property("UserName", Access = PropertyAccess.NosetterCamelcaseUnderscore, Length = 100)]
        public string UserName
        {
            get { return _userName; }
            set
            {
                if ((_userName == null) || (value == null) || (!value.Equals(_userName)))
                {
                    object oldValue = _userName;
                    _userName = value;
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
                }
            }

        }

        #endregion
        #region 公共方法

        /// <summary>
        /// 验证操作
        /// </summary>
        public void DoValidate()
        {
            // 检查是否存在重复键
            /*if (!this.IsPropertyUnique("UniqueKey"))
            {
                throw new RepeatedKeyException("存在重复的 UniqueKey “" + this.UniqueKey + "”");
            }*/
        }

        /// <summary>
        /// 保存
        /// </summary>
        public void DoSave()
        {
            if (String.IsNullOrEmpty(Id))
            {
                this.DoCreate();
            }
            else
            {
                this.DoUpdate();
            }
        }

        /// <summary>
        /// 创建操作
        /// </summary>
        public void DoCreate()
        {
            this.DoValidate();

            this.CreateTime = DateTime.Now;

            // 事务开始
            this.CreateAndFlush();
        }

        /// <summary>
        /// 修改操作
        /// </summary>
        /// <returns></returns>
        public void DoUpdate()
        {
            this.DoValidate();


            this.UpdateAndFlush();
        }

        /// <summary>
        /// 删除操作
        /// </summary>
        public void DoDelete()
        {
            this.Delete();
        }

        public static SurveyedResult[] FindAll()
        {
            return ((SurveyedResult[])(ActiveRecordBase.FindAll(typeof(SurveyedResult))));
        }

        #endregion
    }
}