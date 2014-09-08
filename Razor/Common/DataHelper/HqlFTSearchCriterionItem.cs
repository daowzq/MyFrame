using Newtonsoft.Json;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.Data
{
    public class HqlFTSearchCriterionItem : FTSearchCriterionItem, IHqlSearchCriterionItem
    {
        // Methods
        public HqlFTSearchCriterionItem()
        {
        }

        public HqlFTSearchCriterionItem(FTSearchCriterionBuilderForHql ftCritBuilder)
        {
            this.FtCritBuilder = ftCritBuilder;
        }

        public HqlFTSearchCriterionItem(FTSearchCriterionItem item)
            : base(item)
        {
        }

        public HqlFTSearchCriterionItem(string val)
            : base(val)
        {
        }

        public HqlFTSearchCriterionItem(FTSearchCriterionBuilderForHql ftCritBuilder, FTSearchCriterionItem item)
            : base(item)
        {
            this.FtCritBuilder = ftCritBuilder;
        }

        public HqlFTSearchCriterionItem(FTSearchCriterionBuilderForHql ftCritBuilder, string val)
            : base(val)
        {
            this.FtCritBuilder = ftCritBuilder;
        }

        public HqlFTSearchCriterionItem(IList<string> _columnList, string val)
            : base(val)
        {
        }

        public HqlFTSearchCriterionItem(FTSearchCriterionBuilderForHql ftCritBuilder, IList<string> _columnList, string val)
            : base(val)
        {
            this.FtCritBuilder = ftCritBuilder;
        }

        public ICriterion GetCriterion()
        {
            if (!((this.FtCritBuilder == null) || string.IsNullOrEmpty(base.Value)))
            {
                return this.FtCritBuilder.BuildCriterion(this);
            }
            return null;
        }

        // Properties
        [JsonIgnore]
        public FTSearchCriterionBuilderForHql FtCritBuilder { get; set; }
    }


}
