using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.Data
{
    interface IHqlSearchCriterionItem
    {
        // Methods
        ICriterion GetCriterion();
    }
}
