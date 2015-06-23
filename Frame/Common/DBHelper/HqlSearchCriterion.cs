using Castle.ActiveRecord;
using NHibernate.Criterion;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Razor.Data
{

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

}
