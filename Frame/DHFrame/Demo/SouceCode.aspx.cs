using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDFrame.Demo
{
    public partial class SouceCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request["action"] + "")
            {
                case "load":
                    GetFileText();
                    break;
            }
        }

        protected void GetFileText()
        {
            string path = Request["filepath"] + "";
            path = MapPath(path);
            string txt = File.ReadAllText(path);
            txt = Server.HtmlEncode(txt);

            StringBuilder strb = new StringBuilder();
            strb.Append("<head>");
            strb.Append("<link href=\"../Js/highlight/styles/default.css\" rel=\"stylesheet\" />");
            strb.Append("<link href=\"../Js/highlight/styles/github.css\" rel=\"stylesheet\" />");
            strb.Append("<link href=\"../Js/highlight/styles/googlecode.css\" rel=\"stylesheet\" />");
            strb.Append(" <script src=\"../Js/highlight/highlight.pack.js\"></script>");

            strb.Append("<script>hljs.initHighlightingOnLoad();</script>");
            strb.Append("</head>");
            txt = Razor.StringHelper.Wrap(txt, "<code class='coffeescript'>", "</code>");
            txt = Razor.StringHelper.Wrap(txt, "<pre>", "</pre>");
            string Html = strb.ToString() + txt;
            Response.Write(Html);
            Response.End();
        }
    }
}