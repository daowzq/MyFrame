using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataModel;
using HDFrame.Common;
using NHibernate;
using NHibernate.Criterion;
using Castle.ActiveRecord.Queries;
using Castle.ActiveRecord;
namespace HDFrame.Testpage
{
    public partial class ProductsTest : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //TestProduct.FindAll(IDetachedQuery 
            // TestProduct.FindAll(Expression.IsNull(SysGroup.Prop_ParentID));
            //CountQuery cq = new CountQuery(typeof(TestProduct));
            //int recordCount = (int)ActiveRecordMediator.ExecuteQuery(cq);
        }
    }
}