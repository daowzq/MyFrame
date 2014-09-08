using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Razor.Data
{
    public class SearchHelper
    {
        // Methods
        public static object ConvertToSearchValue(object value, TypeCode type)
        {
            Type type2 = value.GetType();
            object obj2 = value;
            if ((type == TypeCode.Object) && (type2 == typeof(long)))
            {
                type = TypeCode.Int32;
            }
            if (type != TypeCode.Object)
            {
                obj2 = Convert.ChangeType(value, type);
            }
            return obj2;
        }

        public static ICriterion IntersectCriterions(params ICriterion[] crits)
        {
            IList<ICriterion> list = crits.ToList<ICriterion>();
            Conjunction conjunction = new Conjunction();
            foreach (ICriterion criterion in list)
            {
                if (criterion != null)
                {
                    conjunction.Add(criterion);
                }
            }
            return conjunction;
        }

        public static ICriterion UnionCriterions(params ICriterion[] crits)
        {
            IList<ICriterion> list = crits.ToList<ICriterion>();
            Disjunction disjunction = new Disjunction();
            foreach (ICriterion criterion in list)
            {
                if (criterion != null)
                {
                    disjunction.Add(criterion);
                }
            }
            return disjunction;
        }
    }
}
