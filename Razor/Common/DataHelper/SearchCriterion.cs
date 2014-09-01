using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Razor.DataHelper
{
    public class CriterionItem
    {
    }
    public class SearchCriterionItem : CriterionItem
    {
    }

    public class OrderCriterionItem
    {
        // Fields
        private string propertyName;

        // Methods
        public OrderCriterionItem()
            : this(string.Empty, true)
        {
        }

        public OrderCriterionItem(OrderCriterionItem item)
            : this(item.PropertyName, item.Ascending)
        {
        }

        public OrderCriterionItem(string propertyName)
            : this(propertyName, true)
        {
        }

        public OrderCriterionItem(string propertyName, bool ascending)
        {
            this.propertyName = string.Empty;
            this.propertyName = propertyName;
            this.Ascending = ascending;
        }

        // Properties
        public bool Ascending { get; set; }

        public string PropertyName
        {
            get
            {
                return this.propertyName;
            }
            set
            {
                this.propertyName = value;
            }
        }
    }

    public class SearchCriterion
    {
        // Fields
        protected bool _allowPaging = false;
        protected bool _autoOrder = true;
        protected int _currentPage = 1;
        private static int _defaultPageSize = 20;
        protected bool _distinct = false;
        protected bool _getRecordCount = false;
        protected int _pageCount = -1;
        protected int _pageSize = _defaultPageSize;
        protected int _recordCount = -1;
        internal readonly ReadOnlyCollection<string> AUTO_ORDER_FIELDS = new ReadOnlyCollection<string>(new List<string>(new string[] { "CreateDate", "CreateTime", "CreatedDate", "CreatedTime" }));
        private List<string> queryFields = new List<string>();

        // Methods
        public SearchCriterion()
        {
            this.Orders = new List<OrderCriterionItem>();
            this.Searches = new JunctionSearchCriterionItem(JunctionMode.And);
        }

        public void AddFTSearch(string value)
        {
            this.Searches.AddFTSearch(value);
        }

        public void AddFTSearch(List<string> colList, string value)
        {
            this.Searches.AddFTSearch(colList, value);
        }

        public virtual void AddSearch(string propertyName, SingleSearchModeEnum searchMode)
        {
            this.Searches.AddSearch(propertyName, searchMode);
        }

        public virtual void AddSearch(string propertyName, object value)
        {
            this.Searches.AddSearch(propertyName, value, SearchModeEnum.Equal);
        }

        public virtual void AddSearch(string propertyName, object value, SearchModeEnum searchMode)
        {
            this.Searches.AddSearch(propertyName, value, searchMode);
        }

        public virtual void AddSearch(string propertyName, object value, TypeCode type)
        {
            this.Searches.AddSearch(propertyName, value, SearchModeEnum.Equal, type);
        }

        public virtual void AddSearch(string propertyName, object value, SearchModeEnum searchMode, TypeCode type)
        {
            this.Searches.AddSearch(propertyName, value, searchMode, type);
        }

        public virtual void AddSearches(string[] propertyNames, SingleSearchModeEnum searchMode)
        {
            this.Searches.AddSearches(propertyNames, searchMode);
        }

        public virtual void Clear()
        {
            this.queryFields.Clear();
            this.Searches.Clear();
        }

        public virtual T[] FindAll<T>()
        {
            throw new NotImplementedException();
        }

        public virtual void FormatSearch()
        {
            this.FormatSearch(this.Searches);
        }

        protected virtual void FormatSearch(CommonSearchCriterionItem cschitem)
        {
            cschitem.Value = SearchHelper.ConvertToSearchValue(cschitem.Value, cschitem.Type);
        }

        protected virtual void FormatSearch(JunctionSearchCriterionItem jschitem)
        {
            foreach (SearchCriterionItem item in jschitem.Searches)
            {
                if (item is CommonSearchCriterionItem)
                {
                    this.FormatSearch(item as CommonSearchCriterionItem);
                }
                else if (item is JunctionSearchCriterionItem)
                {
                    this.FormatSearch(item as JunctionSearchCriterionItem);
                }
            }
        }

        public virtual CommonSearchCriterionItem GetFirstSearch(string propertyName)
        {
            return this.Searches.GetFirstSearch(propertyName);
        }

        public virtual IList<CommonSearchCriterionItem> GetSearches(string propertyName)
        {
            return this.Searches.GetSearches(propertyName);
        }

        public virtual object GetSearchValue(string propertyName)
        {
            CommonSearchCriterionItem firstSearch = this.Searches.GetFirstSearch(propertyName);
            if (firstSearch == null)
            {
                return null;
            }
            return firstSearch.Value;
        }

        public virtual T GetSearchValue<T>(string propertyName)
        {
            object searchValue = this.GetSearchValue(propertyName);
            if (searchValue == null)
            {
                return default(T);
            }
            return ObjectHelper.ConvertValue<T>(searchValue);
        }

        public virtual T GetSearchValue<T>(string propertyName, T defVal)
        {
            object searchValue = this.GetSearchValue(propertyName);
            if (searchValue == null)
            {
                return defVal;
            }
            return ObjectHelper.ConvertValue<T>(searchValue);
        }

        public virtual object GetSearchValue(string propertyName, object defVal)
        {
            object searchValue = this.GetSearchValue(propertyName);
            if (searchValue == null)
            {
                return defVal;
            }
            return searchValue;
        }

        public bool HasOrdered()
        {
            if ((this.Orders == null) || (this.Orders.Count <= 0))
            {
                return false;
            }
            return true;
        }

        public bool HasOrdered(string propertyName)
        {
            return this.Orders.Exists(ent => ent.PropertyName == propertyName);
        }

        public virtual void RemoveSearch(string[] propertyNames)
        {
            this.Searches.RemoveSearch(propertyNames);
        }

        public virtual void RemoveSearch(string propertyName)
        {
            this.Searches.RemoveSearch(propertyName);
        }

        public void SetOrder(string propertyName)
        {
            this.SetOrder(propertyName, true);
        }

        public void SetOrder(string propertyName, bool ascending)
        {
            Func<OrderCriterionItem, bool> predicate = null;
            if (!(((this.Orders != null) && (this.Orders.Count > 0)) && this.HasOrdered(propertyName)))
            {
                this.Orders.Add(new OrderCriterionItem(propertyName, ascending));
            }
            else
            {
                if (predicate == null)
                {
                    predicate = ent => ent.PropertyName == propertyName;
                }
                this.Orders.First<OrderCriterionItem>(predicate).Ascending = ascending;
            }
        }

        public virtual void SetSearch(string propertyName, SingleSearchModeEnum searchMode)
        {
            this.Searches.SetSearch(propertyName, searchMode);
        }

        public virtual void SetSearch(string propertyName, object value)
        {
            this.Searches.SetSearch(propertyName, value, SearchModeEnum.Equal);
        }

        public virtual void SetSearch(string propertyName, object value, SearchModeEnum searchMode)
        {
            this.Searches.SetSearch(propertyName, value, searchMode);
        }

        public virtual void SetSearch(string propertyName, object value, TypeCode type)
        {
            this.Searches.SetSearch(propertyName, value, SearchModeEnum.Equal, type);
        }

        public virtual void SetSearch(string propertyName, object value, SearchModeEnum searchMode, TypeCode type)
        {
            this.Searches.SetSearch(propertyName, value, searchMode, type);
        }

        public virtual void SetSearches(string[] propertyNames, SingleSearchModeEnum searchMode)
        {
            this.Searches.SetSearches(propertyNames, searchMode);
        }

        // Properties
        public virtual bool AllowPaging
        {
            get
            {
                return this._allowPaging;
            }
            set
            {
                this._allowPaging = value;
            }
        }

        public virtual bool AutoOrder
        {
            get
            {
                return this._autoOrder;
            }
            set
            {
                this._autoOrder = value;
            }
        }

        public virtual int CurrentPageIndex
        {
            get
            {
                return this._currentPage;
            }
            set
            {
                this._currentPage = value;
            }
        }

        public virtual int DefaultPageSize
        {
            get
            {
                return _defaultPageSize;
            }
            set
            {
                _defaultPageSize = value;
            }
        }

        public virtual bool GetRecordCount
        {
            get
            {
                return this._getRecordCount;
            }
            set
            {
                this._getRecordCount = value;
            }
        }

        public virtual bool IsDistinct { get; set; }

        public List<OrderCriterionItem> Orders { get; set; }

        public virtual int PageCount
        {
            get
            {
                if (this._pageCount != -1)
                {
                    return this._pageCount;
                }
                if (this.PageSize >= 0)
                {
                    this._pageCount = ((this.RecordCount - 1) / this.PageSize) + 1;
                    return this._pageCount;
                }
                return 1;
            }
        }

        public virtual int PageSize
        {
            get
            {
                return this._pageSize;
            }
            set
            {
                this._pageSize = value;
                this._pageCount = -1;
            }
        }

        public virtual List<string> QueryFields
        {
            get
            {
                return this.queryFields;
            }
        }

        public virtual int RecordCount
        {
            get
            {
                return this._recordCount;
            }
            set
            {
                this._recordCount = value;
                this._pageCount = -1;
            }
        }

        public JunctionSearchCriterionItem Searches { get; set; }
    }


}
