using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class BaseGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pageSize = Request["limit"] + "";
            string pageCount = Request["page"] + "";
            string startIndex = Request["start"] + "";
            string searchMsg = Request["searchMsg"] + "";
            if (!string.IsNullOrEmpty(Request["action"] + ""))
            {
                string json = "{ total: 20,'items': [ { 'name': 'Lisa', 'email': 'lisa@simpsons.com', 'phone': '555-111-1224' } ]}";
                Response.Write(json);
                Response.End();
            }
        }
    }
}