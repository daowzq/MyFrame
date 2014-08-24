using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Razor;
using System.Security.Cryptography;

namespace Razor
{
    class Program
    {
        static void Main(string[] args)
        {
            //        ////string str1 = "2014-8-29";
            //        //List<string> lt = new List<string>();
            //        //lt.Add("hello");
            //        //lt.Add("world");
            //        //string result = StringHelper.Join(lt);
            //        //Console.WriteLine(result);

            //        //MailHelper.SendMailHelper.mailAccount = "你妹啊";
            //        //MailHelper.SendMailHelper.mailPwd = "wu19920101110";
            //        //MailHelper.SendMailHelper.smtpHost = "smtp.126.com";
            //        //MailHelper.SendMailHelper.mailSenderAddress = "wu922008@126.com";
            //        //string cc = "2803974130@qq.com";
            //        //string title = "测试哦";
            //        //string body = "这是测试内容哦!";
            //        //List<string> list = new List<string>();
            //        //list.Add(cc);
            //        //MailHelper.SendMailHelper.SendMailAndCC("568909447@qq.com", title, body, list);

            //        //  string result = SysInfoHelper.CurrentProcessModuleName();
            //        //  Console.WriteLine(result);

            //        //string str1 = "hello world";
            //        //string result = SecurityHelper.MD5Encrypt(str1);
            //        //Console.WriteLine(result);

            //        //Console.WriteLine(SecurityHelper.Des3DecryptStr(result));

            //        // string outPath = @"D:\test1.txt";
            //        // SecurityHelper.EncryptFile(@"D:\test.txt", outPath);
            //        // SecurityHelper.DencryptFile(outPath, @"d:\resolver.txt");

            //        string privateKey, publicKey;
            //        SecurityHelper.CreateRSAPairKey(out privateKey, out publicKey);
            //        // Console.WriteLine(privateKey);
            //        string result;
            //        //result = SecurityHelper.RSAEcryptString("hello world", publicKey);
            //        //Console.WriteLine(result);

            //        result = SecurityHelper.RSAEncryptString("你好,世界", 1024, publicKey);
            //        Console.WriteLine(result);

            //        result = SecurityHelper.RSADecryptString(result, 1024, privateKey);
            //        Console.WriteLine(result);





            //string result = Razor.Serializer.SerializeToBase64(st);
            //Console.WriteLine(result);
            //st = (Student)Razor.Serializer.DeserializeFromBase64(result);

            Student st = new Student();
            st.Age = 12;
            st.Class = "2.12";
            st.Name = "小明";
            st.Teacher = "张明";


        }

        #region
        //static void Main()
        //{
        //    try
        //    {
        //        //Create a UnicodeEncoder to convert between byte array and string.
        //        UnicodeEncoding ByteConverter = new UnicodeEncoding();

        //        //Create byte arrays to hold original, encrypted, and decrypted data. 
        //        byte[] dataToEncrypt = ByteConverter.GetBytes("Data to Encrypt");
        //        byte[] encryptedData;
        //        byte[] decryptedData;

        //        //Create a new instance of RSACryptoServiceProvider to generate 
        //        //public and private key data. 

        //        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        //        {
        //            string privateKey = RSA.ToXmlString(true);
        //            string publicKey = RSA.ToXmlString(true);
        //            encryptedData = RSAEncrypt(dataToEncrypt, privateKey, false);

        //            decryptedData = RSADecrypt(encryptedData, publicKey, false);

        //            //Display the decrypted plaintext to the console. 
        //            Console.WriteLine("Decrypted plaintext: {0}", ByteConverter.GetString(decryptedData));
        //        }
        //    }
        //    catch (ArgumentNullException)
        //    {
        //        //Catch this exception in case the encryption did 
        //        //not succeed.
        //        Console.WriteLine("Encryption failed.");

        //    }
        //    RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        //    string prKey = rsa.ToXmlString(true);
        //    string puKey = rsa.ToXmlString(true);

        //    string result = SecurityHelper.RSAEcryptString("hello world", puKey);
        //    SecurityHelper.RSADcryptString(result, prKey);

        //}

        static public byte[] RSAEncrypt(byte[] DataToEncrypt, string RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider. 
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs 
                    //toinclude the public key information.
                    //RSA.ImportParameters(RSAKeyInfo);
                    RSA.FromXmlString(RSAKeyInfo);
                    //Encrypt the passed byte array and specify OAEP padding.   
                    //OAEP padding is only available on Microsoft Windows XP or 
                    //later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException   
            //to the console. 
            catch (CryptographicException e)
            {
                Console.WriteLine(e.Message);

                return null;
            }

        }

        static public byte[] RSADecrypt(byte[] DataToDecrypt, string RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider. 
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs 
                    //to include the private key information.
                    //RSA.ImportParameters(RSAKeyInfo);
                    RSA.FromXmlString(RSAKeyInfo);
                    //Decrypt the passed byte array and specify OAEP padding.   
                    //OAEP padding is only available on Microsoft Windows XP or 
                    //later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException   
            //to the console. 
            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());

                return null;
            }

        }
        #endregion
    }

    [Serializable]
    class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Teacher { get; set; }
    }
}
