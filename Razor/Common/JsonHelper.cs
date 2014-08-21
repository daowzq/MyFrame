using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Razor
{
    public static class JsonHelper
    {
        // Methods
        public static string GetJsonString(object obj)
        {
            return JsonConvert.SerializeObject(obj, 0);
        }

        public static string GetJsonStringFromDataTable(DataTable dt)
        {
            return JsonConvert.SerializeObject(dt, new JsonConverter[] { new DataTableConverter() });
        }

        public static T GetObject<T>(string jsonstr)
        {
            return JsonConvert.DeserializeObject<T>(jsonstr);
        }
    }
}
