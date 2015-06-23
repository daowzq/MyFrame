using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.Mongo
{
    public class MongoBaseAction
    {

        //创建数据库链接
        private static MongoServer Servier = new MongoClient(Connnection.ServerAddress).GetServer();//报错 还需要调试
        // private static MongoServer Servier = MongoDB.Driver.MongoServer.Create(Connnection.ServerAddress);
        private MongoDatabase MonDB = Servier.GetDatabase(Connnection.DbName);

        public MongoBaseAction(string DbName)
        {
            if (!string.IsNullOrEmpty(DbName))
            {

                MonDB = Servier.GetDatabase(DbName);
            }
        }

        /// <summary>
        /// 获取Mongo集合
        /// </summary>
        /// <param name="CollectionName">集合名称</param>
        /// <returns></returns>
        public MongoCollection GetMongoCollection(string CollectionName)
        {
            return MonDB.GetCollection(CollectionName);
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName">集合名</param>
        /// <param name="Entity">实体</param>
        public void Insert<T>(string CollectionName, T Entity)
        {
            //获得Users集合,如果数据库中没有，先新建一个
            MongoCollection col = MonDB.GetCollection(CollectionName);
            col.Insert<T>(Entity);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="CollectionName">集合名称</param>
        /// <param name="QueryDoct">查询文档 eg：new QueryDocument { { "Name", "AAA" } };</param>
        /// <param name="UpdateDoct">更新文档 eg：new UpdateDocument { { "$set", new QueryDocument { { "Sex", "wowen" } } } };</param>
        public void Update(string CollectionName, QueryDocument QueryDoct, UpdateDocument UpdateDoct)
        {
            MongoCollection col = MonDB.GetCollection(CollectionName);
            col.Update(QueryDoct, UpdateDoct);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="CollectionName">集合名称</param>
        /// <param name="QueryDoct">查询文档 eg:new QueryDocument { { "Name", "AAA" } };</param>
        public void Delete(string CollectionName, QueryDocument QueryDoct)
        {
            MongoCollection col = MonDB.GetCollection(CollectionName);
            col.Remove(QueryDoct);
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName">集合名称</param>
        /// <returns></returns>
        public T QueryOne<T>(string CollectionName)
        {
            MongoCollection col = MonDB.GetCollection(CollectionName);
            return col.FindOneAs<T>();
        }

        /// <summary>
        /// 查询一条记录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName">集合名称</param>
        /// <returns></returns>
        public T QueryOneById<T>(string CollectionName, string IdValue)
        {
            MongoCollection col = MonDB.GetCollection(CollectionName);
            return col.FindOneByIdAs<T>(IdValue);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName">集合名称</param>
        /// <returns>MongoCursor 游标</returns>
        public MongoCursor<T> QueryAll<T>(string CollectionName)
        {
            MongoCollection col = MonDB.GetCollection(CollectionName);
            return col.FindAllAs<T>();
        }

        /// <summary>
        /// 通过查询条件查询数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName"></param>
        /// <param name="QueryDoct">查询文档 eg：new QueryDocument { { "Name", "test" } };</param>
        public MongoCursor<T> QueryByCondition<T>(string CollectionName, QueryDocument QueryDoct)
        {
            MongoCollection col = MonDB.GetCollection(CollectionName);
            return col.FindAs<T>(QueryDoct);
        }

    }
}
