using DataModel;
using Ext.Net;
using HDFrame.Common;
using Newtonsoft.Json;
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
    public partial class SysRole : BasePage
    {
        #region 全局变量
        private readonly string TypeSign = "role";
        #endregion

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
                case "orgreader":
                    OrgTreeData();
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

        }
        /// <summary>
        /// 获取最大编号
        /// </summary>
        private void GetMaxNum()
        {
            var MuxNum = SysGroupOrRole.FindAll().Max(ten => ten.SortIndex);
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
            int Count = SysGroupOrRole.GetCount(Expression.Sql("GroupCode='" + Code + "'"));
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
            var Count = SysGroupOrRole.GetCount(Expression.Sql("ParentID='" + ID + "'"));
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
            var Ent = SysGroupOrRole.Find(ID);
            //删除相关联的数据
            var GUEnts = SysGroupUser.FindAllByProperties(SysGroupUser.Prop_SysGroupID, Ent.ID);
            var OrgEnts = SysOrgRefGroupOrRole.FindAllByProperty(SysOrgRefGroupOrRole.Prop_GroupOrRoleID, Ent.ID);
            if (GUEnts.Length > 0)
            {
                foreach (var item in GUEnts)
                {
                    item.DoDelete();
                }
            }
            if (OrgEnts.Length > 0)
            {
                foreach (var item in OrgEnts)
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
            SysGroupOrRole Ent = JSON.Deserialize<SysGroupOrRole>(Record);
            Ent.Type = TypeSign;//role 代表角色
            if (string.IsNullOrEmpty(Ent.ParentID))
            {
                Ent.ParentID = "root";
            }
            if (string.IsNullOrEmpty(Ent.ID))
            {
                Ent.DoCreate();
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
            if (string.IsNullOrEmpty(OrgID)) return "0";
            string[] idList = JsonConvert.DeserializeObject<string[]>(Ids);
            if (idList != null && idList.Length > 0)
            {
                SysGroupUser.DoBatchDelete(OrgID, idList);//* OrgID:组织结构ID
            }
            return "1";
        }

        [DirectMethod]
        public string RefUserToOrg(string Json, string PID)
        {
            var OrgEnt = SysGroupOrRole.Find(PID);
            var Ents = JSON.Deserialize<SysUser[]>(Json);
            foreach (var item in Ents)
            {
                //去除重复
                int a = SysGroupUser.GetCount(Expression.Sql("SysUserID='" + item.ID + "' and SysGroupID='" + OrgEnt.ID + "'"));
                if (a > 0) continue;

                SysGroupUser OrgUsr = new SysGroupUser();
                OrgUsr.SysGroupID = OrgEnt.ID;
                OrgUsr.SysGroupName = OrgEnt.GroupName;
                OrgUsr.SysUserID = item.ID;
                OrgUsr.SysUserName = item.Name;
                OrgUsr.DoCreate();
            }
            return "1";
        }

        /// <summary>
        /// 保存选中的树节点
        /// </summary>
        /// <param name="NodeIds"></param>
        /// <param name="RoleOrGroupID"></param>
        /// <returns></returns>
        [DirectMethod]
        public string SaveSelectNode(string NodeIds, string RoleOrGroupID)
        {
            if (string.IsNullOrEmpty(NodeIds)) return "0";
            if (!string.IsNullOrEmpty(RoleOrGroupID))
            {
                string[] idList = JsonConvert.DeserializeObject<string[]>(NodeIds);
                var GrEnt = SysGroupOrRole.Find(RoleOrGroupID);
                //先删除
                string SQL = "delete from SysOrgRefGroupOrRole where GroupOrRoleID='" + RoleOrGroupID + "'";
                DataHelper.ExecSql(SQL);

                foreach (var item in idList)
                {
                    var OrgEnt = SysOrganization.Find(item);
                    SysOrgRefGroupOrRole Ent = new SysOrgRefGroupOrRole();
                    Ent.OrgID = OrgEnt.ID;
                    Ent.OrgName = OrgEnt.Name;
                    Ent.GroupOrRoleID = GrEnt.ID;
                    Ent.GroupOrRoleName = GrEnt.GroupName;
                    Ent.DoCreate();
                }
            }
            else
            {
                return "0";
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
                Where += " and SysUserName like '%" + Name + "%' or (" + GetPinyinWhereString("SysUserName", Name) + ")  ";
            }

            if (e.Parameters.GetParameter("PID") != null)
            {
                var PID = e.Parameters.GetParameter("PID").Value;
                if (PID == "root")
                {
                }
                else
                {
                    Where += " and SysGroupID='" + PID + "' ";
                    SysGroupUser[] SysOUserEnt = DataHelper.GetPageList<SysGroupUser>(start, pageSize, new Order[] { new Order("CreateTime", false) }, out total, Expression.Sql(Where));
                    e.Total = total;
                    IList<SysUser> UserList = SysGroupUser.GetUsersByEnts(SysOUserEnt);
                    foreach (var item in SysOUserEnt)
                    {
                        var ent = UserList.Where(ten => ten.ID == item.SysUserID).First();
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


        #region 加载树

        protected void OrgTreeData()
        {
            string TreeNodeID = Request["TreeNodeID"] + "";
            List<string> SltIds = new List<string>();
            if (!string.IsNullOrEmpty(TreeNodeID))
            {
                var Ents = SysOrgRefGroupOrRole.FindAllByProperty("GroupOrRoleID", TreeNodeID);
                foreach (var item in Ents)
                {
                    SltIds.Add(item.OrgID);
                }
            }

            var list = SysOrganization.FindAll().OrderBy(ten => ten.SortIndex).ToArray();
            List<NodeObject> NodeList = GetOrgTree(list.ToArray(), SltIds, "root");
            string TreeJson = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(NodeList);
            TreeJson = TreeJson.Replace("check", "checked");
            Response.Write(TreeJson);
            Response.End();
        }

        private List<NodeObject> GetOrgTree(SysOrganization[] Ent, List<string> CheckedIds, string ParentID)
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
                tree.expanded = true;

                if (CheckedIds.Count > 0)
                {
                    bool Checked = CheckedIds.Any(ten => ten == item.ID);
                    if (Checked)
                    {
                        tree.check = true;
                    }
                }
                else
                {
                    tree.check = false;
                }


                if (ParentID == "root") //展开Root下节点
                {
                    tree.expanded = true;
                }

                var havaChild = Ent.Any(ten => ten.ParentID == item.ID);
                if (havaChild)
                {
                    tree.leaf = false;
                    tree.children = GetOrgTree(Ent, CheckedIds, item.ID);
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


        protected void LoadTreeData()
        {
            //默认加载ParentID为root
            var list = SysGroupOrRole.FindAll().OrderBy(ten => ten.SortIndex).ToArray();
            List<NodeObject> NodeList = GetTree(list.ToArray(), "root");
            string TreeJson = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(NodeList);
            Response.Write(TreeJson);
            Response.End();
        }

        private List<NodeObject> GetTree(SysGroupOrRole[] Ent, string ParentID)
        {
            List<NodeObject> list = new List<NodeObject>();
            SysGroupOrRole[] TempEnt = Ent.Where(ten => ten.ParentID == ParentID).ToArray();

            //递归调用
            foreach (var item in TempEnt)
            {
                NodeObject tree = new NodeObject();

                //自定义属性
                tree.id = item.ID;
                tree.text = item.GroupName;
                tree.ID = item.ID;
                tree.ParentID = item.ParentID;
                tree.GroupName = item.GroupName;
                tree.GroupCode = item.GroupCode;
                tree.Path = item.Path;
                tree.Type = item.Type;
                tree.Remark = item.Remark;
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
            public bool check { get; set; }
            //扩展属性
            public string ID { get; set; }
            public string GroupName { get; set; }
            public string ParentID { get; set; }
            public string GroupCode { get; set; }
            public string Path { get; set; }
            public string Type { get; set; }
            public string Remark { get; set; }
            public string State { get; set; }
            public int? SortIndex { get; set; }
            public DateTime? CreateTime { get; set; }
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

    }
}