using Razor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestModel;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SearchCriterion _searchCriterion = new HqlSearchCriterion();
            _searchCriterion.AllowPaging = true;
            _searchCriterion.GetRecordCount = true;

            SurveyQuestion[] arr = SurveyQuestion.FindAll(_searchCriterion);

            string str = Razor.JsonHelper.GetJsonString(arr);
            //   Response.Write(Razor.JsonHelper.GetJsonString(arr));
            Response.Write(str);

            // Response.Write("<br/>fasdfsdfasdf");
        }
    }
}