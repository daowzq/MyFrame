using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Razor
{
    public sealed class ObjectHelper
    {
        // Methods
        public static T ConvertValue<T>(object value)
        {
            return ConvertValue<T>(value, default(T));
        }

        public static T ConvertValue<T>(object value, object defValue)
        {
            T local = default(T);
            if (value != null)
            {
                try
                {
                    local = (T)Convert.ChangeType(value, typeof(T));
                }
                catch
                {
                    try
                    {
                        local = (T)value;
                    }
                    catch
                    {
                    }
                }
            }
            return local;
        }

        public static T FilterNull<T>(object val, T def)
        {
            if (val == null)
            {
                return def;
            }
            return (T)val;
        }

        public static Assembly[] GetAssemblysByNames(params string[] assemblyNames)
        {
            Assembly[] assemblyArray = new Assembly[assemblyNames.Length];
            for (int i = 0; i < assemblyNames.Length; i++)
            {
                assemblyArray[i] = Assembly.Load(assemblyNames[i]);
            }
            return assemblyArray;
        }

        public static T GetEnum<T>(object enumStr)
        {
            return GetEnum<T>(enumStr, true);
        }

        public static T GetEnum<T>(object enumStr, bool ignoreCase)
        {
            return GetEnum<T>(enumStr, default(T), ignoreCase);
        }

        public static T GetEnum<T>(object enumStr, T defValue)
        {
            return GetEnum<T>(enumStr, defValue, true);
        }

        public static T GetEnum<T>(object enumStr, T defValue, bool ignoreCase)
        {
            if (enumStr == null)
            {
                return defValue;
            }
            T local = default(T);
            try
            {
                return (T)Enum.Parse(typeof(T), enumStr.ToString(), ignoreCase);
            }
            catch
            {
                return defValue;
            }
        }
    }

    public class EasyDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        // Methods
        public EasyDictionary()
        {
        }

        public EasyDictionary(IDictionary<TKey, TValue> innerDirectionary)
            : base(innerDirectionary)
        {
        }

        public virtual TValue Get(TKey key)
        {
            return this.Get(key, default(TValue));
        }

        public virtual TValue Get(TKey key, TValue defValue)
        {
            TValue local = defValue;
            if (base.ContainsKey(key))
            {
                try
                {
                    local = base[key];
                }
                catch
                {
                }
            }
            return local;
        }

        public virtual void Set(TKey key, TValue value)
        {
            if (base.ContainsKey(key))
            {
                base[key] = value;
            }
            else
            {
                base.Add(key, value);
            }
        }

        // Properties
        public virtual TValue this[TKey key]
        {
            get
            {
                return this.Get(key);
            }
            set
            {
                this.Set(key, value);
            }
        }

        public virtual TValue this[TKey key, TValue defValue]
        {
            get
            {
                return this.Get(key, defValue);
            }
        }
    }

    public sealed class EasyDictionary : EasyDictionary<string, object>
    {
        // Methods
        public EasyDictionary()
        {
        }

        public EasyDictionary(IDictionary<string, object> innerDirectionary)
            : base(innerDirectionary)
        {
        }

        public EasyDictionary(IList<EasyDictionary> dicts)
        {
            string[] strArray = null;
            string key = string.Empty;
            foreach (EasyDictionary dictionary in dicts)
            {
                if (dictionary.Keys.Count >= 2)
                {
                    strArray = dictionary.Keys.ToArray<string>();
                    key = ObjectHelper.ConvertValue<string>(dictionary.Get(strArray[0]));
                    this.Set(key, dictionary.Get(strArray[1]));
                }
            }
        }

        public EasyDictionary(DataTable dt)
        {
            string key = string.Empty;
            if (dt.Columns.Count >= 2)
            {
                string columnName = dt.Columns[0].ColumnName;
                string str3 = dt.Columns[1].ColumnName;
                foreach (DataRow row in dt.Rows)
                {
                    key = ObjectHelper.ConvertValue<string>(row[columnName]);
                    this.Set(key, row[str3]);
                }
            }
        }

        public EasyDictionary(IList<EasyDictionary> dicts, string keyField, string textField)
        {
            string key = string.Empty;
            foreach (EasyDictionary dictionary in dicts)
            {
                key = ObjectHelper.ConvertValue<string>(dictionary.Get(keyField));
                this.Set(key, dictionary.Get(textField));
            }
        }

        public EasyDictionary(DataTable dt, string keyColumnName, string textColumnName)
        {
            string key = string.Empty;
            foreach (DataRow row in dt.Rows)
            {
                key = ObjectHelper.ConvertValue<string>(row[keyColumnName]);
                this.Set(key, row[textColumnName]);
            }
        }

        public T Get<T>(string key)
        {
            return this.Get<T>(key, default(T));
        }

        public T Get<T>(string key, T defValue)
        {
            T local = defValue;
            if (base.ContainsKey(key))
            {
                local = ObjectHelper.ConvertValue<T>(base[key]);
            }
            return local;
        }
    }
}
