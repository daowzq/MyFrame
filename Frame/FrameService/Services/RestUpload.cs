using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;

namespace FrameService.Services
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RestUpload
    {
        #region 上传图片
        [WebInvoke(UriTemplate = "Upload/{fileName}/{description}", Method = "POST")]
        public string UploadPhoto(string fileName, string description, Stream fileContents)
        {
            byte[] buffer = new byte[32768];
            MemoryStream ms = new MemoryStream();
            int bytesRead, totalBytesRead = 0;
            do
            {
                bytesRead = fileContents.Read(buffer, 0, buffer.Length);
                totalBytesRead += bytesRead;

                ms.Write(buffer, 0, bytesRead);
            } while (bytesRead > 0);

            //DataModel.SysRegister.GetDictByCode("SaveDirectory", true).FirstOrDefault().Value;
            string SavePath = ConfigurationManager.AppSettings["SaveDirectory"];
            SavePath = SavePath + "\\" + DateTime.Now.ToString("yy-MM-dd");
            string FullFile = SavePath + "\\" + fileName;
            //保存文件路径(eg:D:\HDFrameFileDirectory\15-06-18)
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }

            if (description.Contains("nochunk"))
            {
                DataModel.SysFile SFile = null;
                using (FileStream Fs = new FileStream(FullFile, FileMode.OpenOrCreate))
                {
                    ms.WriteTo(Fs);
                    ms.Flush();
                    //保存到数据库
                    SFile = new DataModel.SysFile();
                    SFile.FileFullPath = FullFile;
                    SFile.FileName = fileName;
                    SFile.FileSuffix = Path.GetExtension(fileName);
                    SFile.Length = (int)ms.Length;
                    SFile.State = "1";
                    SFile.DoCreate();
                }
                ms.Close();
                return string.Format("{{\"ID\":\"{0}\",\"FileName\":\"{1}\",\"SaveState\":\"{2}\"}}", SFile.ID + "", SFile.FileName + "", "ok");
            }
            else
            {
                DataModel.SysFile SFile = null;
                using (FileStream Fs = new FileStream(FullFile, FileMode.Append))
                {
                    ms.WriteTo(Fs);
                    ms.Flush();
                    if (ms.Length == long.Parse(description.Split('-')[1]))
                    {
                        //保存到数据库
                        SFile = new DataModel.SysFile();
                        SFile.FileFullPath = FullFile;
                        SFile.FileName = fileName;
                        SFile.FileSuffix = Path.GetExtension(fileName);
                        SFile.Length = (int)ms.Length;
                        SFile.State = "1";
                        SFile.DoCreate();
                    }
                }
                ms.Close();
                if (SFile != null)
                {
                    return string.Format("{{\"ID\":\"{0}\",\"FileName\":\"{1}\",\"SaveState\":\"{2}\"}}", SFile.ID + "", SFile.FileName + "", "allok");
                }
                else
                {
                    return string.Format("{{\"ID\":\"{0}\",\"FileName\":\"{1}\",\"SaveState\":\"{2}\"}}", "", "", "");
                }
            }
        }
        #endregion
    }
}