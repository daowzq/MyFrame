using HDFrame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using DataModel;
using Razor.DynamicJson;
using NHibernate;
using NHibernate.Criterion;
namespace HDFrame.SysModule
{
    public partial class Sysmodule : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"] + "";
            switch (action)
            {
                case "reader":
                    LoadTreeData();
                    break;
                case "getmaxnum":
                    GetMaxNum();
                    break;
            }
        }


        /// <summary>
        /// 获取最大编号
        /// </summary>
        private void GetMaxNum()
        {
            var MuxNum = DataModel.SysModule.FindAll().Max(ten => ten.SortIndex);
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
            var Arrs = DataModel.SysModule.FindAll(Expression.Sql("Code='" + Code + "'"));
            if (Arrs.Length > 0)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [DirectMethod]
        public string DeleteData(string ID)
        {
            var Ent = DataModel.SysModule.Find(ID);
            Ent.DoDelete();
            return "1";
        }
        /// <summary>
        /// 删除检查 1 可以删除 0 不可以删除
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [DirectMethod]
        public string DeleteCheck(string ID)
        {
            var Arrs = DataModel.SysModule.FindAllByProperty(DataModel.SysModule.Prop_ParentID, ID);
            if (Arrs.Length > 0)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }


        [DirectMethod]
        public string SaveData(string Record)
        {
            //    Server.HtmlDecode();
            DataModel.SysModule Ent = JSON.Deserialize<DataModel.SysModule>(Record);
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
            //  SysModuleTree.ExpandPath(Ent.ID);
            return Ent.ID;
        }

        #region 加载树
        protected void LoadTreeData()
        {
            //默认加载ParentID为root
            var list = DataModel.SysModule.FindAll().OrderBy(ten => ten.SortIndex).ToArray();
            List<NodeObject> NodeList = GetTree(list.ToArray(), "root");
            string TreeJson = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(NodeList);
            Response.Write(TreeJson);
            Response.End();
        }
        private List<NodeObject> GetTree(DataModel.SysModule[] Ent, string ParentID)
        {
            List<NodeObject> list = new List<NodeObject>();
            DataModel.SysModule[] TempEnt = Ent.Where(ten => ten.ParentID == ParentID).ToArray();

            //递归调用
            foreach (var item in TempEnt)
            {
                NodeObject tree = new NodeObject();
                if (item.Type.HasValue && item.Type == 0)
                {
                    tree.icon = "../icons/house-png/ext.axd";
                }
                tree.ID = item.ID;
                tree.ParentID = item.ParentID;
                tree.SortIndex = item.SortIndex;
                tree.Status = item.Status;
                tree.Url = item.Url;
                tree.Name = item.Name;
                tree.LastModifiedDate = item.LastModifiedDate;
                tree.Code = item.Code;
                tree.CreateDate = item.CreateDate;
                tree.Description = item.Description;
                tree.Type = item.Type;

                var hasLeaf = Ent.Any(ten => ten.ParentID == item.ID);
                if (hasLeaf)
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
            //扩展属性
            public string ID { get; set; }
            public string ParentID { get; set; }
            public string Code { get; set; }
            public string Name { get; set; }
            public int? Type { get; set; }
            public string Url { get; set; }
            public string Description { get; set; }
            public int? Status { get; set; }
            public int? SortIndex { get; set; }
            public DateTime? LastModifiedDate { get; set; }
            public DateTime? CreateDate { get; set; }
        }
        #endregion
    }
}