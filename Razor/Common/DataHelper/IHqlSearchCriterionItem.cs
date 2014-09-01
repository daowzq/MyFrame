using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.DataHelper
{
    interface IHqlSearchCriterionItem
    {
        // Methods
        ICriterion GetCriterion();
    }
}
