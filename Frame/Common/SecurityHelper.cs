using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Razor
{
    public class SecurityHelper
    {
        #region CBC模式**

        /// <summary>
        /// DES3 CBC模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeCBC(byte[] key, byte[] iv, byte[] data)
        {

            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();
                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();

                tdsp.Mode = CipherMode.CBC;             //默认值
                tdsp.Padding = PaddingMode.PKCS7;       //默认值

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream, tdsp.CreateEncryptor(key, iv),
                    CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.
                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();

                // Return the encrypted buffer.
                return ret;

            }
            catch (CryptographicException e)
            {
                throw new Exception(string.Format("A Cryptographic error occurred: {0}", e.Message));
            }
        }


        /// <summary>
        /// DES3 CBC模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV</param>
        /// <param name="data">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeCBC(byte[] key, byte[] iv, byte[] data)
        {

            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);
                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.CBC;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).

                CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                    tdsp.CreateDecryptor(key, iv), CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);
                //Convert the buffer into a string and return it.
                return fromEncrypt;

            }
            catch (CryptographicException e)
            {
                throw new Exception(string.Format("A Cryptographic error occurred: {0}", e.Message));
            }
        }


        #endregion


        #region ECB模式

        /// <summary>
        /// DES3 ECB模式加密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">明文的byte数组</param>
        /// <returns>密文的byte数组</returns>
        public static byte[] Des3EncodeECB(byte[] key, byte[] iv, byte[] data)
        {

            try
            {
                // Create a MemoryStream.
                MemoryStream mStream = new MemoryStream();
                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream cStream = new CryptoStream(mStream,
                    tdsp.CreateEncryptor(key, iv), CryptoStreamMode.Write);

                // Write the byte array to the crypto stream and flush it.
                cStream.Write(data, 0, data.Length);
                cStream.FlushFinalBlock();

                // Get an array of bytes from the 
                // MemoryStream that holds the 
                // encrypted data.

                byte[] ret = mStream.ToArray();

                // Close the streams.
                cStream.Close();
                mStream.Close();
                // Return the encrypted buffer.

                return ret;
            }
            catch (CryptographicException e)
            {
                throw new Exception(string.Format("A Cryptographic error occurred: {0}", e.Message));
            }
        }

        /// <summary>
        /// DES3 ECB模式解密
        /// </summary>
        /// <param name="key">密钥</param>
        /// <param name="iv">IV(当模式为ECB时，IV无用)</param>
        /// <param name="str">密文的byte数组</param>
        /// <returns>明文的byte数组</returns>
        public static byte[] Des3DecodeECB(byte[] key, byte[] iv, byte[] data)
        {
            try
            {
                // Create a new MemoryStream using the passed 
                // array of encrypted data.
                MemoryStream msDecrypt = new MemoryStream(data);

                TripleDESCryptoServiceProvider tdsp = new TripleDESCryptoServiceProvider();
                tdsp.Mode = CipherMode.ECB;
                tdsp.Padding = PaddingMode.PKCS7;

                // Create a CryptoStream using the MemoryStream 
                // and the passed key and initialization vector (IV).
                CryptoStream csDecrypt = new CryptoStream(msDecrypt,

                    tdsp.CreateDecryptor(key, iv), CryptoStreamMode.Read);

                // Create buffer to hold the decrypted data.
                byte[] fromEncrypt = new byte[data.Length];

                // Read the decrypted data out of the crypto stream
                // and place it into the temporary buffer.
                csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

                //Convert the buffer into a string and return it.
                return fromEncrypt;
            }
            catch (CryptographicException e)
            {
                throw new Exception(string.Format("A Cryptographic error occurred: {0}", e.Message));
            }
        }
        #endregion


        /// <summary>
        /// md5 加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String MD5Encrypt(String s)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                strb.Append(Convert.ToString(bytes[i], 16).PadLeft(2, '0'));
            }
            return strb.ToString().PadLeft(32, '0');
        }

        /// <summary>
        /// md5 加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String MD5Encrypt1(String s)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            StringBuilder strb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                strb.Append(bytes[i].ToString("x"));
            }
            return strb.ToString();
        }


        /// <summary>
        /// 加密(UTF8)
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string Des3EncrypStr(string str)
        {
            byte[] bt = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] key = Convert.FromBase64String("jLj7893JLKpifjklUJpoj8093jkJLjp4");
            byte[] iv = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };

            byte[] eBts = Des3EncodeECB(key, iv, bt);
            return Convert.ToBase64String(eBts);
        }

        /// <summary>
        /// 加密(UTF8),网页传参密文中出现"+"要处理 
        /// </summary>
        /// <returns></returns>
        public static string Des3EncrypStrForHtml(string str)
        {
            return Des3EncrypStr(str).Replace("+", "%2B");
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string Des3DecryptStr(string str)
        {
            byte[] bt = Convert.FromBase64String(str);
            byte[] key = Convert.FromBase64String("jLj7893JLKpifjklUJpoj8093jkJLjp4");
            byte[] iv = new byte[] { };

            byte[] bts = Des3DecodeECB(key, null, bt);
            return Encoding.UTF8.GetString(bts).Trim();
        }

        /// <summary>
        /// 加密文件
        /// </summary>
        /// <param name="filePath">要加密的文件</param>
        /// <param name="outPath">输出路径</param>
        public static void EncryptFile(string filePath, string outPath)
        {
            //Check argument
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("没有找到指定的文件");
            }

            byte[] key = Convert.FromBase64String("jLj7893JLKpifjklUJpoj8093jkJLjp4");
            byte[] iv = Encoding.UTF8.GetBytes("qwertyuiopasdfgh");

            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                FileStream fs = File.OpenRead(filePath);
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
                fs.Close();

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        csEncrypt.Write(buffer, 0, buffer.Length);
                        csEncrypt.FlushFinalBlock();

                        byte[] encrypted = msEncrypt.ToArray();
                        using (FileStream stream2 = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                        {
                            stream2.Write(encrypted, 0, encrypted.Length);
                            stream2.Flush();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="filePath">要解密的文件</param>
        /// <param name="outPath">输出路径</param>
        public static void DencryptFile(string filePath, string outPath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("没有找到指定的文件");
            }
            byte[] key = Convert.FromBase64String("jLj7893JLKpifjklUJpoj8093jkJLjp4");
            byte[] iv = Encoding.UTF8.GetBytes("qwertyuiopasdfgh");

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                FileStream fs = File.OpenRead(filePath);
                // Create the streams used for decryption.
                using (CryptoStream csDecrypt = new CryptoStream(fs, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        string plaintext = srDecrypt.ReadToEnd();
                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        byte[] decData = Encoding.UTF8.GetBytes(plaintext);
                        using (FileStream stream2 = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                        {
                            stream2.Write(decData, 0, decData.Length);
                            stream2.Flush();
                            fs.Close();
                        }
                    }
                }
            }
        }

        #region RSA加密

        /// <summary>
        /// 生成RSA密钥对,xml形式返回
        /// </summary>
        /// <param name="privateKey">私钥</param>
        /// <param name="publicKey">公钥</param>
        /// <returns>是否成功</returns>
        public static bool CreateRSAPairKey(out string privateKey, out string publicKey)
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(1024);
            privateKey = RSA.ToXmlString(true);
            publicKey = RSA.ToXmlString(true);
            return true;
        }

        static public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] encryptedData;
                //Create a new instance of RSACryptoServiceProvider. 
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {

                    //Import the RSA Key information. This only needs 
                    //toinclude the public key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Encrypt the passed byte array and specify OAEP padding.   
                    //OAEP padding is only available on Microsoft Windows XP or later.  
                    encryptedData = RSA.Encrypt(DataToEncrypt, DoOAEPPadding);
                }
                return encryptedData;
            }
            //Catch and display a CryptographicException   
            //to the console. 
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        static public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                byte[] decryptedData;
                //Create a new instance of RSACryptoServiceProvider. 
                using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                {
                    //Import the RSA Key information. This needs 
                    //to include the private key information.
                    RSA.ImportParameters(RSAKeyInfo);

                    //Decrypt the passed byte array and specify OAEP padding.   
                    //OAEP padding is only available on Microsoft Windows XP or later.  
                    decryptedData = RSA.Decrypt(DataToDecrypt, DoOAEPPadding);
                }
                return decryptedData;
            }
            //Catch and display a CryptographicException   
            //to the console. 
            catch (CryptographicException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// RSA加密(UTF-16)
        /// </summary>
        /// <param name="data">String</param>
        /// <param name="publicKey">公钥</param>
        /// <returns>加密后的字符串</returns>
        public static string RSAEcryptString(string data, string publicKey)
        {
            if (string.IsNullOrEmpty(publicKey))
            {
                throw new ArgumentException("请输入公钥!");
            }
            //Create a UnicodeEncoder to convert between byte array and string.
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes(data);
            byte[] encryptedData;
            //Create a new instance of RSACryptoServiceProvider to generate 
            //public and private key data. 
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKey);
                //Pass the data to ENCRYPT, the public key information  
                //(using RSACryptoServiceProvider.ExportParameters(false), 
                //and a boolean flag specifying no OAEP padding.
                encryptedData = RSAEncrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                return ByteConverter.GetString(encryptedData);
            }
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="p_inputString">需要加密的字符串</param>
        /// <param name="p_dwKeySize">密钥的大小</param>
        /// <param name="p_xmlString">包含密钥的XML文本信息</param>
        /// <returns>加密后的文本信息</returns>
        public static string RSAEncryptString(string p_inputString, int p_dwKeySize, string p_xmlString)
        {
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(p_dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(p_xmlString);
            int keySize = p_dwKeySize / 8;
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] bytes = ByteConverter.GetBytes(p_inputString);
            int maxLength = keySize - 42;
            int dataLength = bytes.Length;
            int iterations = dataLength / maxLength;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i <= iterations; i++)
            {
                byte[] tempBytes = new byte[(dataLength - maxLength * i > maxLength) ? maxLength : dataLength - maxLength * i];
                Buffer.BlockCopy(bytes, maxLength * i, tempBytes, 0, tempBytes.Length);
                byte[] encryptedBytes = rsaCryptoServiceProvider.Encrypt(tempBytes, true);
                // Array.Reverse(encryptedBytes);
                stringBuilder.Append(Convert.ToBase64String(encryptedBytes));
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="p_inputString">需要解密的字符串信息</param>
        /// <param name="p_dwKeySize">密钥的大小</param>
        /// <param name="p_xmlString">包含密钥的文本信息</param>
        /// <returns>解密后的文本信息</returns>
        public static string RSADecryptString(string inputString, int dwKeySize, string xmlString)
        {
            RSACryptoServiceProvider rsaCryptoServiceProvider = new RSACryptoServiceProvider(dwKeySize);
            rsaCryptoServiceProvider.FromXmlString(xmlString);
            int base64BlockSize = ((dwKeySize / 8) % 3 != 0) ? (((dwKeySize / 8) / 3) * 4) + 4 : ((dwKeySize / 8) / 3) * 4;
            int iterations = inputString.Length / base64BlockSize;
            List<byte> arrayList = new List<byte>();
            for (int i = 0; i < iterations; i++)
            {
                byte[] encryptedBytes = Convert.FromBase64String(inputString.Substring(base64BlockSize * i, base64BlockSize));
                //  Array.Reverse(encryptedBytes);
                arrayList.AddRange(rsaCryptoServiceProvider.Decrypt(encryptedBytes, true));
            }
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            return ByteConverter.GetString(arrayList.ToArray() as byte[]);
        }


        /// <summary>
        /// RSA解密(UTF-16)
        /// </summary>
        /// <param name="data">String</param>
        /// <param name="publicKey">私钥</param>
        /// <returns>解密后的字符串</returns>
        public static string RSADcryptString(string data, string privateKey)
        {
            if (string.IsNullOrEmpty(privateKey))
            {
                throw new ArgumentException("请输入私钥!");
            }
            //Create a UnicodeEncoder to convert between byte array and string.
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes(data);
            byte[] dencryptedData;
            //Create a new instance of RSACryptoServiceProvider to generate 
            //public and private key data. 
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKey);
                //Pass the data to ENCRYPT, the public key information  
                //(using RSACryptoServiceProvider.ExportParameters(false), 
                //and a boolean flag specifying no OAEP padding.
                dencryptedData = RSADecrypt(dataToEncrypt, RSA.ExportParameters(false), false);
                return ByteConverter.GetString(dencryptedData);
            }
        }
        #endregion
    }
}
