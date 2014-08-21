using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Razor;

namespace Razor
{
    class Program
    {
        static void Main(string[] args)
        {
            ////string str1 = "2014-8-29";
            //List<string> lt = new List<string>();
            //lt.Add("hello");
            //lt.Add("world");
            //string result = StringHelper.Join(lt);
            //Console.WriteLine(result);

            MailHelper.SendMailHelper.mailAccount = "你妹啊";
            MailHelper.SendMailHelper.mailPwd = "wu19920101110";
            MailHelper.SendMailHelper.smtpHost = "smtp.126.com";
            MailHelper.SendMailHelper.mailSenderAddress = "wu922008@126.com";
            string cc = "2803974130@qq.com";
            string title = "测试哦";
            string body = "这是测试内容哦!";
            List<string> list = new List<string>();
            list.Add(cc);
            MailHelper.SendMailHelper.SendMailAndCC("568909447@qq.com", title, body, list);

        }
    }
}
