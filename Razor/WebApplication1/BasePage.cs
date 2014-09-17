using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Security;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Castle.ActiveRecord;
using Razor.Data;
using Razor;

/// <summary>
/// 页面基类
/// </summary>
public class BasePage : Page
{

    #region ASP.NET 事件

    /// <summary>
    /// 初始化方法（先于Page_Load和OnLoad执行）
    /// </summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.EnableViewState = false;   // 禁用ViewState
    }

    /// <summary>
    /// 异常处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void Page_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();

        /*--写事件日志开始--*/

        // 这里只对异步的异常做处理，同步的可以自定义处理方式
        //if (IsAsyncRequest)
        //{
        //    Server.ClearError();

        //    Response.Write(ex.Message);
        //    Response.End();
        //    return;
        //}
        throw ex;
    }

    /// <summary>
    /// 渲染前触发
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected virtual void Page_PreRender(object sender, EventArgs e)
    {
        //// 异步请求时，直接输出数据
        //if (IsAsyncRequest)
        //{
        //    Response.Write(this.packPageState());
        //    Response.End();
        //}
        //else if (containter != null)
        //{
        //    containter.Value = this.packPageState();
        //}
    }

    //去缓存
    protected override void OnLoad(EventArgs e)
    {
        Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
        Response.Expires = 0;
        // -------------------------------------------------------
        // 去除页面的缓存
        // -------------------------------------------------------
        // 页面 No Cache	< META HTTP-EQUIV="PRAGMA" CONTENT="NO-CACHE" />
        // 这里要特别注意，如果”>“ 与 META 之间有空格的话，
        // 那这段字符串会直接显示在页面上，
        // 必须去掉两个括号与括号内容之间的空格。
        //string strNoCache = "<META HTTP-EQUIV=\"PRAGMA\" CONTENT=\"NO-CACHE\">";
        //Response.Write(strNoCache);
        base.OnLoad(e);

    }


    #endregion 事件

}
