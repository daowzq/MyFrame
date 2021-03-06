﻿using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;
using NHibernate;
using NHibernate.Criterion;
using Razor.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;

namespace Razor
{
    public class DataHelper
    {
        #region 获取连接字符串
        public static IDbConnection GetCurrentDbConnection()
        {
            return GetCurrentDbConnection(typeof(ActiveRecordBase));
        }
        public static IDbConnection GetCurrentDbConnection(Type arBaseType)
        {
            return ActiveRecordMediator.GetSessionFactoryHolder().GetSessionFactory(arBaseType).OpenStatelessSession().Connection;
        }
        #endregion

        #region 获取ISession
        public static IStatelessSession GetStateSession(Type arBaseType)
        {
            return ActiveRecordMediator.GetSessionFactoryHolder().GetSessionFactory(arBaseType).OpenStatelessSession();
        }
        public static ISession GetCurrSession()
        {
             
            return ActiveRecordMediator.GetSessionFactoryHolder().GetSessionFactory(typeof(ActiveRecordBase)).GetCurrentSession();
        }

        #endregion

        #region 数据的拷贝
        public static void CopyDataToDatabase(DataTable dt, SqlConnection sqlConn, string targetTable)
        {
            try
            {
                SqlBulkCopy copy = new SqlBulkCopy(GetCurrentDbConnection() as SqlConnection)
                {
                    DestinationTableName = targetTable
                };
                foreach (DataColumn column in dt.Columns)
                {
                    copy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }
                copy.WriteToServer(dt);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public static IList<EasyDictionary> DataTableToDictList(DataTable dt)
        {
            IList<EasyDictionary> list = new List<EasyDictionary>();
            foreach (DataRow row in dt.Rows)
            {
                EasyDictionary item = new EasyDictionary();
                foreach (DataColumn column in dt.Columns)
                {
                    item.Set(column.ColumnName, row[column]);
                }
                list.Add(item);
            }
            return list;
        }
        #endregion

        #region 分页相关
        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount<T>()
        {
            return ActiveRecordMediator.Count(typeof(T));
        }

        /// <summary>
        /// 获取行数
        /// </summary>
        public static int GetCount<T>(params ICriterion[] ICrit)
        {
            return ActiveRecordMediator.Count(typeof(T), ICrit);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public static T[] GetPageList<T>(int start, int pagesize, out int total)
        {
            Array array = null;
            total = ActiveRecordMediator.Count(typeof(T));
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="orders">new Order[] { new Order("CreateTime", false) }</param>
        /// <returns></returns>
        public static T[] GetPageList<T>(int start, int pagesize, out int total, Order[] orders)
        {
            Array array = null;
            total = ActiveRecordMediator.Count(typeof(T));
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, orders);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="Iquery">new DetachedQuery(SelectHql).SetParameter(....)</param>
        /// <returns></returns>
        public static T[] GetPageList<T>(int start, int pagesize, IDetachedQuery Iquery)
        {
            Array array = null;
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, Iquery);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="orders"></param>
        /// <param name="criteria">Expression.XX()</param>
        /// <returns></returns>
        public static T[] GetPageList<T>(int start, int pagesize, Order[] orders, out int total, params ICriterion[] criteria)
        {
            Array array = null;
            total = ActiveRecordMediator.Count(typeof(T), criteria);
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, orders, criteria);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="orders">new Order[] { new Order("CreateTime", false) }</param>
        /// <param name="criteria">Expression.XX()</param>
        /// <returns></returns>
        public static T[] GetPageList<T>(int start, int pagesize, Order[] orders, params ICriterion[] criteria)
        {
            Array array = null;
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, orders, criteria);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="criteria">Expression.XX()</param>
        /// <returns></returns>
        public static T[] GetPageList<T>(int start, int pagesize, out int total, params ICriterion[] criteria)
        {
            Array array = null;
            total = ActiveRecordMediator.Count(typeof(T), criteria);
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, criteria);
            return (T[])array;
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="criteria">Expression.XX()</param>
        /// <returns></returns>
        public static T[] GetPageList<T>(int start, int pagesize, params ICriterion[] criteria)
        {
            Array array = null;
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, criteria);
            return (T[])array;
        }
        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="start"></param>
        /// <param name="pagesize"></param>
        /// <param name="Hql">Hql语句</param>
        /// <returns></returns>
        public static T[] GetPageList<T>(int start, int pagesize, string Hql)
        {
            Array array = null;
            array = ActiveRecordMediator.SlicedFindAll(typeof(T), start, pagesize, new NHibernate.Impl.DetachedQuery(Hql));
            return (T[])array;
        }
        #endregion
        #region XML处理
        public static string DataTableToXML(DataTable dataTable)
        {
            MemoryStream w = null;
            XmlTextWriter writer = null;
            string str;
            try
            {
                w = new MemoryStream();
                writer = new XmlTextWriter(w, Encoding.Default);
                dataTable.WriteXml(writer);
                int length = (int)w.Length;
                byte[] buffer = new byte[length];
                w.Seek(0L, SeekOrigin.Begin);
                w.Read(buffer, 0, length);
                UTF8Encoding encoding = new UTF8Encoding();
                str = encoding.GetString(buffer).Trim();
            }
            catch
            {
                str = string.Empty;
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
            return str;
        }
        public static string DataTableToXMLItems(DataTable dataTable)
        {
            string xml = DataTableToXML(dataTable);
            XmlDocument document = new XmlDocument();
            document.LoadXml(xml);
            if (document.HasChildNodes)
            {
                xml = document.FirstChild.InnerXml;
            }
            return xml;
        }
        public static DataSet XMLToDataSet(string xmlData)
        {
            StringReader input = null;
            XmlTextReader reader = null;
            DataSet set2;
            try
            {
                DataSet set = new DataSet();
                input = new StringReader(xmlData);
                reader = new XmlTextReader(input);
                set.ReadXml(reader);
                set2 = set;
            }
            catch (Exception exception)
            {
                string message = exception.Message;
                set2 = null;
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
            return set2;
        }
        #endregion

        #region 存储过程
        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="spName">存储过程名</param>
        /// <param name="parameters">[param,paramVal....]</param>
        public static void ExecSp(string spName, params object[] parameters)
        {
            ExecSp(GetCurrentDbConnection(), spName, parameters);
        }
        public static void ExecSp(IDbConnection conn, string spName, params object[] parameters)
        {
            IDbCommand command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = spName;
            if (parameters.Length > 0)
            {
                if ((parameters.Length % 2) != 0)
                {
                    throw new DataException("参数数量不匹配!");
                }
                for (int i = 0; i < parameters.Length; i += 2)
                {
                    IDbDataParameter parameter = command.CreateParameter();
                    parameter.ParameterName = parameters[i].ToString();
                    parameter.Value = parameters[i + 1];
                    command.Parameters.Add(parameter);
                }
            }
            command.ExecuteNonQuery();
        }
        #endregion

        #region 执行SQL

        public static T ExecSql<T>(string sqlString)
        {
            return ExecSql<T>(sqlString, GetCurrentDbConnection());
        }

        public static object ExecSql(string sqlString)
        {
            return ExecSql(sqlString, GetCurrentDbConnection());
        }

        public static T ExecSql<T>(string sqlString, IDbConnection conn)
        {
            T local = default(T);
            object obj2 = QueryValue(sqlString, conn);
            if (obj2 != null)
            {
                local = (T)obj2;
            }
            return local;
        }
        /// <summary>
        /// 执行SQL,返回结果集的第一行第一列
        /// </summary>
        /// <param name="sqlString"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static object ExecSql(string sqlString, IDbConnection conn)
        {
            object obj2 = null;
            try
            {
                IDbCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = sqlString;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                obj2 = command.ExecuteScalar();
                if (DBNull.Value == obj2)
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }
            return obj2;
        }
        #endregion

        #region Query
        public static DataTable QueryDataTable(string sqlString)
        {
            IDbConnection currentDbConnection = GetCurrentDbConnection();
            return QueryDataTable(sqlString, currentDbConnection);
        }

        public static DataTable QueryDataTable(string sqlString, IDbConnection conn)
        {
            DataTable table2;
            try
            {
                DataTable table = new DataTable();
                IDbCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = sqlString;
                IDataReader reader = command.ExecuteReader();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                table.Load(reader);
                table2 = table;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }
            return table2;
        }

        public static EasyDictionary QueryDict(string sqlString)
        {
            return new EasyDictionary(QueryDataTable(sqlString));
        }

        public static EasyDictionary QueryDict(string sqlString, IDbConnection conn)
        {
            return new EasyDictionary(QueryDataTable(sqlString, conn));
        }

        public static EasyDictionary QueryDict(string sqlString, string keyField, string textField)
        {
            return new EasyDictionary(QueryDataTable(sqlString), keyField, textField);
        }

        public static EasyDictionary QueryDict(string sqlString, IDbConnection conn, string keyField, string textField)
        {
            return new EasyDictionary(QueryDataTable(sqlString, conn), keyField, textField);
        }

        public static IList<EasyDictionary> QueryDictList(string sqlString)
        {
            return DataTableToDictList(QueryDataTable(sqlString));
        }

        public static IList<object[]> QueryObjectsList(string sql)
        {
            DataTable table = QueryDataTable(sql);
            IList<object[]> list = new List<object[]>();
            foreach (DataRow row in table.Rows)
            {
                object[] item = new object[table.Columns.Count];
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    item[i] = row[i];
                }
                list.Add(item);
            }
            return list;
        }

        public static T QueryValue<T>(string sqlString)
        {
            return QueryValue<T>(sqlString, GetCurrentDbConnection());
        }

        public static object QueryValue(string sqlString)
        {
            return QueryValue(sqlString, GetCurrentDbConnection());
        }

        public static object QueryValue(string sqlString, IDbConnection conn)
        {
            object obj2 = null;
            try
            {
                IDbCommand command = conn.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = sqlString;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                obj2 = command.ExecuteScalar();
                if (DBNull.Value == obj2)
                {
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                conn.Close();
            }
            return obj2;
        }

        public static T QueryValue<T>(string sqlString, IDbConnection conn)
        {
            T local = default(T);
            object obj2 = QueryValue(sqlString, conn);
            if (obj2 != null)
            {
                local = (T)obj2;
            }
            return local;
        }
        #endregion

        #region GetSchema
        public static DataTable GetDataSchema(string tableName)
        {
            return GetDataSchema(tableName, GetCurrentDbConnection());
        }

        public static DataTable GetDataSchema(string tableName, IDbConnection conn)
        {
            return QueryDataTable(string.Format("SELECT * FROM {0} WHERE 1=0", tableName), conn);
        }
        #endregion

        #region HQL操作

        public static IQuery GetHqlQuery(string hql, params object[] parameters)
        {
            return GetHqlQuery(OpenHqlSession(), hql, parameters);
        }

        public static IQuery GetHqlQuery(ISession session, string hql, params object[] parameters)
        {
            IQuery query = session.CreateQuery(hql);
            for (int i = 0; i < parameters.Length; i++)
            {
                query.SetParameter(i, parameters[i]);
            }
            return query;
        }

        public static void HqlDelete(string hql)
        {
            ISession session = OpenHqlSession();
            try
            {
                HqlDelete(session, hql);
            }
            finally
            {
                ReleaseHqlSessin(session);
            }
        }

        public static void HqlDelete(ISession session, string hql)
        {
            try
            {
                session.Delete(hql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public static IList HqlQueryList(string hql, params object[] parameters)
        {
            IList list;
            ISession session = OpenHqlSession();
            try
            {
                list = GetHqlQuery(session, hql, parameters).List();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                ReleaseHqlSessin(session);
            }
            return list;
        }

        public static IList HqlQueryList(ISession session, string hql, params object[] parameters)
        {
            return GetHqlQuery(session, hql, parameters).List();
        }

        public static object[] HqlQueryObjects(string hql, params object[] parameters)
        {
            IList<object[]> list = HqlQueryObjectsList(hql, parameters);
            if (list.Count > 0)
            {
                return list[0];
            }
            return null;
        }

        public static IList<object[]> HqlQueryObjectsList(string hql, params object[] parameters)
        {
            IList<object[]> list;
            ISession session = OpenHqlSession();
            try
            {
                list = GetHqlQuery(session, hql, parameters).List<object[]>();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                ReleaseHqlSessin(session);
            }
            return list;
        }

        public static void HqlUpdate(string hql, params object[] parameters)
        {
            GetHqlQuery(hql, parameters).ExecuteUpdate();
        }

        public static void HqlUpdate(ISession session, string hql, params object[] parameters)
        {
            GetHqlQuery(session, hql, parameters).ExecuteUpdate();
        }
        #endregion

        #region MergeData
        /// <summary>
        /// 融合对象,from entity2 all Property to entity1 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity1"></param>
        /// <param name="entity2"></param>
        public static T MergeData<T>(T entity1, T entity2) where T : EntityBase<T>
        {
            foreach (PropertyInfo info in EntityBase<T>.AllProperties)
            {
                if (info.CanWrite)
                {
                    info.SetValue(entity1, info.GetValue(entity2, null), null);
                }
            }
            return entity1;
        }

        /// <summary>
        /// 融合对象如果entity1属性为NULL则赋值
        /// </summary>
        public static T MergeDataIf<T>(T entity1, T entity2) where T : EntityBase<T>
        {
            foreach (PropertyInfo info in EntityBase<T>.AllProperties)
            {
                if (info.CanWrite)
                {
                    object toVal = entity1.GetValue(info.Name);
                    if (toVal == null)
                        info.SetValue(entity1, info.GetValue(entity2, null), null);
                }
            }
            return entity1;
        }
        public static T MergeData<T>(T entity1, T entity2, ICollection<string> keys) where T : EntityBase<T>
        {
            foreach (PropertyInfo info in EntityBase<T>.AllProperties)
            {
                if (info.CanWrite && keys.Contains(info.Name))
                {
                    info.SetValue(entity1, info.GetValue(entity2, null), null);
                }
            }
            return entity1;
        }
        #endregion

        #region HqlSession 操作
        public static ISession OpenHqlSession()
        {
            return OpenHqlSession<ActiveRecordBase>();
        }

        public static ISession OpenHqlSession<T>()
        {
            return OpenHqlSession<T>(null);
        }

        public static ISession OpenHqlSession(IDbConnection conn)
        {
            return OpenHqlSession<ActiveRecordBase>(conn);
        }

        public static ISession OpenHqlSession<T>(IDbConnection conn)
        {
            ISessionFactory sessionFactory = SessionFactoryHolder.GetSessionFactory(typeof(T));
            if (conn == null)
            {
                return sessionFactory.OpenSession();
            }
            return sessionFactory.OpenSession(conn);
        }

        public static void ReleaseHqlSessin(ISession session)
        {
            if (session != null)
            {
                SessionFactoryHolder.ReleaseSession(session);
            }
        }

        // Properties
        public static ISessionFactoryHolder SessionFactoryHolder
        {
            get
            {
                return ActiveRecordMediator.GetSessionFactoryHolder();
            }
        }
        #endregion
    }
}
