using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace FrameService.Services
{
    public sealed class Singleton
    {
        private Dictionary<string, string> tokenDict = new Dictionary<string, string>();
        private static Singleton s_value = null;
        // 私有构造器，阻止这个类外部的任何代码创建实例
        private Singleton() { }
        public static Singleton GetSingleton()
        {
            if (s_value != null) return s_value;

            Singleton temp = new Singleton(); //此对象会被垃圾回收机制自动释放
            Interlocked.CompareExchange(ref s_value, temp, null);
            return s_value;
        }
        /// <summary>
        /// 用户认证SeesionID
        /// </summary>
        public Dictionary<string, string> TokenDict
        {
            get
            {
                return tokenDict;
            }
        }
    }
}