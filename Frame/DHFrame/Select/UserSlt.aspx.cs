using HDFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using DataModel;
using NHibernate.Criterion;
namespace HDFrame.Select
{
    public partial class UserSlt : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region 加载数据
        protected void RefreshDataList(object sender, StoreReadDataEventArgs e)
        {
            int start = e.Start;
            int pageSize = e.Limit;
            int total = 0;

            //查询条件
            string Where = GetQueryString();
            var arr = Razor.DataHelper.GetPageList<SysUser>(start, pageSize, out total, Expression.Sql(Where));
            e.Total = total;
            DataStore.Data = arr;
            DataStore.DataBind();
        }
        protected string GetQueryString()
        {
            string Where = " 1=1 and State <> '-1' ";
            string WorkNo = Request["WorkNo"] + "";
            string Name = Request["Name"] + "";
            if (!string.IsNullOrEmpty(WorkNo))
            {
                Where += " and WorkNo like '%" + WorkNo + "%' ";
            }
            if (!string.IsNullOrEmpty(Name))
            {
                // Where += " and Name like '%" + Name + "%'";
                Where += " and " + GetPinyinWhereString("Name", Name);
            }
            return Where;
        }

        public string GetPinyinWhereString(string fieldName, string pinyinIndex)
        {
            string[,] hz = Razor.StringHelper.GetHanziScope(pinyinIndex);
            string whereString = "(";
            for (int i = 0; i < hz.GetLength(0); i++)
            {
                whereString += "(SUBSTRING(" + fieldName + ", " + (i + 1) + ", 1) >= '" + hz[i, 0] + "' AND SUBSTRING(" + fieldName + ", " + (i + 1) + ", 1) <= '" + hz[i, 1] + "') AND ";
            }
            if (whereString.Substring(whereString.Length - 4, 4) == "AND ")
                return whereString.Substring(0, whereString.Length - 4) + ")";
            else
                return "(1=1)";
        }
        #endregion

    }
}