using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using HDFrame.Common;
namespace HDFrame.Testpage
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["query"] + ""))
            {
                string query = Request["query"] + "";
                object[] arr = new object[] {
                    new {Code="1",Name="AAAAA"},
                    new {Code="2",Name="BBBBB"},
                    new {Code="3",Name="CCCCC"},
                    new {Code="4",Name="DDDDD"},
                    new {Code="5",Name="FFFFF"},
                    new {Code="6",Name="GGGGG"}
                };

                GridJsonStruct gjs = new GridJsonStruct(arr, 5);
                string Json = Razor.DynamicJson.DynamicJsonConvert.SerializeObject(arr);
                Response.Write(Json);
                Response.End();
            }
        }
        /// <summary>
        /// MongoDb 测试
        /// </summary>
        protected void MongoDbT()
        {
            string Config = Razor.Mongo.Connnection.ServerAddress;
            string DBName = Razor.Mongo.Connnection.DbName;

            Razor.Mongo.MongoBaseAction BA = new Razor.Mongo.MongoBaseAction(DBName);
            Stuend st = new Stuend();
            st.Name = "张三";
            st.Age = 18;
            BA.Insert<Stuend>(typeof(Stuend).Name, st);
            X.Msg.Alert("Tip", "插入成功").Show();
        }
        class Stuend
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}