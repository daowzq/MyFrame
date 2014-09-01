using NHibernate.Criterion;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.DataHelper
{
    public class HqlCommonSearchCriterionItem : CommonSearchCriterionItem, IHqlSearchCriterionItem
    {
        // Methods
        public HqlCommonSearchCriterionItem()
        {
        }

        public HqlCommonSearchCriterionItem(CommonSearchCriterionItem item)
            : base(item)
        {
        }

        public HqlCommonSearchCriterionItem(string propertyName, SingleSearchModeEnum searchMode)
            : base(propertyName, searchMode)
        {
        }

        public HqlCommonSearchCriterionItem(string propertyName, object value)
            : base(propertyName, value)
        {
        }

        public HqlCommonSearchCriterionItem(string propertyName, object value, SearchModeEnum searchMode)
            : base(propertyName, value, searchMode)
        {
        }

        public HqlCommonSearchCriterionItem(string propertyName, object value, TypeCode type)
            : base(propertyName, value)
        {
        }

        public HqlCommonSearchCriterionItem(string propertyName, object value, SearchModeEnum searchMode, TypeCode type)
            : base(propertyName, value, searchMode)
        {
        }

        public ICriterion GetCriterion()
        {
            ICriterion criterion = null;
            string propertyName = base.PropertyName;
            object obj2 = base.Value;
            if ((string.IsNullOrEmpty(propertyName) || (obj2 == null)) || string.IsNullOrEmpty(obj2.ToString()))
            {
                return null;
            }
            if (base.IsSingleSearch)
            {
                switch (base.SingleSearchMode)
                {
                    case SingleSearchModeEnum.IsEmpty:
                        return Restrictions.IsEmpty(propertyName);

                    case SingleSearchModeEnum.IsNotEmpty:
                        return Restrictions.IsNotEmpty(propertyName);

                    case SingleSearchModeEnum.IsNull:
                        return Restrictions.IsNull(propertyName);

                    case SingleSearchModeEnum.IsNotNull:
                        return Restrictions.IsNotNull(propertyName);
                }
                return criterion;
            }
            switch (base.SearchMode)
            {
                case SearchModeEnum.Equal:
                    return Restrictions.Eq(propertyName, obj2);

                case SearchModeEnum.NotEqual:
                    return Restrictions.Not(Restrictions.Eq(propertyName, obj2));

                case SearchModeEnum.In:
                    if (obj2 is ICollection)
                    {
                        criterion = Restrictions.In(propertyName, obj2 as ICollection);
                    }
                    return criterion;

                case SearchModeEnum.NotIn:
                    if (obj2 is ICollection)
                    {
                        criterion = Restrictions.Not(Restrictions.In(propertyName, obj2 as ICollection));
                    }
                    return criterion;

                case SearchModeEnum.Like:
                    return Restrictions.Like(propertyName, "%" + obj2 + "%");

                case SearchModeEnum.NotLike:
                    return Restrictions.Not(Restrictions.Like(propertyName, "%" + obj2 + "%"));

                case SearchModeEnum.GreaterThan:
                    return Restrictions.Gt(propertyName, obj2);

                case SearchModeEnum.GreaterThanEqual:
                    return Restrictions.Ge(propertyName, obj2);

                case SearchModeEnum.LessThan:
                    return Restrictions.Lt(propertyName, obj2);

                case SearchModeEnum.LessThanEqual:
                    return Restrictions.Le(propertyName, obj2);

                case SearchModeEnum.StartWith:
                    return Restrictions.Like(propertyName, obj2.ToString(), MatchMode.Start);

                case SearchModeEnum.EndWith:
                    return Restrictions.Like(propertyName, obj2.ToString(), MatchMode.End);

                case SearchModeEnum.NotStartWith:
                    return Restrictions.Not(Restrictions.Like(propertyName, obj2.ToString(), MatchMode.End));

                case SearchModeEnum.NotEndWith:
                    return Restrictions.Not(Restrictions.Like(propertyName, obj2.ToString(), MatchMode.Start));
            }
            return criterion;
        }
    }
}
