using HDFrame.Common;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDFrame
{
    public partial class Default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Ents = DataModel.SysModule.FindAll(Expression.Sql("Status=1"));
            GetAuthModel(Ents);
        }

        /// <summary>
        /// 获取模块
        /// </summary>
        /// <param name="Modules"></param>
        protected void GetAuthModel(DataModel.SysModule[] Modules)
        {
            if (Modules.Length <= 0)
            {
                return;
            }
            List<DataModel.SysModule> Ents = new List<DataModel.SysModule>();
            foreach (var item in Modules)
            {
                Ents.Add(item);
            }

            Ents = Ents.OrderBy(ten => ten.SortIndex).ToList();
            this.PageState.Add("AuthModule", Razor.DynamicJson.DynamicJsonConvert.SerializeObject(Ents));
        }
    }
}