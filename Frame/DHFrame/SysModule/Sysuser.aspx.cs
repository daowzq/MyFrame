using DataModel;
using Ext.Net;
using HDFrame.Common;
using NHibernate.Criterion;
using Razor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDFrame.SysModule
{
    public partial class Sysuser : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                ResourceM1.AddScript("afterInit();");
            }
        }

        #region 公共方法
        [DirectMethod]
        public string SaveData(string json)
        {
            SysUser Ent = Newtonsoft.Json.JsonConvert.DeserializeObject<SysUser>(json);
            if (string.IsNullOrEmpty(Ent.ID))
            {
                Ent.DoCreate();
            }
            else
            {
                var SourceEnt = SysUser.Find(Ent.ID);
                var NewEnt = DataHelper.MergeDataIf<SysUser>(Ent, SourceEnt);
                NewEnt.DoUpdate();
            }
            return Ent.ID;
        }

        //冻结,解冻用户
        [DirectMethod]
        public string FreezeUser(string ID)
        {
            var Ent = SysUser.Find(ID);
            if (Ent.State == "1")
            {
                Ent.State = "0"; //0 标识冻结
            }
            else if (Ent.State == "0")
            {
                Ent.State = "1"; //1 启用
            }
            Ent.DoUpdate();
            return "1";
        }
        //删除数据
        [DirectMethod]
        public string DeleteRecord(string Id)
        {
            var Ent = SysUser.Find(Id);
            Ent.State = "-1";
            Ent.DoUpdate();
            return "1";
        }

        //导出Excel
        [DirectMethod]
        public string ExportExcel()
        {
            string SQL = "select * from  SysUser where ";
            SQL += GetQueryString();
            SQL += " order by CreateTime desc ";
            string PgKey = "SYSUSER";
            Dictionary<string, string> XlsMap = new Dictionary<string, string>();
            XlsMap.Add("WorkNo", "工号");
            XlsMap.Add("Name", "姓名");
            XlsMap.Add("EnglishName", "英文名");
            XlsMap.Add("LoginName", "登陆名");
            XlsMap.Add("State", "状态");
            XlsMap.Add("Email", "邮箱");
            XlsMap.Add("Phone", "手机");
            XlsMap.Add("TelNo", "电话");
            XlsMap.Add("QQ", "QQ");
            XlsMap.Add("WeChat", "微信");
            XlsMap.Add("WorkInDate", "入职日期");
            XlsMap.Add("WorkOutDat  ", "离职日期");

            DataTable dt = DataHelper.QueryDataTable(SQL);
            ExcelHelper ExcelOut = new ExcelHelper(dt, XlsMap, PgKey);
            string FileFullPath = ExcelOut.Start();
            return FileFullPath;
        }
        #endregion

        #region 加载数据
        protected void ListStore_RefershData(object sender, StoreReadDataEventArgs e)
        {
            int start = e.Start;
            int pageSize = e.Limit;
            int total = 0;

            //查询条件
            string Where = GetQueryString();

            var arr = DataHelper.GetPageList<SysUser>(start, pageSize, new Order[] { new Order("CreateTime", false) }, out total, Expression.Sql(Where));
            e.Total = total;
            ListStore.Data = arr;
            ListStore.DataBind();
        }
        protected string GetQueryString()
        {
            string Where = " 1=1 and State<>'-1' "; //State ='-1' 标识删除状态  0冻结状态
            string SchType = Request["SchType"] + "";
            string SchVal = Request["SchVal"] + "";
            SchVal = SchVal.Replace("输入工号/姓名/姓名简拼", "");

            //高级查询字段
            string WorkNo = Request["schWorkNo"] + "";
            string Name = Request["schName"] + "";
            string Phone = Request["schPhone"] + "";
            string Freeze = Request["schFreeze"] + "";

            if (int.Parse(SchType) % 2 == 0) //高级查询
            {
                if (!string.IsNullOrEmpty(WorkNo))
                {
                    Where += " and  WorkNo like '%" + WorkNo + "%' ";
                }
                if (!string.IsNullOrEmpty(Name))
                {
                    Where += " and ( Name like '%" + Name + "%' or (" + GetPinyinWhereString("Name", Name) + ")) ";
                }
                if (!string.IsNullOrEmpty(Phone))
                {
                    Where += " and Phone like '%" + Phone + "%' ";
                }
                if (!string.IsNullOrEmpty(Freeze))
                {
                    Freeze = (Freeze == "冻结" ? "0" : "1");
                    Where += " and State ='" + Freeze + "' ";
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(SchVal))
                {
                    Where += " and ( WorkNo like '%" + SchVal + "%' or (" + GetPinyinWhereString("Name", SchVal) + ") )";
                }
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