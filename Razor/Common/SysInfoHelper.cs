using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Razor
{
    public sealed class SysInfoHelper
    {
        /// <summary>
        /// 获取本机IP地址列表
        /// </summary>
        /// <returns></returns>
        public static string[] GetLocalHostIP()
        {
            IPHostEntry hostinfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] ips = hostinfo.AddressList;
            string[] strLocalHostIPs = new string[ips.Length];

            for (int index = 0; index < ips.Length; index++)
            {
                strLocalHostIPs[index] = ips[index].ToString();
            }
            return strLocalHostIPs;
        }

        /// <summary>
        /// 获取本机主机名
        /// </summary>
        /// <returns></returns>
        public static string GetLocalHostName()
        {
            string strHostName = Dns.GetHostName();
            return strHostName;
        }

        /// <summary>
        /// 获取新的Process 组件并将其与当前活动的进程关联的主模块的完整路径，包含文件名(进程名)
        /// </summary>
        public static string CurrentProcessModuleName()
        {
            return System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        }

        /// <summary>
        /// 获取和设置当前目录（即该进程从中启动的目录）的完全限定路径
        /// </summary>
        public static string CurrentDirectory()
        {
            return System.Environment.CurrentDirectory; ;
        }

        /// <summary>
        ///当前Thread 的当前应用程序域的基目录 
        /// </summary>
        public static string CurrentDomainDic()
        {
            return System.AppDomain.CurrentDomain.BaseDirectory;
        }

        /// <summary>
        ///获取应用程序的当前工作目录 
        /// </summary>
        public static string GetCurrentDirectory()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }
    }
}
