using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using Castle.ActiveRecord;
using Castle.ActiveRecord.Queries;
using Newtonsoft.Json;

namespace DataModel
{
    /// <summary>
    /// 自定义实体类
    /// </summary>
    [Serializable]
    public partial class SysOrgUser
    {
        #region 私有成员
        [NonSerialized]
        private IList<SysUser> _User = new List<SysUser>();
        #endregion

        #region 成员属性

        public IList<SysUser> User
        {
            get
            {
                return SysUser.GetOtherMap("SysUser", " where ID='" + this.UserID + "'");
            }
        }
        #endregion

        #region 成员方法
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
            if (String.IsNullOrEmpty(ID))
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



        #endregion

        #region 静态成员

        /// <summary>
        /// 批量删除操作
        /// </summary>
        public static void DoBatchDelete(params object[] args)
        {
            SysOrgUser[] tents = SysOrgUser.FindAll(Expression.In("ID", args));

            foreach (SysOrgUser tent in tents)
            {
                tent.DoDelete();
            }
        }

        /// <summary>
        /// 批量删除操作
        /// </summary>
        public static void DoBatchDelete(string OrgID, string[] Ids)
        {
            SysOrgUser[] tents = SysOrgUser.FindAll(Expression.In("UserID", Ids), Expression.Eq("OrgID", OrgID));

            foreach (SysOrgUser tent in tents)
            {
                tent.DoDelete();
            }

        }
        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount()
        {
            return ActiveRecordMediator.Count(typeof(SysOrgUser));
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount(params ICriterion[] ICrit)
        {
            return ActiveRecordMediator.Count(typeof(SysOrgUser), ICrit);
        }
        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount(string fileter, params object[] objects)
        {
            return ActiveRecordMediator.Count(typeof(SysOrgUser), fileter, objects);
        }

        /// <summary>
        /// 获取关联的人员
        /// </summary>
        /// <param name="OrgUsers"></param>
        /// <returns></returns>
        public static IList<SysUser> GetUsersByEnts(SysOrgUser[] OrgUsers)
        {
            List<string> Ids = new List<string>();
            foreach (var item in OrgUsers)
            {
                Ids.Add("'" + item.UserID + "'");
            }
            string Where = string.Empty;
            if (Ids.Count > 0)
            {
                Where = " where ID in (" + string.Join(",", Ids) + ") ";
            }
            else
            {
                Where = " where 1<>1";
            }
            return SysUser.GetOtherMap("SysUser", Where);
        }
        #endregion

    } // SysOrgUser
}


