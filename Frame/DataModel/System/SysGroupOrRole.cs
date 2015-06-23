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
	public partial class SysGroupOrRole
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
			SysGroupOrRole[] tents = SysGroupOrRole.FindAll(Expression.In("ID", args));

			foreach (SysGroupOrRole tent in tents)
			{
				tent.DoDelete();
			}
        }
		
        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount()
        {
            return ActiveRecordMediator.Count(typeof(SysGroupOrRole));
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount(params ICriterion[] ICrit)
        {
            return ActiveRecordMediator.Count(typeof(SysGroupOrRole), ICrit);
        }
        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount(string fileter, params object[] objects)
        {
            return ActiveRecordMediator.Count(typeof(SysGroupOrRole), fileter, objects);
        }

        #endregion

    } // SysGroupOrRole
}


