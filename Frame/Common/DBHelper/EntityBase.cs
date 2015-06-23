using System;
using Castle.ActiveRecord.Framework.Internal;
using Castle.ActiveRecord;
using System.Collections.ObjectModel;
using System.Reflection;
using Castle.ActiveRecord.Queries;
using System.Xml.Serialization;
using System.Text;
using System.IO;
using NHibernate.Criterion;
using PostSharp;
using NHibernate;
using NHibernate.Transform;

namespace Razor.Data
{
    [Serializable]
    public abstract class EntityBase<T> : ActiveRecordBase<T>, IAimNotifyPropertyChanged where T : EntityBase<T>
    {
        // Fields
        private static ReadOnlyCollection<PropertyInfo> allProperties;
        private static string className;
        private static Type primaryKeyDataType;
        private static string primaryKeyName;
        private static string tableName;

        // Events
        public event RazorPropertyChangedEventHandler RazorPropertyChanged;

        // Methods
        static EntityBase()
        {
            EntityBase<T>.allProperties = null;
            EntityBase<T>.className = null;
            EntityBase<T>.tableName = null;
            EntityBase<T>.primaryKeyName = null;
            EntityBase<T>.primaryKeyDataType = null;
        }

        public EntityBase()
        {
            this.Initialize();
        }

        protected virtual void Initialize()
        {
            this.RazorPropertyChanged = (RazorPropertyChangedEventHandler)Delegate.Combine(this.RazorPropertyChanged, new RazorPropertyChangedEventHandler(this.OnPropertyChanged));
        }
        protected virtual void OnPropertyChanged(object sender, RazorPropertyChangedEventArgs e)
        {
        }

        #region 基本成员方法
        /// <summary>
        /// 调用RazorPropertyChanged 事件
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        public void RaisePropertyChanged(string propertyName, object oldValue, object newValue)
        {
            if (this.RazorPropertyChanged != null)
            {
                this.RazorPropertyChanged(this, new RazorPropertyChangedEventArgs(propertyName, oldValue, newValue));
            }
        }

        public virtual object GetPrimaryValue()
        {
            return this.GetValue(EntityBase<T>.PrimaryKeyName);
        }

        public virtual T1 GetValue<T1>(string propertyName)
        {
            return (T1)base.GetType().GetProperty(propertyName).GetValue(this, null);
        }

        public virtual object GetValue(string propertyName)
        {
            return base.GetType().GetProperty(propertyName).GetValue(this, null);
        }

        public bool IsPropertyUnique(string property)
        {
            object obj2 = this.GetValue(property);
            object primaryValue = this.GetPrimaryValue();
            if (obj2 == null)
            {
                return false;
            }
            bool flag = false;
            if (primaryValue == null)
            {
                flag = !ActiveRecordBase<T>.Exists<SimpleExpression>(Restrictions.Eq(property, obj2));
            }
            else
            {
                flag = !ActiveRecordBase<T>.Exists(new ICriterion[] { Restrictions.Eq(property, obj2), Restrictions.Not(Restrictions.Eq(EntityBase<T>.PrimaryKeyName, primaryValue)) });
            }
            return flag;
        }

        public override string ToString()
        {
            XmlSerializer serializer = new XmlSerializer(base.GetType());
            StringBuilder sb = new StringBuilder();
            TextWriter textWriter = new StringWriter(sb);
            serializer.Serialize(textWriter, this);
            textWriter.Flush();
            string str = sb.ToString();
            textWriter.Close();
            return str;
        }
        public static DetachedCriteria GetCriteriaByProperties(params object[] nameAndValues)
        {
            if ((nameAndValues.Length % 2) == 1)
            {
                throw new Exception("FindAllByPropertys参数数目不正确！");
            }
            int num = nameAndValues.Length / 2;
            DetachedCriteria criteria = DetachedCriteria.For(typeof(T));
            for (int i = 0; i < (nameAndValues.Length / 2); i++)
            {
                SimpleExpression expression = Restrictions.Eq(nameAndValues[i * 2].ToString(), nameAndValues[(i * 2) + 1]);
                criteria.Add(expression);
            }
            return criteria;
        }

        public override void Save()
        {
            base.Save();
        }

        public override void Update()
        {
            base.Update();
        }
        public override void Create()
        {
            base.Create();
        }

        public override void Delete()
        {
            base.Delete();
        }

        public virtual void SetValue(string propertyName, object val)
        {
            base.GetType().GetProperty(propertyName).SetValue(this, val, null);
        }

        #endregion

        #region  FindAll 方法
        public static T AutoFind(object id)
        {
            object obj2 = null;
            if (id.GetType() != EntityBase<T>.PrimaryKeyDataType)
            {
                obj2 = Convert.ChangeType(id, EntityBase<T>.PrimaryKeyDataType);
            }
            else
            {
                obj2 = id;
            }
            if (obj2 != null)
            {
                return ActiveRecordBase<T>.Find(obj2);
            }
            return default(T);
        }

        public new static T[] FindAll()
        {
            return (T[])(ActiveRecordBase.FindAll(typeof(T)));
        }


        public static T[] FindAll(string querystr, params object[] args)
        {
            SimpleQuery<T> query = new SimpleQuery<T>(querystr, args);
            return query.Execute();
        }


        public static T[] FindAllByPrimaryKeys(params object[] args)
        {
            return ActiveRecordBase<T>.FindAll(new ICriterion[] { Restrictions.In(EntityBase<T>.PrimaryKeyName, args) });
        }

        public static T[] FindAllByProperties(params object[] nameAndValues)
        {
            return ActiveRecordBase<T>.FindAll(EntityBase<T>.GetCriteriaByProperties(nameAndValues), null);
        }

        public static T[] FindAllByProperties(int ascOrdesc, string orderbyprop, params object[] nameAndValues)
        {
            DetachedCriteria criteriaByProperties = EntityBase<T>.GetCriteriaByProperties(nameAndValues);
            Order order = new Order(orderbyprop, true);
            if (ascOrdesc == 1)
            {
                order = new Order(orderbyprop, false);
            }
            return ActiveRecordBase<T>.FindAll(criteriaByProperties, new Order[] { order });
        }

        public static T FindFirstByProperties(params object[] nameAndValues)
        {
            return ActiveRecordBase<T>.FindFirst(EntityBase<T>.GetCriteriaByProperties(nameAndValues), new Order[0]);
        }

        #endregion

        #region   属性
        public static ReadOnlyCollection<PropertyInfo> AllProperties
        {
            get
            {
                if (EntityBase<T>.allProperties == null)
                {
                    EntityBase<T>.allProperties = new ReadOnlyCollection<PropertyInfo>(typeof(T).GetProperties());
                }
                return EntityBase<T>.allProperties;
            }
        }

        public static string ClassName
        {
            get
            {
                if (string.IsNullOrEmpty(EntityBase<T>.className))
                {
                    EntityBase<T>.className = typeof(T).Name;
                }
                return EntityBase<T>.className;
            }
        }

        public static Type PrimaryKeyDataType
        {
            get
            {
                if (!string.IsNullOrEmpty(EntityBase<T>.PrimaryKeyName))
                {
                    EntityBase<T>.primaryKeyDataType = ActiveRecordModel.GetModel(typeof(T)).PrimaryKey.Property.PropertyType;
                }
                return EntityBase<T>.primaryKeyDataType;
            }
        }

        public static string PrimaryKeyName
        {
            get
            {
                if (string.IsNullOrEmpty(EntityBase<T>.primaryKeyName))
                {
                    EntityBase<T>.primaryKeyName = ActiveRecordModel.GetModel(typeof(T)).PrimaryKey.PrimaryKeyAtt.Column;
                }
                return EntityBase<T>.primaryKeyName;
            }
        }

        public static string TableName
        {
            get
            {
                if (string.IsNullOrEmpty(EntityBase<T>.tableName) && (EntityBase<T>.tableName == null))
                {
                    EntityBase<T>.tableName = ActiveRecordModel.GetModel(typeof(T)).ActiveRecordAtt.Table;
                }
                return EntityBase<T>.tableName;
            }
        }

        #endregion

        event RazorPropertyChangedEventHandler IAimNotifyPropertyChanged.RazorPropertyChanged
        {
            add { throw new NotImplementedException(); }
            remove { throw new NotImplementedException(); }
        }
    }
}

