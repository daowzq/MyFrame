using DataModel;
using Ext.Net;
using HDFrame.Common;
using Newtonsoft.Json;
using NHibernate.Criterion;
using Razor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDFrame.SysModule
{
    public partial class SysAuth : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["action"] + "")
            {
                case "reader":
                    LoadTreeData();
                    break;
                case "readOrg":
                    LoadModelTreeData();
                    break;
                case "readrole":
                    LoadOrgTreeData();
                    break;
            }
        }

        #region 公共方法
        /// <summary>
        /// 保存选中的树节点
        /// </summary>
        /// <param name="NodeIds"></param>
        /// <param name="RoleOrGroupID"></param>
        /// <returns></returns>
        [DirectMethod]
        public string SaveSelectNode(string NodeIds, string RefID, string TabIndex)
        {
            if (string.IsNullOrEmpty(NodeIds)) return "0";
            if (!string.IsNullOrEmpty(RefID))
            {
                string[] idList = JsonConvert.DeserializeObject<string[]>(NodeIds);
                switch (TabIndex)
                {
                    case "0":
                        {
                            //先删除
                            string SQL = "delete from SysOrgAuth where OrgID='" + RefID + "'";
                            DataHelper.ExecSql(SQL);

                            var GrEnt = SysOrganization.Find(RefID);
                            foreach (var item in idList)
                            {
                                var OrgEnt = DataModel.SysModule.Find(item);
                                //创建
                                SysOrgAuth Ent = new SysOrgAuth();
                                Ent.OrgID = GrEnt.ID;
                                Ent.OrgName = GrEnt.Name;
                                Ent.ModuleID = OrgEnt.ID;
                                Ent.ModuleName = OrgEnt.Name;
                                Ent.DoCreate();
                            }
                        }
                        break;
                    case "1":
                        {
                            //先删除
                            string SQL = "delete from SysGroupAuth where GroupID='" + RefID + "'";
                            DataHelper.ExecSql(SQL);

                            var GrEnt = SysGroupOrRole.Find(RefID);
                            foreach (var item in idList)
                            {
                                var OrgEnt = DataModel.SysModule.Find(item);
                                //创建
                                SysGroupAuth Ent = new SysGroupAuth();
                                Ent.GroupID = GrEnt.ID;
                                Ent.GroupName = GrEnt.GroupName;
                                Ent.ModuleID = OrgEnt.ID;
                                Ent.ModuleName = OrgEnt.Name;
                                Ent.DoCreate();
                            }
                        }
                        break;
                    case "2":
                        {
                            //先删除
                            string SQL = "delete from SysUserAuth where UserID='" + RefID + "'";
                            DataHelper.ExecSql(SQL);

                            var GrEnt = SysUser.Find(RefID);
                            foreach (var item in idList)
                            {
                                var OrgEnt = DataModel.SysModule.Find(item);
                                //创建
                                SysUserAuth Ent = new SysUserAuth();
                                Ent.UserID = GrEnt.ID;
                                Ent.UserName = GrEnt.Name;
                                Ent.ModuleID = OrgEnt.ID;
                                Ent.ModuleName = OrgEnt.Name;
                                Ent.DoCreate();
                            }
                        }
                        break;
                }
            }
            else
            {
                return "0";
            }
            return "1";
        }
        #endregion

        #region 生成权限树

        /// <summary>
        /// 生成权限树
        /// </summary>
        /// <returns></returns>
        [DirectMethod]
        public string CreateAuthList()
        {
            // SysOrgAuth
            // SysGroupAuth
            // SysUserAuth
            var OrgEnts = SysOrgAuth.FindAll();
            //SysOrgAuth.get
            return "1";
        }
        #endregion

        #region 用户GridPanel
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
            string Where = " 1=1 ";

            //高级查询字段
            string WorkNo = Request["schWorkNo"] + "";
            string Name = Request["schName"] + "";

            if (!string.IsNullOrEmpty(Name))
            {
                Where += " and ( Name like '%" + Name + "%' or (" + GetPinyinWhereString("Name", Name) + ")) ";
            }
            if (!string.IsNullOrEmpty(WorkNo))
            {
                Where += " and WorkNo like '%" + WorkNo + "%' ";
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

        #region 组角色树
        protected void LoadOrgTreeData()
        {
            var list = SysGroupOrRole.FindAll().OrderBy(ten => ten.SortIndex).ToArray();
            List<NodeObject> NodeList = GetOrgTree(list.ToArray(), "root");
            string TreeJson = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(NodeList);
            Response.Write(TreeJson);
            Response.End();
        }

        private List<NodeObject> GetOrgTree(SysGroupOrRole[] Ent, string ParentID)
        {
            List<NodeObject> list = new List<NodeObject>();
            var TempEnt = Ent.Where(ten => ten.ParentID == ParentID).ToArray();

            foreach (var item in TempEnt)
            {
                NodeObject tree = new NodeObject();

                //自定义属性
                tree.id = item.ID;
                tree.text = item.GroupName;
                tree.ID = item.ID;
                if (ParentID == "root") //展开Root下节点
                {
                    tree.expanded = true;
                }

                var havaChild = Ent.Any(ten => ten.ParentID == item.ID);
                if (havaChild)
                {
                    tree.leaf = false;
                    tree.children = GetOrgTree(Ent, item.ID);
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
        #endregion

        #region 组织机构树

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
        #endregion

        #region 系统模块树
        protected void LoadModelTreeData()
        {
            string TreeNodeID = Request["TreeNodeID"] + "";
            string TabIndex = Request["TabIndex"] + "";

            List<string> SltIds = new List<string>();
            if (!string.IsNullOrEmpty(TreeNodeID))
            {
                switch (TabIndex)
                {
                    case "0"://组织结构
                        {
                            var Ents = SysOrgAuth.FindAllByProperty("OrgID", TreeNodeID);
                            foreach (var item in Ents)
                            {
                                SltIds.Add(item.ModuleID);
                            }
                        }
                        break;
                    case "1"://组角色
                        {
                            var Ents = SysGroupAuth.FindAllByProperty("GroupID", TreeNodeID);
                            foreach (var item in Ents)
                            {
                                SltIds.Add(item.ModuleID);
                            }
                        }
                        break;
                    case "2"://人员
                        {
                            var Ents = SysUserAuth.FindAllByProperty("UserID", TreeNodeID);
                            foreach (var item in Ents)
                            {
                                SltIds.Add(item.ModuleID);
                            }
                        }
                        break;
                }
            }

            var list = DataModel.SysModule.FindAll().OrderBy(ten => ten.SortIndex).ToArray();
            List<NodeObject> NodeList = GetModelTree(list.ToArray(), SltIds, "root");
            string TreeJson = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(NodeList);
            TreeJson = TreeJson.Replace("check", "checked");
            Response.Write(TreeJson);
            Response.End();
        }
        private List<NodeObject> GetModelTree(DataModel.SysModule[] Ent, List<string> CheckedIds, string ParentID)
        {
            List<NodeObject> list = new List<NodeObject>();
            DataModel.SysModule[] TempEnt = Ent.Where(ten => ten.ParentID == ParentID).ToArray();

            //递归调用
            foreach (var item in TempEnt)
            {
                NodeObject tree = new NodeObject();
                if (item.Type.HasValue && item.Type == 0)
                    tree.icon = "../icons/house-png/ext.axd";
                //展开指定节点
                if (item.Path.Contains("root"))
                    tree.expanded = true;

                tree.ID = item.ID;
                tree.ParentID = item.ParentID;
                tree.SortIndex = item.SortIndex;
                tree.Type = item.Type.GetValueOrDefault() + "";
                tree.Name = item.Name;
                tree.Code = item.Code;

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

                var hasLeaf = Ent.Any(ten => ten.ParentID == item.ID);
                if (hasLeaf)
                {
                    tree.leaf = false;
                    tree.children = GetModelTree(Ent, CheckedIds, item.ID);
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
        #endregion

        #region 树节点
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
            public string Name { get; set; }
            public string ParentID { get; set; }
            public string Code { get; set; }
            public string Path { get; set; }
            public string Type { get; set; }
            public string OrgType { get; set; }
            public string State { get; set; }
            public int? SortIndex { get; set; }
            public DateTime? CreateTime { get; set; }
        }
        #endregion
    }
}