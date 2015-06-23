using DataModel;
using HDFrame.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using NHibernate.Criterion;
using Razor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDFrame
{
    public partial class ProductDemo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["action"] + "" == "ajax")
            {
                Response.Write(ResponseJsonBySQL());
                Response.End();
            }

            if (Request["action"] + "" == "data")
            {
                string data = Request["data"] + "";
                var jObj = (JObject)JsonConvert.DeserializeObject(data);
                string sql = @"insert into Employee 
                             select NEWID(), '{0}',{1},'{2}','{3}','{4}',GETDATE(),NEWID(),'WGM'";
                sql = string.Format(sql, (jObj["Name"] + "").Replace("\"", ""),
                                          (jObj["Age"] + "").Replace("\"", ""),
                                           (jObj["Job"] + "").Replace("\"", ""),
                                            (jObj["Email"] + "").Replace("\"", ""),
                                             (jObj["Postion"] + "").Replace("\"", ""));
                Razor.DataHelper.ExecSql(sql);
                Response.Write("1");
                Response.End();
            }
        }


        /// <summary>
        /// 输出Json字符串
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string ResponseJsonBySQL()
        {
            //if (string.IsNullOrEmpty(sql)) return null;


            List<ICriterion> exps = new List<ICriterion>();

            //查询数据时
            if (!string.IsNullOrEmpty(PagingStruct.search))
            {
                var jarr = (JArray)JsonConvert.DeserializeObject(PagingStruct.search);
                dynamic jsonObj = Razor.DynamicJson.DynamicJsonConvert.Parse(PagingStruct.search);

                string Name = jsonObj[0].Name;
                string Age = jsonObj[1].Age;
                string Email = jsonObj[2].Email;

                if (!string.IsNullOrEmpty(Name))
                {
                    exps.Add((ICriterion)Expression.Like("Name", Name));
                }
                if (!string.IsNullOrEmpty(Age))
                {
                    exps.Add((ICriterion)Expression.Eq("Age", int.Parse(Age)));
                }
                if (!string.IsNullOrEmpty(Email))
                {
                    exps.Add((ICriterion)Expression.Like("Email", Email));
                }
            }

            var list = DataHelper.GetPageList<Employee>(PagingStruct.Page, PagingStruct.PageSize,
                                                    new Order[] { new Order("CreateTime", false) }, exps.ToArray());
            GridJsonStruct gjs = new GridJsonStruct(list, DataHelper.GetCount<Employee>());
            return Razor.DynamicJson.DynamicJsonConvert.SerializeObject(gjs);

        }


        /// <summary>
        /// DataTable分页
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="PageIndex">页索引,注意：从1开始</param>
        /// <param name="PageSize">每页大小</param>
        /// <returns>分好页的DataTable数据</returns>
        public static DataTable GetPagedTable(DataTable dt, int PageIndex, int PageSize)
        {
            if (PageIndex == 0) { return dt; }
            DataTable newdt = dt.Copy();
            newdt.Clear();
            int rowbegin = (PageIndex - 1) * PageSize;
            int rowend = PageIndex * PageSize;

            if (rowbegin >= dt.Rows.Count)
            { return newdt; }

            if (rowend > dt.Rows.Count)
            { rowend = dt.Rows.Count; }
            for (int i = rowbegin; i <= rowend - 1; i++)
            {
                DataRow newdr = newdt.NewRow();
                DataRow dr = dt.Rows[i];
                foreach (DataColumn column in dt.Columns)
                {
                    newdr[column.ColumnName] = dr[column.ColumnName];
                }
                newdt.Rows.Add(newdr);
            }
            return newdt;
        }
    }
}