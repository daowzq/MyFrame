using Castle.ActiveRecord;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Razor.Data;
using NHibernate.Transform;
using NHibernate.Criterion;
using Razor;

namespace DataModel
{
    [Serializable]
    public abstract class ModelBase<T> : EntityBase<T> where T : ModelBase<T>, new()
    {
        /// <summary>
        /// 查询, 需要写Where 关键字
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="withwhereString"></param>
        /// <returns></returns>
        public static IList<T> GetOtherMap(string tableName, string withwhereString)
        {
            string query = string.Format("select * from {0} {1}", tableName, withwhereString);
            return (IList<T>)ActiveRecordMediator<T>.Execute(
                delegate(ISession session, object instance)
                {
                    //return session.CreateSQLQuery(query, "synonym", typeof(SmartDeal)).List<SmartDeal>();   
                    return session.CreateSQLQuery(query).AddEntity("synonym", typeof(T)).List<T>();
                }, new T());
        }
    }
}
