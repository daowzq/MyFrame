using Razor;
using Razor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            ApplicationStartInit();
        }


        public void ApplicationStartInit()
        {

            //获取当前程序集
            Assembly[] assemblies = new Assembly[] { Assembly.GetExecutingAssembly() };
            Assembly[] exAssemblies = ObjectHelper.GetAssemblysByNames(new string[] { "TestModel" });

            // 初始化Entity
            EntityManager.InitializeEntity(assemblies, exAssemblies, typeof(EntityBase<>));

        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}