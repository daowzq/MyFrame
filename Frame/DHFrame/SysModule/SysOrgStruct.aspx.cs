using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using NHibernate.Criterion;
using HDFrame.Common;
using DataModel;
using Razor;
using Castle.ActiveRecord;
using Newtonsoft.Json;
using System.Data;
namespace HDFrame.SysModule
{
    public partial class SysOrgStruct : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                CompomnentInit();
                ResourceM1.AddScript("afterInit();");
            }
            switch (Request["action"] + "")
            {
                case "reader":
                    LoadTreeData();
                    break;
                case "getmaxnum":
                    GetMaxNum();
                    break;
            }
        }
        #region 方法

        /// <summary>
        /// 组件初始化
        /// </summary>
        private void CompomnentInit()
        {
            lblPath.Text = "当前节点:" + "远道软件有限公司";
        }
        /// <summary>
        /// 获取最大编号
        /// </summary>
        private void GetMaxNum()
        {
            var MuxNum = SysOrganization.FindAll().Max(ten => ten.SortIndex);
            Response.Write(MuxNum.GetValueOrDefault() + 5);
            Response.End();
        }

        /// <summary>
        /// 检查是否重复的编码
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        [DirectMethod]
        public string CheckCode(string Code)
        {
            int Count = SysOrganization.GetCount(Expression.Sql("Code='" + Code + "'"));
            return Count > 0 ? "0" : "1";
        }

        /// <summary>
        /// 删除检查 1 可以删除 0 不可以删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [DirectMethod]
        public string DeleteCheck(string ID)
        {
            var Count = SysOrganization.GetCount(Expression.Sql("ParentID='" + ID + "'"));
            return Count > 0 ? "0" : "1";
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [DirectMethod]
        public string DeleteData(string ID)
        {
            var Ent = SysOrganization.Find(ID);
            //删除相关联的人员
            var RefEnts = SysOrgUser.FindAllByProperties(SysOrgUser.Prop_OrgID, Ent.ID);
            if (RefEnts.Length > 0)
            {
                foreach (var item in RefEnts)
                {
                    item.DoDelete();
                }
            }
            Ent.DoDelete();
            return "1";
        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="Record"></param>
        [DirectMethod]
        public string SaveData(string Record)
        {
            //    Server.HtmlDecode();
            SysOrganization Ent = JSON.Deserialize<SysOrganization>(Record);
            if (string.IsNullOrEmpty(Ent.ParentID))
            {
                Ent.ParentID = "root";
            }
            if (string.IsNullOrEmpty(Ent.ID))
            {
                Ent.DoCreate();
                //保存Path,包含本身ID
                Ent.Path = Ent.Path + "/" + Ent.ID;
                Ent.DoUpdate();
            }
            else
            {
                Ent.Update();
            }
            return Ent.ID;
        }
        /// <summary>
        /// 移除人员
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        [DirectMethod]
        public string RemoveUser(string OrgID, string Ids)
        {
            string[] idList = JsonConvert.DeserializeObject<string[]>(Ids);
            if (idList != null && idList.Length > 0)
            {
                SysOrgUser.DoBatchDelete(OrgID, idList);
            }
            return "1";
        }
        /// <summary>
        /// 绑定人员到根节点
        /// </summary>
        /// <returns></returns>
        [DirectMethod]
        public string BindRootNode()
        {
            var Ent = SysOrganization.FindFirstByProperties(SysOrganization.Prop_ParentID, "root");
            if (Ent != null)
            {
                // SysOrganization SysOrgEnt = new SysOrganization();
                SysOrganization.BindUserToRootNode(Ent);
            }
            return "1";
        }
        [DirectMethod]
        public string RefUserToOrg(string Json, string PID)
        {
            var OrgEnt = SysOrganization.Find(PID);
            var Ents = JSON.Deserialize<SysUser[]>(Json);
            foreach (var item in Ents)
            {
                //去除重复
                int a = SysOrgUser.GetCount(Expression.Sql("UserID='" + item.ID + "' and OrgID='" + OrgEnt.ID + "'"));
                if (a > 0) continue;

                SysOrgUser OrgUsr = new SysOrgUser();
                OrgUsr.OrgID = OrgEnt.ID;
                OrgUsr.OrgName = OrgEnt.Name;
                OrgUsr.UserID = item.ID;
                OrgUsr.UserName = item.Name;
                OrgUsr.DoCreate();
            }
            return "1";
        }

        protected void RefreshData(object sender, StoreReadDataEventArgs e)
        {
            int start = e.Start;
            int pageSize = e.Limit;
            int total = 0;

            //查询条件
            string Where = " 1=1 ";
            string Name = Request["UserQuery"] + "";
            Name = Name.Replace("输入姓名简拼", "");
            if (!string.IsNullOrEmpty(Name))
            {
                Where += " and UserName like '%" + Name + "%' or (" + GetPinyinWhereString("UserName", Name) + ")  ";
            }

            if (e.Parameters.GetParameter("PID") != null)
            {
                var PID = e.Parameters.GetParameter("PID").Value;
                if (PID == "root")
                {
                    SysUser[] UserEnts = DataHelper.GetPageList<SysUser>(start, pageSize, new Order[] { new Order("CreateTime", false) }, out total, Expression.Sql(Where));
                    e.Total = total;
                    UserStore.Data = UserEnts;
                    UserStore.DataBind();
                }
                else
                {
                    Where += " and OrgID='" + PID + "' ";
                    SysOrgUser[] SysOUserEnt = DataHelper.GetPageList<SysOrgUser>(start, pageSize, new Order[] { new Order("CreateTime", false) }, out total, Expression.Sql(Where));
                    e.Total = total;
                    IList<SysUser> UserList = SysOrgUser.GetUsersByEnts(SysOUserEnt);
                    foreach (var item in SysOUserEnt)
                    {
                        var ent = UserList.Where(ten => ten.ID == item.UserID).First();
                        if (ent != null)
                        {
                            UserList.Add(ent);
                        }
                    }
                    UserStore.Data = UserList;
                    UserStore.DataBind();
                    return;
                }
            }
            //默认情况
            SysUser[] Arr = DataHelper.GetPageList<SysUser>(start, pageSize, new Order[] { new Order("CreateTime", false) }, out total, Expression.Sql(Where));
            e.Total = total;
            UserStore.Data = Arr;
            UserStore.DataBind();
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

        #region 导出Exce
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <returns></returns>
        [DirectMethod]
        public string ExportExcel(string OrgID)
        {
            string SQL = @"select 
             		        A.OrgName,A.CreateTime,B.WorkNo,B.Name,B.EnglishName
             	        from SysOrgUser As A
             	        left join SysUser As B
             		        on A.UserID=B.ID
                        where  A.OrgID='{0}' order by CreateTime desc";
            // string SQL = "select * from SysOrgUser As A";
            SQL = string.Format(SQL, OrgID);
            string PgKey = "SYSORGUSER";
            Dictionary<string, string> XlsMap = new Dictionary<string, string>();
            XlsMap.Add("OrgName", "组织结构");
            XlsMap.Add("WorkNo", "工号");
            XlsMap.Add("Name", "姓名");
            XlsMap.Add("EnglishName", "英文名");
            XlsMap.Add("CreateTime", "创建日期");

            DataTable dt = DataHelper.QueryDataTable(SQL);
            ExcelHelper ExcelOut = new ExcelHelper(dt, XlsMap, PgKey);
            string FileFullPath = ExcelOut.Start();
            return FileFullPath;
        }
        #endregion

        #region 加载树

        protected void LoadTreeData()
        {
            //默认加载ParentID为root
            var list = SysOrganization.FindAll().OrderBy(ten => ten.SortIndex).ToArray();
            List<NodeObject> NodeList = GetTree(list.ToArray(), "root");
            string TreeJson = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(NodeList);
            Response.Write(TreeJson);
            Response.End();
        }

        private List<NodeObject> GetTree(SysOrganization[] Ent, string ParentID)
        {
            List<NodeObject> list = new List<NodeObject>();
            SysOrganization[] TempEnt = Ent.Where(ten => ten.ParentID == ParentID).ToArray();

            //递归调用
            foreach (var item in TempEnt)
            {
                NodeObject tree = new NodeObject();
                if (!string.IsNullOrEmpty(item.OrgType) && item.OrgType == "position") //职务
                {
                    tree.icon = "../icons/user-png/ext.axd";
                }

                //自定义属性
                tree.id = item.ID;
                tree.text = item.Name;
                tree.ID = item.ID;
                tree.ParentID = item.ParentID;
                tree.Code = item.Code;
                tree.Name = item.Name;
                tree.Path = item.Path;
                tree.OrgType = item.OrgType;
                tree.State = item.State;
                tree.SortIndex = item.SortIndex;
                tree.CreateTime = item.CreateTime;
                tree.expanded = false;

                if (ParentID == "root") //展开Root下节点
                {
                    tree.expanded = true;
                }

                var havaChild = Ent.Any(ten => ten.ParentID == item.ID);
                if (havaChild)
                {
                    tree.leaf = false;
                    tree.children = GetTree(Ent, item.ID);
                    list.Add(tree);
                }
                else
                {
                    tree.leaf = true;
                    tree.children = null;
                    list.Add(tree);
                }
            }
            return list;
        }

        public class NodeObject
        {
            public string iconCls { get; set; }
            public bool leaf { get; set; }
            public List<NodeObject> children { get; set; }
            public string icon { get; set; }
            public string id { get; set; }
            public string text { get; set; }
            public bool expanded { get; set; }
            //扩展属性
            public string ID { get; set; }
            public string Name { get; set; }
            public string ParentID { get; set; }
            public string Code { get; set; }
            public string Path { get; set; }
            public string OrgType { get; set; }
            public string State { get; set; }
            public int? SortIndex { get; set; }
            public DateTime? CreateTime { get; set; }
        }
        #endregion
    }
}