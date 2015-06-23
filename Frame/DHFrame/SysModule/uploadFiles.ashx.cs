using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Net;
using System.Configuration;

namespace WebApplication1
{
    /// <summary>
    /// uploadFiles 的摘要说明
    /// </summary>
    public class uploadFiles : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.CacheControl = "no-cache";
            UploadFile(context);
        }

        public void UploadFile(HttpContext context)
        {
            string updir = FileHelper.GetUploadPath() + "\\" + DateTime.Now.ToString("yy-MM-dd");
            string extname = string.Empty;
            string fullname = string.Empty;
            string filename = string.Empty;

            try
            {
                for (int j = 0; j < context.Request.Files.Count; j++)
                {
                    HttpPostedFile uploadFile = context.Request.Files[j];
                    int offset = Convert.ToInt32(context.Request["chunk"]);
                    int total = Convert.ToInt32(context.Request["chunks"]);
                    string name = context.Request["name"];

                    if (!Directory.Exists(updir))
                        Directory.CreateDirectory(updir);

                    //文件没有分块
                    if (total == 1)
                    {
                        if (uploadFile.ContentLength > 0)
                        {
                            extname = Path.GetExtension(uploadFile.FileName);
                            fullname = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                            filename = uploadFile.FileName;
                            uploadFile.SaveAs(string.Format("{0}\\{1}", updir, filename));
                        }
                    }
                    else
                    {
                        fullname = WriteTempFile(uploadFile, offset);//文件分成多块上传
                        //如果是最后一个分块文件,则把文件从临时文件夹中移到上传文件夹中
                        if (total - offset == 1)
                        {
                            //System.IO.FileInfo fi = new System.IO.FileInfo(fullname);
                            //string newFullName = string.Format("{0}\\{1}", updir, uploadFile.FileName);
                            //FileInfo newFi = new FileInfo(newFullName);
                            //if (newFi.Exists)
                            //    newFi.Delete();         //文件名存在则删除旧文件
                            //fi.MoveTo(newFullName);   //移到上传文件夹中

                            //REST上传By WGM(2015-6-18)
                            string FileID = SaveFileByREST(fullname);
                            context.Response.Write(FileID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("Message" + ex.ToString());
            }
        }

        /// <summary>
        /// REST 方式上传文件
        /// </summary>
        /// <param name="FullFileName"></param>
        private string SaveFileByREST(string FullFileName)
        {
            // Create the REST request.
            string url = ConfigurationManager.AppSettings["serviceUrl"];
            string FileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(FullFileName).Replace(".part", ""); //文件名
            bool IsAllSave = false;               //是否全部存储完毕
            string FileSaveInfo = string.Empty;   //数据库中的文件信息

            FileInfo FInfo = new FileInfo(FullFileName);
            if (FInfo.Length > 20 * 1024 * 1024) //使用分块传输
            {
                using (FileStream fs = FInfo.OpenRead())
                {
                    int numBytesToRead = (int)fs.Length;
                    while (numBytesToRead > 0)
                    {
                        byte[] bytes = new byte[20 * 1024 * 1024];
                        // Read may return anything from 0 to numBytesToRead. 
                        int n = fs.Read(bytes, 0, bytes.Length);

                        //chunk: 表示分块存储
                        string requestUrl = string.Format("{0}/Upload/{1}/{2}", url, FileName, "chunk-" + fs.Length);
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
                        request.Method = "POST";
                        request.ContentType = "text/plain";
                        request.ContentLength = bytes.Length;

                        using (Stream requestStream = request.GetRequestStream())
                        {
                            requestStream.Write(bytes, 0, bytes.Length);
                            requestStream.Close();
                        }
                        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                        {
                            Stream resStream = response.GetResponseStream();
                            using (StreamReader sr = new StreamReader(resStream))
                            {
                                string data = sr.ReadToEnd();
                                if (data.Contains("allok"))
                                {
                                    IsAllSave = true;
                                    FileSaveInfo = data;
                                }
                            }
                        }

                        // Break when the end of the file is reached. 
                        if (n == 0)
                            break;
                        numBytesToRead -= n;
                    }
                }
                //成功保存删除文件
                if (IsAllSave)
                    FInfo.Delete();
            }
            else
            {
                string Description = "nochunk";
                string requestUrl = string.Format("{0}/Upload/{1}/{2}", url, FileName, Description);

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
                request.Method = "POST";
                request.ContentType = "text/plain";

                byte[] fileToSend = File.ReadAllBytes(FullFileName);
                request.ContentLength = fileToSend.Length;

                using (Stream requestStream = request.GetRequestStream())
                {
                    // Send the file as body request.
                    requestStream.Write(fileToSend, 0, fileToSend.Length);
                    requestStream.Close();
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream resStream = response.GetResponseStream();
                    using (StreamReader sr = new StreamReader(resStream))
                    {
                        string data = sr.ReadToEnd();
                        FileSaveInfo = data;
                    }
                }
                // 上传成功,删除临时文件
                File.Delete(FullFileName);
            }
            return FileSaveInfo;
        }
        /// <summary>
        /// 保存临时文件 
        /// </summary>
        /// <param name="uploadFile"></param>
        /// <param name="chunk"></param>
        /// <returns></returns>
        private string WriteTempFile(HttpPostedFile uploadFile, int chunk)
        {

            string tempDir = FileHelper.GetTempPath();
            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }
            string fullName = string.Format("{0}\\{1}.part", tempDir, uploadFile.FileName);
            if (chunk == 0)
            {
                //如果是第一个分块，则直接保存
                uploadFile.SaveAs(fullName);
            }
            else
            {
                //如果是其他分块文件 ，则原来的分块文件，读取流，然后文件最后写入相应的字节
                FileStream fs = new FileStream(fullName, FileMode.Append);
                if (uploadFile.ContentLength > 0)
                {
                    int FileLen = uploadFile.ContentLength;
                    byte[] input = new byte[FileLen];

                    // Initialize the stream.
                    System.IO.Stream MyStream = uploadFile.InputStream;

                    // Read the file into the byte array.
                    MyStream.Read(input, 0, FileLen);

                    fs.Write(input, 0, FileLen);
                    fs.Close();
                }
            }


            return fullName;
        }


        public bool IsReusable
        {
            get { return true; }
        }
    }

    /// <summary>
    ///FileHelper 的摘要说明
    /// </summary>
    public class FileHelper
    {
        public FileHelper()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// 获取上传目录
        /// </summary>
        /// <returns></returns>
        public static string GetUploadPath()
        {
            string path = HttpContext.Current.Server.MapPath("~/");
            string dirname = GetDirName();
            //string uploadDir = path + "\\" + dirname;
            string uploadDir = path + dirname;
            CreateDir(uploadDir);
            return uploadDir;
        }
        /// <summary>
        /// 获取临时目录
        /// </summary>
        /// <returns></returns>
        public static string GetTempPath()
        {
            string path = HttpContext.Current.Server.MapPath("~/");
            string dirname = GetTempDirName();
            // string uploadDir = path + "\\" + dirname;
            string uploadDir = path + dirname;
            CreateDir(uploadDir);
            return uploadDir;
        }
        private static string GetDirName()
        {
            //   return System.Configuration.ConfigurationManager.AppSettings["uploaddir"];
            return "UPLOADFILE";
        }
        private static string GetTempDirName()
        {
            //return System.Configuration.ConfigurationManager.AppSettings["tempdir"];
            return "tempdir";
        }
        public static void CreateDir(string path)
        {
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }
    }

}