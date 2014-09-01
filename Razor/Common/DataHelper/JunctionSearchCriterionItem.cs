using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.DataHelper
{
    public enum JunctionMode
    {
        Or,
        And
    }
    public enum SingleSearchModeEnum
    {
        IsEmpty,
        IsNotEmpty,
        IsNull,
        IsNotNull,
        UnSettled
    }
    public enum SearchModeEnum
    {
        Equal,
        NotEqual,
        In,
        NotIn,
        Like,
        NotLike,
        GreaterThan,
        GreaterThanEqual,
        LessThan,
        LessThanEqual,
        StartWith,
        EndWith,
        NotStartWith,
        NotEndWith,
        UnSettled
    }

    public class CommonSearchCriterionItem : SearchCriterionItem
    {
        // Methods
        public CommonSearchCriterionItem()
        {
            this.Init();
        }

        public CommonSearchCriterionItem(CommonSearchCriterionItem item)
            : this(item.PropertyName, item.Value, item.SearchMode, item.Type)
        {
        }

        public CommonSearchCriterionItem(string propertyName, SingleSearchModeEnum searchMode)
        {
            this.Init();
            this.PropertyName = propertyName;
            this.SingleSearchMode = searchMode;
        }

        public CommonSearchCriterionItem(string propertyName, object value)
        {
            this.Init();
            this.PropertyName = propertyName;
            this.Value = value;
            this.SearchMode = SearchModeEnum.Equal;
        }

        public CommonSearchCriterionItem(string propertyName, object value, SearchModeEnum searchMode)
            : this()
        {
            this.Init();
            this.PropertyName = propertyName;
            this.Value = value;
            this.SearchMode = searchMode;
        }

        public CommonSearchCriterionItem(string propertyName, object value, TypeCode type)
            : this(propertyName, value)
        {
            this.Type = type;
        }

        public CommonSearchCriterionItem(string propertyName, object value, SearchModeEnum searchMode, TypeCode type)
            : this(propertyName, value, searchMode)
        {
            this.Type = type;
        }

        private void Init()
        {
            this.SearchMode = SearchModeEnum.Equal;
            this.SingleSearchMode = SingleSearchModeEnum.UnSettled;
            this.Type = TypeCode.Object;
        }

        // Properties
        public bool IsSingleSearch
        {
            get
            {
                return (this.SingleSearchMode != SingleSearchModeEnum.UnSettled);
            }
        }

        public string PropertyName { get; set; }

        public SearchModeEnum SearchMode { get; set; }

        public SingleSearchModeEnum SingleSearchMode { get; set; }

        public TypeCode Type { get; set; }

        public object Value { get; set; }
    }

    public class FTSearchCriterionItem
    {
        // Fields
        protected IList<string> columnList;

        // Methods
        public FTSearchCriterionItem()
        {
            this.columnList = new List<string>();
            this.Value = null;
        }

        public FTSearchCriterionItem(FTSearchCriterionItem item)
        {
            this.columnList = new List<string>();
            this.columnList = item.columnList;
            this.Value = item.Value;
        }

        public FTSearchCriterionItem(string val)
        {
            this.columnList = new List<string>();
            this.Value = val;
        }

        public FTSearchCriterionItem(IList<string> _columnList, string val)
            : this(val)
        {
            this.columnList = _columnList;
        }

        // Properties
        public IList<string> ColumnList
        {
            get
            {
                return this.columnList;
            }
            set
            {
                this.columnList = value;
            }
        }

        public string Value { get; set; }
    }

    public class JunctionSearchCriterionItem : SearchCriterionItem
    {
        // Methods
        public JunctionSearchCriterionItem()
            : this(JunctionMode.Or)
        {
        }

        public JunctionSearchCriterionItem(JunctionMode junctionMode)
        {
            this.JunctionMode = junctionMode;
            this.Searches = new List<CommonSearchCriterionItem>();
            this.FTSearches = new List<FTSearchCriterionItem>();
            this.JuncSearches = new List<JunctionSearchCriterionItem>();
        }

        public JunctionSearchCriterionItem(JunctionSearchCriterionItem item)
            : this()
        {
            this.JunctionMode = item.JunctionMode;
            foreach (CommonSearchCriterionItem item2 in item.Searches)
            {
                this.Searches.Add(item2);
            }
            foreach (FTSearchCriterionItem item3 in item.FTSearches)
            {
                this.FTSearches.Add(item3);
            }
            foreach (JunctionSearchCriterionItem item4 in item.JuncSearches)
            {
                this.JuncSearches.Add(item4);
            }
        }

        public void AddFTSearch(string value)
        {
            this.FTSearches.Add(new FTSearchCriterionItem(value));
        }

        public void AddFTSearch(List<string> colList, string value)
        {
            this.FTSearches.Add(new FTSearchCriterionItem(colList, value));
        }

        public virtual void AddSearch(string propertyName, SingleSearchModeEnum searchMode)
        {
            this.Searches.Add(new CommonSearchCriterionItem(propertyName, searchMode));
        }

        public virtual void AddSearch(string propertyName, object value)
        {
            this.AddSearch(propertyName, value, SearchModeEnum.Equal);
        }

        public virtual void AddSearch(string propertyName, object value, SearchModeEnum searchMode)
        {
            this.Searches.Add(new CommonSearchCriterionItem(propertyName, value, searchMode));
        }

        public virtual void AddSearch(string propertyName, object value, TypeCode type)
        {
            this.AddSearch(propertyName, value, SearchModeEnum.Equal, type);
        }

        public virtual void AddSearch(string propertyName, object value, SearchModeEnum searchMode, TypeCode type)
        {
            this.Searches.Add(new CommonSearchCriterionItem(propertyName, value, searchMode, type));
        }

        public virtual void AddSearches(string[] propertyNames, SingleSearchModeEnum searchMode)
        {
            foreach (string str in propertyNames)
            {
                this.AddSearch(str, searchMode);
            }
        }

        public virtual void Clear()
        {
            this.Searches.Clear();
            this.FTSearches.Clear();
            this.JuncSearches.Clear();
        }

        public CommonSearchCriterionItem GetFirstSearch(string propertyName)
        {
            Func<CommonSearchCriterionItem, bool> predicate = null;
            if ((this.Searches != null) && (this.Searches.Count<CommonSearchCriterionItem>(tent => (tent.PropertyName == propertyName)) > 0))
            {
                if (predicate == null)
                {
                    predicate = tent => tent.PropertyName == propertyName;
                }
                return this.Searches.First<CommonSearchCriterionItem>(predicate);
            }
            return null;
        }

        public IList<CommonSearchCriterionItem> GetSearches(string propertyName)
        {
            Func<CommonSearchCriterionItem, bool> predicate = null;
            if ((this.Searches != null) && (this.Searches.Count<CommonSearchCriterionItem>(tent => (tent.PropertyName == propertyName)) > 0))
            {
                if (predicate == null)
                {
                    predicate = tent => tent.PropertyName == propertyName;
                }
                return this.Searches.Where<CommonSearchCriterionItem>(predicate).ToList<CommonSearchCriterionItem>();
            }
            return null;
        }

        public virtual void RemoveSearch(string[] propertyNames)
        {
            Predicate<CommonSearchCriterionItem> match = null;
            if ((((this.Searches != null) && (this.Searches.Count > 0)) && (propertyNames != null)) && (propertyNames.Length > 0))
            {
                if (match == null)
                {
                    match = tent => propertyNames.Contains<string>(tent.PropertyName);
                }
                this.Searches.RemoveAll(match);
            }
        }

        public virtual void RemoveSearch(string propertyName)
        {
            Predicate<CommonSearchCriterionItem> match = null;
            if ((this.Searches != null) && (this.Searches.Count > 0))
            {
                if (match == null)
                {
                    match = tent => tent.PropertyName == propertyName;
                }
                this.Searches.RemoveAll(match);
            }
        }

        public virtual void SetSearch(string propertyName, SingleSearchModeEnum searchMode)
        {
            CommonSearchCriterionItem firstSearch = this.GetFirstSearch(propertyName);
            if (firstSearch != null)
            {
                firstSearch.SingleSearchMode = searchMode;
            }
            else
            {
                this.AddSearch(propertyName, searchMode);
            }
        }

        public virtual void SetSearch(string propertyName, object value)
        {
            CommonSearchCriterionItem firstSearch = this.GetFirstSearch(propertyName);
            if (firstSearch != null)
            {
                firstSearch.Value = value;
            }
            else
            {
                this.AddSearch(propertyName, value);
            }
        }

        public virtual void SetSearch(string propertyName, object value, SearchModeEnum searchMode)
        {
            CommonSearchCriterionItem firstSearch = this.GetFirstSearch(propertyName);
            if (firstSearch != null)
            {
                firstSearch.Value = value;
                firstSearch.SearchMode = searchMode;
            }
            else
            {
                this.AddSearch(propertyName, value, searchMode);
            }
        }

        public virtual void SetSearch(string propertyName, object value, TypeCode type)
        {
            CommonSearchCriterionItem firstSearch = this.GetFirstSearch(propertyName);
            if (firstSearch != null)
            {
                firstSearch.Value = value;
                firstSearch.Type = type;
            }
            else
            {
                this.AddSearch(propertyName, value, type);
            }
        }

        public virtual void SetSearch(string propertyName, object value, SearchModeEnum searchMode, TypeCode type)
        {
            CommonSearchCriterionItem firstSearch = this.GetFirstSearch(propertyName);
            if (firstSearch != null)
            {
                firstSearch.Value = value;
                firstSearch.SearchMode = searchMode;
                firstSearch.Type = type;
            }
            else
            {
                this.AddSearch(propertyName, value, searchMode, type);
            }
        }

        public virtual void SetSearches(string[] propertyNames, SingleSearchModeEnum searchMode)
        {
            foreach (string str in propertyNames)
            {
                this.SetSearch(str, searchMode);
            }
        }

        // Properties
        public List<FTSearchCriterionItem> FTSearches { get; set; }

        public List<JunctionSearchCriterionItem> JuncSearches { get; set; }

        public JunctionMode JunctionMode { get; set; }

        public List<CommonSearchCriterionItem> Searches { get; set; }
    }
}
