using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
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

        #region 获取MAC地址

        [DllImport("Iphlpapi.dll")]
        private static extern int SendARP(Int32 dest, Int32 host, ref   Int64 mac, ref   Int32 length);
        [DllImport("Ws2_32.dll")]
        private static extern Int32 inet_addr(string ip);

        ///<summary>
        /// 利用IP得到MAC地址
        ///</summary>
        ///<param name="remoteip">客户端ip</param>
        ///<returns>int16类型的mac</returns>
        static private Int64 GetRemoteMAC(string remoteip)
        {
            Int32 ldest = inet_addr(remoteip);
            try
            {
                Int64 macinfo = new Int64();
                Int32 len = 6;
                int res = SendARP(ldest, 0, ref   macinfo, ref   len);
                return macinfo;
            }
            catch (Exception err)
            {
                throw new Exception(string.Format("获取mac地址失败,{0}", err.Message));
            }
        }


        ///<summary>
        /// int64类型的mac转换成正确的客户端mac
        ///</summary>
        ///<returns>MAC</returns>
        private string GetClientMAC(string Ip)
        {
            Int64 macid = GetRemoteMAC(Ip);
            if (macid == 0)
                return "0";
            string beforeMacAddr = Convert.ToString(macid, 16);
            string endMacAddr = "";
            string[] macArray = new string[6];
            for (int i = 0; i < 6; i++)
            {
                macArray[i] = beforeMacAddr.Substring(i * 2, 2);
            }
            for (int i = 0; i < 6; i++)
            {
                endMacAddr += macArray[5 - i] + "-";
            }
            endMacAddr = endMacAddr.Substring(0, endMacAddr.Length - 1);
            endMacAddr = endMacAddr.ToUpper();
            return endMacAddr;
        }
        #endregion
    }
}
