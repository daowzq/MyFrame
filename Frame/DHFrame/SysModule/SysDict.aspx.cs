using Ext.Net;
using HDFrame.Common;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDFrame.SysModule
{
    public partial class SysDict : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request["action"] + "";
            switch (action)
            {
                case "reader":
                    LoadTreeData();
                    break;
                case "nodesch":
                    NodeSeach();
                    break;
            }
        }


        protected void NodeSeach()
        {
            string Name = Request["Name"] + "";
            string Code = Request["Code"] + "";
            string Where = " 1=1 ";
            if (!string.IsNullOrEmpty(Name))
            {
                Where += " and ( Name like '%" + Name + "%' or (" + GetPinyinWhereString("Name", Name) + ")) ";
            }
            if (!string.IsNullOrEmpty(Code))
            {
                Where += " and  Code like '%" + Code + "%'";
            }
            var Arr = DataModel.SysDict.FindAll(Expression.Sql(Where));
            Response.Write(JSON.Serialize(Arr));
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
            var Arrs = DataModel.SysDict.FindAll(Expression.Sql("Code='" + Code + "'"));
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
            var Ent = DataModel.SysDict.Find(ID);
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
            var Arrs = DataModel.SysDict.FindAllByProperty(DataModel.SysDict.Prop_ParentID, ID);
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
            DataModel.SysDict Ent = JSON.Deserialize<DataModel.SysDict>(Record);
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

        #region 加载树
        protected void LoadTreeData()
        {
            //默认加载ParentID为root
            var list = DataModel.SysDict.FindAll().OrderBy(ten => ten.SortIndex).ToArray();
            List<NodeObject> NodeList = GetTree(list.ToArray(), "root");
            string TreeJson = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(NodeList);
            Response.Write(TreeJson);
            Response.End();
        }
        private List<NodeObject> GetTree(DataModel.SysDict[] Ent, string ParentID)
        {
            List<NodeObject> list = new List<NodeObject>();
            DataModel.SysDict[] TempEnt = Ent.Where(ten => ten.ParentID == ParentID).ToArray();

            //递归调用
            foreach (var item in TempEnt)
            {
                NodeObject tree = new NodeObject();
                tree.ID = item.ID;
                tree.ParentID = item.ParentID;
                tree.SortIndex = item.SortIndex;
                tree.Name = item.Name;
                tree.Value = item.Value;
                tree.Code = item.Code;
                tree.Path = item.Path;
                tree.Remarks = item.Remarks;
                tree.CreateDate = item.CreateDate;

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
            public string Value { get; set; }
            public string Path { get; set; }
            public string Remarks { get; set; }
            public int? SortIndex { get; set; }
            public DateTime? CreateDate { get; set; }
        }
        #endregion

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

    }
}