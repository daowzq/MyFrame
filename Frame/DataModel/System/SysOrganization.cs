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
    public partial class SysOrganization
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

            //this.CreateName = UserInfo.Name;
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
            SysOrganization[] tents = SysOrganization.FindAll(Expression.In("ID", args));

            foreach (SysOrganization tent in tents)
            {
                tent.DoDelete();
            }
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount()
        {
            return ActiveRecordMediator.Count(typeof(SysOrganization));
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount(params ICriterion[] ICrit)
        {
            return ActiveRecordMediator.Count(typeof(SysOrganization), ICrit);
        }
        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount(string fileter, params object[] objects)
        {
            return ActiveRecordMediator.Count(typeof(SysOrganization), fileter, objects);
        }

        /// <summary>
        /// 将人员关联到根节点
        /// </summary>
        /// <param name="RootEnt"></param>
        /// <returns></returns>
        public static int BindUserToRootNode(SysOrganization RootEnt)
        {

            using (TransactionScope trans = new TransactionScope())
            {
                //删除
                string SQL = "delete from SysOrgUser where OrgID='" + RootEnt.ID + "' ";
                Razor.DataHelper.ExecSql(SQL);

                var Arrs = SysUser.FindAll();
                SQL = "insert into SysOrgUser values('{0}','{1}','{2}','{3}','{4}');";
                StringBuilder strb = new StringBuilder();
                //添加
                foreach (var item in Arrs)
                {
                    //SysOrgUser Ent = new SysOrgUser();
                    //Ent.OrgID = RootEnt.ID;
                    //Ent.OrgName = RootEnt.Name;
                    //Ent.UserID = item.ID;
                    //Ent.UserName = item.Name;
                    //Ent.Create();
                    string ExeSql = string.Format(SQL, Guid.NewGuid().ToString(), RootEnt.ID, RootEnt.Name, item.ID, item.Name);
                    strb.Append(ExeSql);
                }
                Razor.DataHelper.ExecSql(strb.ToString());
                trans.VoteCommit();
            }
            return 1;
        }
        #endregion

    } // SysOrganization
}


