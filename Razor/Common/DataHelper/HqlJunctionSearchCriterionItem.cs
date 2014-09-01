using Newtonsoft.Json;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.DataHelper
{
    public class HqlJunctionSearchCriterionItem : JunctionSearchCriterionItem, IHqlSearchCriterionItem
    {
        // Methods
        public HqlJunctionSearchCriterionItem()
        {
        }

        public HqlJunctionSearchCriterionItem(JunctionMode junctionMode)
            : base(junctionMode)
        {
        }

        public HqlJunctionSearchCriterionItem(JunctionSearchCriterionItem item)
            : base(item)
        {
        }

        public ICriterion GetCriterion()
        {
            ICriterion criterion = null;
            IHqlSearchCriterionItem item2;
            ICriterion criterion2;
            IList<ICriterion> source = new List<ICriterion>();
            foreach (CommonSearchCriterionItem item in base.Searches)
            {
                item2 = new HqlCommonSearchCriterionItem(item);
                criterion2 = item2.GetCriterion();
                if (criterion2 != null)
                {
                    source.Add(criterion2);
                }
            }
            foreach (FTSearchCriterionItem item3 in base.FTSearches)
            {
                item2 = new HqlFTSearchCriterionItem(this.FtCritBuilder, item3);
                criterion2 = item2.GetCriterion();
                if (criterion2 != null)
                {
                    source.Add(criterion2);
                }
            }
            foreach (JunctionSearchCriterionItem item4 in base.JuncSearches)
            {
                item2 = new HqlJunctionSearchCriterionItem(item4);
                criterion2 = item2.GetCriterion();
                if (criterion2 != null)
                {
                    source.Add(criterion2);
                }
            }
            if (source.Count <= 0)
            {
                return criterion;
            }
            if (base.JunctionMode == JunctionMode.And)
            {
                return SearchHelper.IntersectCriterions(source.ToArray<ICriterion>());
            }
            return SearchHelper.UnionCriterions(source.ToArray<ICriterion>());
        }

        // Properties
        [JsonIgnore]
        public FTSearchCriterionBuilderForHql FtCritBuilder { get; set; }
    }
}
