using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace Razor.MailHelper
{
    #region 发送邮件
    public sealed class SendMailHelper
    {
        /// <summary>
        /// 默认smtp.126.com,需配置
        /// </summary>
        public static string smtpHost = string.Empty;
        /// <summary>
        /// 默认端口
        /// </summary>
        public static int smtpPort = 25;

        /// <summary>
        /// 发送方的邮件地址,必须配置
        /// </summary>
        public static string mailSenderAddress = string.Empty;
        /// <summary>
        /// 发送方的账号,必须配置
        /// </summary>
        public static string mailAccount = string.Empty;

        /// <summary>
        /// 发送方的账号密码,必须配置
        /// </summary>
        public static string mailPwd = string.Empty;

        /// <summary>
        /// 邮件编码方式,默认为UTF8编码(标题)
        /// </summary>
        public static System.Text.Encoding encoding = System.Text.Encoding.UTF8;

        /// <summary>
        /// 邮件内容编码方式,默认UTF8(常用GB2312,UTF8)
        /// </summary>
        public static System.Text.Encoding bodyEncoding = System.Text.Encoding.UTF8;

        /// <summary>
        /// 邮件的优先级
        /// </summary>
        public static MailPriority prity = MailPriority.Normal;

        /// <summary>
        /// 清除配置
        /// </summary>
        public static void ClearSet()
        {
            smtpHost = string.Empty;
            mailSenderAddress = string.Empty;
            mailAccount = string.Empty;
            mailPwd = string.Empty;
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toUserAddr">要发送的邮件地址</param>
        /// <param name="title">标题</param>
        /// <param name="body">内容</param>
        /// <param name="bccList">发送人</param>
        /// <param name="addFilesStream">附件(文件流)</param>
        /// <param name="ccList">抄送人</param>
        /// <param name="sendedcallBack">异步发送回调</param>
        public static void SendMail(string toUserAddr, string title, string body, List<string> bccList, List<System.IO.Stream> addFilesStream, List<string> ccList, SendCompletedEventHandler sendedcallBack)
        {
            if (string.IsNullOrEmpty(smtpHost))
            {
                throw new Exception("请配置smtp服务器!");
            }
            if (string.IsNullOrEmpty(mailSenderAddress))
            {
                throw new Exception("请配置邮件mailSenderAddress字段!");
            }
            if (string.IsNullOrEmpty(mailAccount) || string.IsNullOrEmpty(mailPwd))
            {
                throw new Exception("请配置发送方的邮件服务器,账号及密码!");
            }

            //创建smtpclient对象(发送方)   
            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = smtpHost;
            client.Port = smtpPort; //默认为25

            string from = mailSenderAddress;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(from, mailPwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;     //通过网络发送到SMTP服务器

            //这个配置的是发件人的要显示在邮件的名称   
            MailAddress mailfrom = new MailAddress(mailSenderAddress, mailAccount, encoding);//发件人邮箱地址，名称，编码UTF8
            MailAddress mailto = new MailAddress(toUserAddr);       //收件人邮箱地址，名称，编码UTF8  

            //创建mailMessage对象   
            System.Net.Mail.MailMessage message = new MailMessage(mailfrom, mailto);
            message.Subject = title;                //邮件标题
            message.Priority = prity;               //邮件的优先级
            message.Body = body;                    //正文默认格式为html   
            message.IsBodyHtml = true;              //邮件内容是否为html格式
            message.BodyEncoding = bodyEncoding;    //邮件内容编码
            message.SubjectEncoding = encoding;     //主题编码

            //添加多个联系人
            if (null != bccList && bccList.Count > 0)
            {
                message.Bcc.Add(StringHelper.Join(bccList)); //可以添加多个收件人
            }

            //邮件附件
            if (null != addFilesStream && addFilesStream.Count > 0)
            {
                foreach (var item in addFilesStream)
                {
                    message.Attachments.Add(new Attachment(item, string.Empty));
                }
            }

            //添加邮件抄送
            if (null != ccList && ccList.Count > 0)
            {
                string address = Razor.StringHelper.Join(ccList);
                message.CC.Add(address);
            }

            //异步发送
            if (null != sendedcallBack)
            {
                client.SendCompleted += sendedcallBack;
                string userState = toUserAddr + ",Send success!" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                client.SendAsync(message, userState);
                return;
            }
            client.Send(message);
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="toUserAddr">要发送的邮件地址</param>
        /// <param name="title">主题</param>
        /// <param name="body">内容</param>
        public static void SendMail(string toUserAddr, string title, string body)
        {
            SendMail(toUserAddr, title, body, null, null, null, null);
        }

        /// <summary>
        /// 发送邮件(多人发送)
        /// </summary>
        /// <param name="toUserAddr">要发送的邮件地址</param>
        /// <param name="title">主题</param>
        /// <param name="body">内容</param>
        /// <param name="bccList">发送人</param>
        public static void SendMail(string toUserAddr, string title, string body, List<string> bccList)
        {
            SendMail(toUserAddr, title, body, bccList, null, null, null);
        }

        /// <summary>
        /// 发送邮件(多人抄送)
        /// </summary>
        /// <param name="toUserAddr">要发送的邮件地址</param>
        /// <param name="title">主题</param>
        /// <param name="body">内容</param>
        /// <param name="ccList">抄送人</param>
        public static void SendMailAndCC(string toUserAddr, string title, string body, List<string> ccList)
        {
            SendMail(toUserAddr, title, body, null, null, ccList, null);
        }

        /// <summary>
        /// 发送邮件(单人附件)
        /// </summary>
        /// <param name="toUserAddr">要发送的邮件地址</param>
        /// <param name="title">主题</param>
        /// <param name="body">内容</param>
        /// <param name="fileStream">附件(文件流形式)</param>
        public static void SendMailAddFile(string toUserAddr, string title, string body, System.IO.Stream fileStream)
        {
            List<System.IO.Stream> lst = new List<System.IO.Stream>();
            lst.Add(fileStream);
            SendMail(toUserAddr, title, body, null, lst, null, null);
        }

        /// <summary>
        /// 发送邮件(多人附件)
        /// </summary>
        /// <param name="toUserAddr">要发送的邮件地址</param>
        /// <param name="title">主题</param>
        /// <param name="body">内容</param>
        /// <param name="fileStream">附件(文件流形式)</param>
        public static void SendMailAddFile(string toUserAddr, string title, string body, List<string> bccList, System.IO.Stream fileStream)
        {
            List<System.IO.Stream> lst = new List<System.IO.Stream>();
            lst.Add(fileStream);
            SendMail(toUserAddr, title, body, bccList, lst, null, null);
        }

        /// <summary>
        /// 发送邮件(单人多个附件)
        /// </summary>
        /// <param name="toUserAddr">要发送的邮件地址</param>
        /// <param name="title">主题</param>
        /// <param name="body">内容</param>
        /// <param name="filesStream">附件(多个文件流形式)</param>
        public static void SendMailAddFile(string toUserAddr, string title, string body, List<System.IO.Stream> filesStream)
        {
            SendMail(toUserAddr, title, body, null, filesStream, null, null);
        }
    }
    #endregion


}
