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
using TestModel;
using Razor.Data;

public partial class _Default : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        SurveyQuestion[] arr = SurveyQuestion.FindAll();

        //Response.Write(Razor.JsonHelper.GetJsonString(arr));
        Response.Write(arr[0].ToString());
        arr[0].RazorPropertyChanged += _Default_RazorPropertyChanged;
        arr[0].SurveyTitile = "sssss";
        Response.Write("<br/>");
        // Response.Write(SurveyQuestion.TableName);
        //SurveyQuestion Ent = new SurveyQuestion();

    }

    void _Default_RazorPropertyChanged(object sender, Razor.Data.RazorPropertyChangedEventArgs e)
    {
        // throw new Exception("new exception");
        // 属性发生改变时出发该事件
    }
}
