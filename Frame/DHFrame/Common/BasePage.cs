using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HDFrame.Common
{
    public class BasePage : Page
    {
        private Hashtable pageState = new Hashtable();
        private PageStateContainer containter;

        #region 属性
        /// <summary>
        /// 页面状态，用于前后台传输数据
        /// </summary>
        public virtual Hashtable PageState
        {
            get { return pageState; }
        }
        /// <summary>  
        /// 获取IP地址  
        /// </summary>  
        public static string IPAddress
        {
            get
            {
                string userIP;
                // HttpRequest Request = HttpContext.Current.Request;  
                HttpRequest Request = HttpContext.Current.Request; // ForumContext.Current.Context.Request;  
                // 如果使用代理，获取真实IP  
                if (Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
                    userIP = Request.ServerVariables["REMOTE_ADDR"];
                else
                    userIP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                if (userIP == null || userIP == "")
                    userIP = Request.UserHostAddress;
                return userIP;
            }
        }
        #endregion

        #region ASP.NET 事件

        /// <summary>
        /// 初始化方法（先于Page_Load和OnLoad执行）
        /// </summary>
        /// <param name="e"></param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.EnableViewState = false;   // 禁用ViewState

            if (this.containter == null && Form != null)
            {
                this.containter = new PageStateContainer();
                this.Form.Controls.Add(containter);
            }

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
            if (!IsCallback)
            {
                try
                {
                    DataModel.SysLog Log = new DataModel.SysLog();
                    Log.CreateTime = DateTime.Now;
                    Log.ExceptionMsg = ex.Message;
                    Log.StackTrace = ex.StackTrace;
                    Log.LoginIP = IPAddress;
                    Log.Create();
                }
                catch { }
                finally
                {
                    throw ex;
                }
            }
            else
            //处理异步情况
            {
                try
                {
                    DataModel.SysLog Log = new DataModel.SysLog();
                    Log.CreateTime = DateTime.Now;
                    Log.ExceptionMsg = ex.Message;
                    Log.StackTrace = ex.StackTrace;
                    Log.LoginIP = IPAddress;
                    Log.Create();
                }
                catch { }
                finally
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 渲染前触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void Page_PreRender(object sender, EventArgs e)
        {
            if (containter != null)
            {
                containter.Value = this.packPageState();
            }
        }
        /// <summary>
        /// 打包页面信息，并将其绑定到隐藏的服务器端控件上
        /// </summary>
        private string packPageState()
        {
            return Razor.DynamicJson.DynamicJsonConvert.SerializeObject(this.pageState);
        }

        //去缓存
        protected override void OnLoad(EventArgs e)
        {
            Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Expires = 0;
            base.OnLoad(e);
        }

        #endregion 事件
    }
}