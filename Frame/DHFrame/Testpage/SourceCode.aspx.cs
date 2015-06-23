using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.IO;

namespace HDFrame.Testpage
{
    public partial class SourceCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetFileText();
            switch (Request["action"] + "")
            {
                case "load":
                    GetFileText();
                    break;
            }
        }

        protected void GetFileText()
        {
            string path = MapPath("/testpage/sourcecode.aspx");
            string txt = File.ReadAllText(path);
            txt = Razor.StringHelper.Wrap(txt, "<pre>", "</pre>");
            Response.Write(txt);
            Response.End();
        }
    }
}