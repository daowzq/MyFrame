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
using System.Text;

namespace DataModel
{
    /// <summary>
    /// 自定义实体类
    /// </summary>
    [Serializable]
    public partial class SysModule
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

            this.CreateDate = DateTime.Now;

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

            this.LastModifiedDate = DateTime.Now;

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
            SysModule[] tents = SysModule.FindAll(Expression.In("ID", args));

            foreach (SysModule tent in tents)
            {
                tent.DoDelete();
            }
        }

        public string GetNodePathById(string ID)
        {
            List<string> strb = new List<string>();
            var Ent = SysModule.Find(ID);
            strb.Add(ID);
            if (!string.IsNullOrEmpty(Ent.ParentID) && Ent.ParentID != "root")
            {
                strb.Add(Ent.ParentID);
                GetNodePathById(Ent.ParentID);
            }
            return string.Join("/", strb.Reverse<string>());
        }
        #endregion

    } // SysModule
}


