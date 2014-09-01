using Castle.ActiveRecord;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Razor.DataHelper
{
    public abstract class FTSearchCriterionBuilderForHql
    {
        // Methods
        protected FTSearchCriterionBuilderForHql()
        {
        }

        public abstract ICriterion BuildCriterion(FTSearchCriterionItem criterionItem);
    }

    /// <summary>
    /// QueryBuilder
    /// </summary>
    public class QueryBuilder
    {
        // Methods
        public static string[] GetColumnNames(string qryString)
        {
            string str = qryString.ToUpper();
            int startIndex = 0;
            if (!str.Contains("SELECT"))
            {
                return null;
            }
            startIndex = str.IndexOf("SELECT") + "SELECT".Length;
            int index = 0;
            if (!str.Contains("FROM"))
            {
                return null;
            }
            index = str.IndexOf("FROM");
            if (startIndex >= index)
            {
                return null;
            }
            string[] strArray = qryString.Substring(startIndex, index - startIndex).Split(new char[] { ',' });
            string[] strArray2 = new string[strArray.Length];
            for (int i = 0; i < strArray2.Length; i++)
            {
                string str3 = strArray[i].Trim();
                int num4 = str3.ToUpper().IndexOf(" AS ");
                if (num4 > 0)
                {
                    str3 = str3.Substring(num4 + 3).Trim();
                }
                int num5 = str3.ToUpper().IndexOf(".");
                if (num5 > 0)
                {
                    str3 = str3.Substring(num5 + 1).Trim();
                }
                strArray2[i] = str3;
            }
            return strArray2;
        }

        public static string GetSQLOrderString(SearchCriterion schCrit)
        {
            string str = string.Empty;
            if ((schCrit.Orders == null) || (schCrit.Orders.Count <= 0))
            {
                return str;
            }
            foreach (OrderCriterionItem item in schCrit.Orders)
            {
                if (!string.IsNullOrEmpty(item.PropertyName))
                {
                    str = str + item.PropertyName;
                    if (item.Ascending)
                    {
                        str = str + " ASC";
                    }
                    else
                    {
                        str = str + " DESC";
                    }
                    str = str + ",";
                }
            }
            return str.TrimEnd(new char[] { ',' });
        }
    }
    public class SQLFTQueryBuilder : QueryBuilder
    {
        // Methods
        public static string ProcessQueryString(string qrystr)
        {
            if (!string.IsNullOrEmpty(qrystr))
            {
                qrystr = "\"" + qrystr.Replace(" ", "\"\"").Replace("'", "''") + "\"";
            }
            return qrystr;
        }
    }

    /// <summary>
    /// SQLFTSearchCriterionBuilderForHql
    /// </summary>
    public class SQLFTSearchCriterionBuilderForHql : FTSearchCriterionBuilderForHql
    {
        // Methods
        public override ICriterion BuildCriterion(FTSearchCriterionItem criterionItem)
        {
            ICriterion criterion = null;
            if (!string.IsNullOrEmpty(criterionItem.Value))
            {
                string str = SQLFTQueryBuilder.ProcessQueryString(criterionItem.Value);
                criterion = Expression.Sql(string.Format("contains({0},'{1}')", this.getColumnListString(criterionItem), str));
            }
            return criterion;
        }

        private string getColumnListString(FTSearchCriterionItem criterionItem)
        {
            string str = "*";
            if (criterionItem.ColumnList.Count > 0)
            {
                StringBuilder builder = new StringBuilder();
                foreach (string str2 in criterionItem.ColumnList)
                {
                    builder.AppendFormat("{0},", str2);
                }
                str = builder.ToString().TrimEnd(new char[] { ',' });
            }
            return string.Format("({0})", str);
        }
    }

    /// <summary>
    /// HqlOrderCriterionItem
    /// </summary>
    public class HqlOrderCriterionItem : OrderCriterionItem, IHqlOrderCriterionItem
    {
        // Methods
        public HqlOrderCriterionItem(OrderCriterionItem item)
            : base(item)
        {
        }

        public HqlOrderCriterionItem(string propertyName, bool ascending)
            : base(propertyName, ascending)
        {
        }

        public Order GetOrder()
        {
            if (string.IsNullOrEmpty(base.PropertyName))
            {
                return null;
            }
            return new Order(base.PropertyName, base.Ascending);
        }
    }


    /// <summary>
    /// HqlSearchCriterion
    /// </summary>
    public class HqlSearchCriterion : SearchCriterion
    {
        // Fields
        private FTSearchCriterionBuilderForHql _ftCritBuilder;

        // Methods
        public HqlSearchCriterion()
        {
            this._ftCritBuilder = null;
            this._ftCritBuilder = new SQLFTSearchCriterionBuilderForHql();
        }

        public HqlSearchCriterion(FTSearchCriterionBuilderForHql ftCritBuilder)
        {
            this._ftCritBuilder = null;
            this._ftCritBuilder = ftCritBuilder;
        }

        private DetachedCriteria AddOrderCriteria(DetachedCriteria criterias, ref bool isAdded)
        {
            if (!isAdded)
            {
                foreach (OrderCriterionItem item in base.Orders)
                {
                    Order order = new HqlOrderCriterionItem(item).GetOrder();
                    if (order != null)
                    {
                        criterias.AddOrder(order);
                    }
                }
            }
            return criterias;
        }

        public override T[] FindAll<T>()
        {
            DetachedCriteria detachedCriteriaWithoutOrder = null;
            Array array = null;
            if (this.AllowPaging)
            {
                detachedCriteriaWithoutOrder = this.GetDetachedCriteriaWithoutOrder<T>();
                if (this.GetRecordCount)
                {
                    this.RecordCount = ActiveRecordMediator.Count(typeof(T), detachedCriteriaWithoutOrder);
                }
                detachedCriteriaWithoutOrder = this.GetDetachedCriteria<T>();
                array = ActiveRecordMediator.SlicedFindAll(typeof(T), (this.CurrentPageIndex - 1) * this.PageSize, this.PageSize, detachedCriteriaWithoutOrder);
            }
            else
            {
                detachedCriteriaWithoutOrder = this.GetDetachedCriteria<T>();
                array = ActiveRecordMediator.FindAll(typeof(T), detachedCriteriaWithoutOrder, new Order[0]);
                if (this.GetRecordCount)
                {
                    this.RecordCount = array.Length;
                }
            }
            return (T[])array;
        }

        public T[] FindAll<T>(params ICriterion[] crits)
        {
            DetachedCriteria detachedCriteriaWithoutOrder = null;
            Array array = null;
            if (this.AllowPaging)
            {
                detachedCriteriaWithoutOrder = this.GetDetachedCriteriaWithoutOrder<T>();
                foreach (ICriterion criterion in crits)
                {
                    if (criterion != null)
                    {
                        detachedCriteriaWithoutOrder.Add(criterion);
                    }
                }
                if (this.GetRecordCount)
                {
                    this.RecordCount = ActiveRecordMediator.Count(typeof(T), detachedCriteriaWithoutOrder);
                }
                detachedCriteriaWithoutOrder = this.GetDetachedCriteria<T>();
                foreach (ICriterion criterion in crits)
                {
                    if (criterion != null)
                    {
                        detachedCriteriaWithoutOrder.Add(criterion);
                    }
                }
                array = ActiveRecordMediator.SlicedFindAll(typeof(T), (this.CurrentPageIndex - 1) * this.PageSize, this.PageSize, detachedCriteriaWithoutOrder);
            }
            else
            {
                detachedCriteriaWithoutOrder = this.GetDetachedCriteria<T>();
                foreach (ICriterion criterion in crits)
                {
                    if (criterion != null)
                    {
                        detachedCriteriaWithoutOrder.Add(criterion);
                    }
                }
                array = ActiveRecordMediator.FindAll(typeof(T), detachedCriteriaWithoutOrder, new Order[0]);
                if (this.GetRecordCount)
                {
                    this.RecordCount = array.Length;
                }
            }
            return (T[])array;
        }

        public DetachedCriteria GetDetachedCriteria<T>()
        {
            bool isAdded = false;
            DetachedCriteria detachedCriteriaWithoutOrder = this.GetDetachedCriteriaWithoutOrder<T>();
            if (this.AutoOrder)
            {
                ReadOnlyCollection<PropertyInfo> source = new ReadOnlyCollection<PropertyInfo>(typeof(T).GetProperties());
                using (IEnumerator<string> enumerator = base.AUTO_ORDER_FIELDS.GetEnumerator())
                {
                    Func<PropertyInfo, bool> predicate = null;
                    string tfield;
                    while (enumerator.MoveNext())
                    {
                        tfield = enumerator.Current;
                        if (predicate == null)
                        {
                            predicate = v => string.Compare(v.Name, tfield) == 0;
                        }
                        PropertyInfo info = source.FirstOrDefault<PropertyInfo>(predicate);
                        if (info != null)
                        {
                            object[] customAttributes = info.GetCustomAttributes(typeof(PropertyAttribute), true);
                            if (((customAttributes != null) && (customAttributes.Length > 0)) && !base.HasOrdered(info.Name))
                            {
                                detachedCriteriaWithoutOrder.AddOrder(new Order(info.Name, false));
                            }
                            goto Label_0105;
                        }
                    }
                }
            }
        Label_0105:
            return this.AddOrderCriteria(detachedCriteriaWithoutOrder, ref isAdded);
        }

        public DetachedCriteria GetDetachedCriteriaWithoutOrder<T>()
        {
            DetachedCriteria criteria = DetachedCriteria.For(typeof(T));
            HqlJunctionSearchCriterionItem item2 = new HqlJunctionSearchCriterionItem(base.Searches)
            {
                FtCritBuilder = this._ftCritBuilder
            };
            ICriterion criterion = item2.GetCriterion();
            if (criterion != null)
            {
                criteria.Add(criterion);
            }
            if (this.IsDistinct)
            {
                criteria.SetResultTransformer(new DistinctRootEntityResultTransformer());
            }
            return criteria;
        }

        public void SetFullTextCriterionBuilder(FTSearchCriterionBuilderForHql ftCritBuilder)
        {
            this._ftCritBuilder = ftCritBuilder;
        }
    }
}
