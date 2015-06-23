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

namespace DataModel
{
    /// <summary>
    /// 自定义实体类
    /// </summary>
    [Serializable]
    public partial class SysGroupUser
    {
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
            SysGroupUser[] tents = SysGroupUser.FindAll(Expression.In("ID", args));

            foreach (SysGroupUser tent in tents)
            {
                tent.DoDelete();
            }
        }
        public static void DoBatchDelete(string OrgID, string[] Ids)
        {
            SysGroupUser[] tents = SysGroupUser.FindAll(Expression.In("SysUserID", Ids), Expression.Eq("SysGroupID", OrgID));

            foreach (SysGroupUser tent in tents)
            {
                tent.DoDelete();
            }

        }
        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount()
        {
            return ActiveRecordMediator.Count(typeof(SysGroupUser));
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount(params ICriterion[] ICrit)
        {
            return ActiveRecordMediator.Count(typeof(SysGroupUser), ICrit);
        }
        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount(string fileter, params object[] objects)
        {
            return ActiveRecordMediator.Count(typeof(SysGroupUser), fileter, objects);
        }
        /// <summary>
        /// 获取关联的人员
        /// </summary>
        /// <param name="OrgUsers"></param>
        /// <returns></returns>
        public static IList<SysUser> GetUsersByEnts(SysGroupUser[] OrgR)
        {
            List<string> Ids = new List<string>();
            foreach (var item in OrgR)
            {
                Ids.Add("'" + item.SysUserID + "'");
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

    } // SysGroupUser
}


