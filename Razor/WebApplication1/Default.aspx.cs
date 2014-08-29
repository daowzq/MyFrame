using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord;
using Model;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IConfigurationSource source = System.Configuration.ConfigurationSettings.GetConfig("activerecord") as IConfigurationSource;
        ActiveRecordStarter.Initialize(source, typeof(SurveyedResult));

        Response.Write(SurveyedResult.FindAll().Length);
        Response.End();

    }
}
