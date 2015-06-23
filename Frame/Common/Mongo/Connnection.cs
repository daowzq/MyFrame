using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Razor.Mongo
{
    public class Connnection
    {
        private static readonly string ConStr = ConfigurationManager.AppSettings["mongodb"];

        /// <summary>
        /// 服务器地址
        /// </summary>
        public static string ServerAddress
        {
            get
            {
                if (!string.IsNullOrEmpty(ConStr))
                {
                    var server = DynamicJson.DynamicJsonConvert.Parse(ConStr).server;
                    return server;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// DBName
        /// </summary>
        public static string DbName
        {
            get
            {
                if (!string.IsNullOrEmpty(ConStr))
                {
                    var server = DynamicJson.DynamicJsonConvert.Parse(ConStr).database;
                    return server;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        ///  用户名称
        /// </summary>
        public static string UserName
        {
            get
            {
                if (!string.IsNullOrEmpty(ConStr))
                {
                    var server = DynamicJson.DynamicJsonConvert.Parse(ConStr).username;
                    return server;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public static string Password
        {
            get
            {
                if (!string.IsNullOrEmpty(ConStr))
                {
                    var server = DynamicJson.DynamicJsonConvert.Parse(ConStr).password;
                    return server;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
