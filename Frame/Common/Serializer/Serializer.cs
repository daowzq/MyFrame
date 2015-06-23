using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Razor
{
    public class Serializer
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="str">Base64字符串</param>
        /// <returns></returns>
        public static object DeserializeFromBase64(string str)
        {
            return DeserializeFromBytes(Convert.FromBase64String(str));
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <param name="bytes">字节数组</param>
        /// <returns>Object对象</returns>
        public static object DeserializeFromBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream(bytes)
            {
                Position = 0L
            };
            return formatter.Deserialize(serializationStream);
        }

        /// <summary>
        /// 发序列化对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="bytes">直接数组</param>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] bytes)
        {
            object obj2 = DeserializeFromBytes(bytes);
            if (obj2 == null)
            {
                return default(T);
            }
            return (T)obj2;
        }

        /// <summary>
        /// 序列化对象为Base64字符串
        /// </summary>
        /// <param name="obj">Object对象</param>
        /// <returns>Base64字符串</returns>
        public static string SerializeToBase64(object obj)
        {
            return Convert.ToBase64String(SerializeToBytes(obj));
        }

        /// <summary>
        /// 序列化对象为
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns>字节数组</returns>
        public static byte[] SerializeToBytes(object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream();
            formatter.Serialize(serializationStream, obj);
            return serializationStream.ToArray();
        }
    }
}
