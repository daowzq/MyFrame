using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.DataHelper
{
    public interface IHqlOrderCriterionItem
    {
        // Methods
        Order GetOrder();
    }
}
