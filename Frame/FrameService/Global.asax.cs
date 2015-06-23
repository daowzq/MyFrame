using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using FrameService;
using System.Reflection;
using Castle.ActiveRecord.Framework;
using Castle.ActiveRecord;
using System.ServiceModel.Activation;
using FrameService.Services;

namespace FrameService
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            AuthConfig.RegisterOpenAuth();

            IConfigurationSource source = System.Configuration.ConfigurationManager.GetSection("activerecord") as IConfigurationSource;
            Assembly ably = Assembly.Load("DataModel"); //数据集集合
            ActiveRecordStarter.Initialize(ably, source);

            RegisterRoutes();//注册路由
        }
        private void RegisterRoutes()
        {
            // Edit the base address of Service1 by replacing the "Service1" string below
            RouteTable.Routes.Add(new ServiceRoute("file", new WebServiceHostFactory(), typeof(RestUpload)));
        }
        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }
    }
}
