using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Razor
{
    public sealed class StringHelper
    {
        #region 汉字与拼音
        public class ChsToPY
        {
            // Fields
            private static int[] pyCodeList = new int[] { 
        -20319, -20317, -20304, -20295, -20292, -20283, -20265, -20257, -20242, -20230, -20051, -20036, -20032, -20026, -20002, -19990, 
        -19986, -19982, -19976, -19805, -19784, -19775, -19774, -19763, -19756, -19751, -19746, -19741, -19739, -19728, -19725, -19715, 
        -19540, -19531, -19525, -19515, -19500, -19484, -19479, -19467, -19289, -19288, -19281, -19275, -19270, -19263, -19261, -19249, 
        -19243, -19242, -19238, -19235, -19227, -19224, -19218, -19212, -19038, -19023, -19018, -19006, -19003, -18996, -18977, -18961, 
        -18952, -18783, -18774, -18773, -18763, -18756, -18741, -18735, -18731, -18722, -18710, -18697, -18696, -18526, -18518, -18501, 
        -18490, -18478, -18463, -18448, -18447, -18446, -18239, -18237, -18231, -18220, -18211, -18201, -18184, -18183, -18181, -18012, 
        -17997, -17988, -17970, -17964, -17961, -17950, -17947, -17931, -17928, -17922, -17759, -17752, -17733, -17730, -17721, -17703, 
        -17701, -17697, -17692, -17683, -17676, -17496, -17487, -17482, -17468, -17454, -17433, -17427, -17417, -17202, -17185, -16983, 
        -16970, -16942, -16915, -16733, -16708, -16706, -16689, -16664, -16657, -16647, -16474, -16470, -16465, -16459, -16452, -16448, 
        -16433, -16429, -16427, -16423, -16419, -16412, -16407, -16403, -16401, -16393, -16220, -16216, -16212, -16205, -16202, -16187, 
        -16180, -16171, -16169, -16158, -16155, -15959, -15958, -15944, -15933, -15920, -15915, -15903, -15889, -15878, -15707, -15701, 
        -15681, -15667, -15661, -15659, -15652, -15640, -15631, -15625, -15454, -15448, -15436, -15435, -15419, -15416, -15408, -15394, 
        -15385, -15377, -15375, -15369, -15363, -15362, -15183, -15180, -15165, -15158, -15153, -15150, -15149, -15144, -15143, -15141, 
        -15140, -15139, -15128, -15121, -15119, -15117, -15110, -15109, -14941, -14937, -14933, -14930, -14929, -14928, -14926, -14922, 
        -14921, -14914, -14908, -14902, -14894, -14889, -14882, -14873, -14871, -14857, -14678, -14674, -14670, -14668, -14663, -14654, 
        -14645, -14630, -14594, -14429, -14407, -14399, -14384, -14379, -14368, -14355, -14353, -14345, -14170, -14159, -14151, -14149, 
        -14145, -14140, -14137, -14135, -14125, -14123, -14122, -14112, -14109, -14099, -14097, -14094, -14092, -14090, -14087, -14083, 
        -13917, -13914, -13910, -13907, -13906, -13905, -13896, -13894, -13878, -13870, -13859, -13847, -13831, -13658, -13611, -13601, 
        -13406, -13404, -13400, -13398, -13395, -13391, -13387, -13383, -13367, -13359, -13356, -13343, -13340, -13329, -13326, -13318, 
        -13147, -13138, -13120, -13107, -13096, -13095, -13091, -13076, -13068, -13063, -13060, -12888, -12875, -12871, -12860, -12858, 
        -12852, -12849, -12838, -12831, -12829, -12812, -12802, -12607, -12597, -12594, -12585, -12556, -12359, -12346, -12320, -12300, 
        -12120, -12099, -12089, -12074, -12067, -12058, -12039, -11867, -11861, -11847, -11831, -11798, -11781, -11604, -11589, -11536, 
        -11358, -11340, -11339, -11324, -11303, -11097, -11077, -11067, -11055, -11052, -11045, -11041, -11038, -11024, -11020, -11019, 
        -11018, -11014, -10838, -10832, -10815, -10800, -10790, -10780, -10764, -10587, -10544, -10533, -10519, -10331, -10329, -10328, 
        -10322, -10315, -10309, -10307, -10296, -10281, -10274, -10270, -10262, -10260, -10256, -10254
     };
            private static string[] pyList = new string[] { 
        "a", "ai", "an", "ang", "ao", "ba", "bai", "ban", "bang", "bao", "bei", "ben", "beng", "bi", "bian", "biao", 
        "bie", "bin", "bing", "bo", "bu", "ca", "cai", "can", "cang", "cao", "ce", "ceng", "cha", "chai", "chan", "chang", 
        "chao", "che", "chen", "cheng", "chi", "chong", "chou", "chu", "chuai", "chuan", "chuang", "chui", "chun", "chuo", "ci", "cong", 
        "cou", "cu", "cuan", "cui", "cun", "cuo", "da", "dai", "dan", "dang", "dao", "de", "deng", "di", "dian", "diao", 
        "die", "ding", "diu", "dong", "dou", "du", "duan", "dui", "dun", "duo", "e", "en", "er", "fa", "fan", "fang", 
        "fei", "fen", "feng", "fo", "fou", "fu", "ga", "gai", "gan", "gang", "gao", "ge", "gei", "gen", "geng", "gong", 
        "gou", "gu", "gua", "guai", "guan", "guang", "gui", "gun", "guo", "ha", "hai", "han", "hang", "hao", "he", "hei", 
        "hen", "heng", "hong", "hou", "hu", "hua", "huai", "huan", "huang", "hui", "hun", "huo", "ji", "jia", "jian", "jiang", 
        "jiao", "jie", "jin", "jing", "jiong", "jiu", "ju", "juan", "jue", "jun", "ka", "kai", "kan", "kang", "kao", "ke", 
        "ken", "keng", "kong", "kou", "ku", "kua", "kuai", "kuan", "kuang", "kui", "kun", "kuo", "la", "lai", "lan", "lang", 
        "lao", "le", "lei", "leng", "li", "lia", "lian", "liang", "liao", "lie", "lin", "ling", "liu", "long", "lou", "lu", 
        "lv", "luan", "lue", "lun", "luo", "ma", "mai", "man", "mang", "mao", "me", "mei", "men", "meng", "mi", "mian", 
        "miao", "mie", "min", "ming", "miu", "mo", "mou", "mu", "na", "nai", "nan", "nang", "nao", "ne", "nei", "nen", 
        "neng", "ni", "nian", "niang", "niao", "nie", "nin", "ning", "niu", "nong", "nu", "nv", "nuan", "nue", "nuo", "o", 
        "ou", "pa", "pai", "pan", "pang", "pao", "pei", "pen", "peng", "pi", "pian", "piao", "pie", "pin", "ping", "po", 
        "pu", "qi", "qia", "qian", "qiang", "qiao", "qie", "qin", "qing", "qiong", "qiu", "qu", "quan", "que", "qun", "ran", 
        "rang", "rao", "re", "ren", "reng", "ri", "rong", "rou", "ru", "ruan", "rui", "run", "ruo", "sa", "sai", "san", 
        "sang", "sao", "se", "sen", "seng", "sha", "shai", "shan", "shang", "shao", "she", "shen", "sheng", "shi", "shou", "shu", 
        "shua", "shuai", "shuan", "shuang", "shui", "shun", "shuo", "si", "song", "sou", "su", "suan", "sui", "sun", "suo", "ta", 
        "tai", "tan", "tang", "tao", "te", "teng", "ti", "tian", "tiao", "tie", "ting", "tong", "tou", "tu", "tuan", "tui", 
        "tun", "tuo", "wa", "wai", "wan", "wang", "wei", "wen", "weng", "wo", "wu", "xi", "xia", "xian", "xiang", "xiao", 
        "xie", "xin", "xing", "xiong", "xiu", "xu", "xuan", "xue", "xun", "ya", "yan", "yang", "yao", "ye", "yi", "yin", 
        "ying", "yo", "yong", "you", "yu", "yuan", "yue", "yun", "za", "zai", "zan", "zang", "zao", "ze", "zei", "zen", 
        "zeng", "zha", "zhai", "zhan", "zhang", "zhao", "zhe", "zhen", "zheng", "zhi", "zhong", "zhou", "zhu", "zhua", "zhuai", "zhuan", 
        "zhuang", "zhui", "zhun", "zhuo", "zi", "zong", "zou", "zu", "zuan", "zui", "zun", "zuo"
     };

            /// <summary>
            /// 转换成汉字拼音
            /// </summary>
            /// <param name="hz"></param>
            /// <returns></returns>
            public static string Convert(string input)
            {
                byte[] bytes = new byte[2];
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                char[] chArray = input.ToCharArray();
                StringBuilder builder = new StringBuilder(chArray.Length);
                for (int i = 0; i < chArray.Length; i++)
                {
                    if (!Regex.IsMatch(chArray[i].ToString(), @"\W"))
                    {
                        if (Regex.IsMatch(chArray[i].ToString(), "[a-zA-Z0-9_]"))
                        {
                            builder.Append(chArray[i].ToString());
                        }
                        else
                        {
                            bytes = Encoding.GetEncoding("gb2312").GetBytes(chArray[i].ToString());
                            num2 = bytes[0];
                            num3 = bytes[1];
                            num = ((num2 * 0x100) + num3) - 0x10000;
                            if ((num > 0) && (num < 160))
                            {
                                builder.Append(chArray[i].ToString());
                            }
                            else if (num <= -10247)
                            {
                                int length = pyCodeList.Length;
                                while (--length >= 0)
                                {
                                    if (pyCodeList[length] <= num)
                                    {
                                        builder.Append(ToTitleCase(pyList[length].ToString()));
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                return builder.ToString();
            }


            public static string GetCode(string hz)
            {
                byte[] bytes = new byte[2];
                int num = 0;
                int num2 = 0;
                int num3 = 0;
                bytes = Encoding.GetEncoding("gb2312").GetBytes(hz);
                num2 = bytes[0];
                num3 = bytes[1];
                num = ((num2 * 0x100) + num3) - 0x10000;
                return num.ToString();
            }

            /// <summary>
            /// 转换成汉字拼音首字母(大写)
            /// </summary>
            /// <param name="hz"></param>
            /// <returns></returns>
            public static string GetFirstPYChar(string hz)
            {
                if (string.IsNullOrEmpty(hz))
                {
                    throw new Exception("未将字符串实例化或为空字符串!");
                }
                string hazi = Convert(hz).Trim();
                return hazi.Substring(0, 1);
            }

            public static string ToTitleCase(string input)
            {
                if (input.Length < 1)
                {
                    return input;
                }
                if (Regex.IsMatch(input, "^[A-Z]+$"))
                {
                    return input;
                }
                input = input.ToLower();
                char ch = input[0];
                return (ch.ToString().ToUpper() + input.Substring(1));
            }

        }
        /// <summary>
        /// 汉字域
        /// </summary>
        /// <param name="pinyinIndex"></param>
        /// <returns></returns>
        public static string[,] GetHanziScope(string pinyinIndex)
        {
            pinyinIndex = pinyinIndex.ToLower();
            string[,] array = new string[pinyinIndex.Length, 2];
            for (int i = 0; i < pinyinIndex.Length; i++)
            {
                string text = pinyinIndex.Substring(i, 1);
                if (text == "a")
                {
                    array[i, 0] = "吖";
                    array[i, 1] = "驁";
                }
                else
                {
                    if (text == "b")
                    {
                        array[i, 0] = "八";
                        array[i, 1] = "簿";
                    }
                    else
                    {
                        if (text == "c")
                        {
                            array[i, 0] = "嚓";
                            array[i, 1] = "錯";
                        }
                        else
                        {
                            if (text == "d")
                            {
                                array[i, 0] = "咑";
                                array[i, 1] = "鵽";
                            }
                            else
                            {
                                if (text == "e")
                                {
                                    array[i, 0] = "妸";
                                    array[i, 1] = "樲";
                                }
                                else
                                {
                                    if (text == "f")
                                    {
                                        array[i, 0] = "发";
                                        array[i, 1] = "猤";
                                    }
                                    else
                                    {
                                        if (text == "g")
                                        {
                                            array[i, 0] = "旮";
                                            array[i, 1] = "腂";
                                        }
                                        else
                                        {
                                            if (text == "h")
                                            {
                                                array[i, 0] = "妎";
                                                array[i, 1] = "夻";
                                            }
                                            else
                                            {
                                                if (text == "j")
                                                {
                                                    array[i, 0] = "丌";
                                                    array[i, 1] = "攈";
                                                }
                                                else
                                                {
                                                    if (text == "k")
                                                    {
                                                        array[i, 0] = "咔";
                                                        array[i, 1] = "穒";
                                                    }
                                                    else
                                                    {
                                                        if (text == "l")
                                                        {
                                                            array[i, 0] = "垃";
                                                            array[i, 1] = "鱳";
                                                        }
                                                        else
                                                        {
                                                            if (text == "m")
                                                            {
                                                                array[i, 0] = "嘸";
                                                                array[i, 1] = "椧";
                                                            }
                                                            else
                                                            {
                                                                if (text == "n")
                                                                {
                                                                    array[i, 0] = "拏";
                                                                    array[i, 1] = "桛";
                                                                }
                                                                else
                                                                {
                                                                    if (text == "o")
                                                                    {
                                                                        array[i, 0] = "噢";
                                                                        array[i, 1] = "漚";
                                                                    }
                                                                    else
                                                                    {
                                                                        if (text == "p")
                                                                        {
                                                                            array[i, 0] = "妑";
                                                                            array[i, 1] = "曝";
                                                                        }
                                                                        else
                                                                        {
                                                                            if (text == "q")
                                                                            {
                                                                                array[i, 0] = "七";
                                                                                array[i, 1] = "裠";
                                                                            }
                                                                            else
                                                                            {
                                                                                if (text == "r")
                                                                                {
                                                                                    array[i, 0] = "亽";
                                                                                    array[i, 1] = "鶸";
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (text == "s")
                                                                                    {
                                                                                        array[i, 0] = "仨";
                                                                                        array[i, 1] = "蜶";
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (text == "t")
                                                                                        {
                                                                                            array[i, 0] = "他";
                                                                                            array[i, 1] = "籜";
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (text == "w")
                                                                                            {
                                                                                                array[i, 0] = "屲";
                                                                                                array[i, 1] = "鶩";
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (text == "x")
                                                                                                {
                                                                                                    array[i, 0] = "夕";
                                                                                                    array[i, 1] = "鑂";
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (text == "y")
                                                                                                    {
                                                                                                        array[i, 0] = "丫";
                                                                                                        array[i, 1] = "韻";
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (text == "z")
                                                                                                        {
                                                                                                            array[i, 0] = "帀";
                                                                                                            array[i, 1] = "咗";
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            array[i, 0] = text;
                                                                                                            array[i, 1] = text;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return array;
        }
        #endregion

        /// <summary>
        /// 包裹字符串
        /// </summary>
        /// <param name="tmplstr">目标字符串</param>
        /// <param name="beginWrapper">开始</param>
        /// <param name="endWrapper">结尾</param>
        public static string Wrap(string tmplstr, string beginWrapper, string endWrapper)
        {
            return string.Format("{0}{1}{2}", beginWrapper, tmplstr, endWrapper);
        }

        /// <summary>
        /// 数组转字符串并指定字符分割
        /// </summary>
        /// <param name="objenum">IEnumerable类型变量</param>
        /// <param name="divChar">要插入的字符</param>
        public static string Join(IEnumerable objenum, char divChar)
        {
            string str = string.Empty;
            foreach (object obj2 in objenum)
            {
                if (!((obj2 == null) || string.IsNullOrEmpty(obj2.ToString().Trim())))
                {
                    str = str + string.Format("{0}{1}", obj2.ToString(), divChar);
                }
            }
            return str.TrimEnd(new char[] { divChar });
        }

        public static string Join(IEnumerable objenum)
        {
            return Join(objenum, ',');
        }

        /// <summary>
        /// 数组转字符串并指定字符分割包裹
        /// </summary>
        /// <param name="objenum">IEnumerable变量</param>
        /// <param name="divChar">分割字符</param>
        /// <param name="leftquota">左包裹字符串</param>
        /// <param name="rightquota">又包裹字符串</param>
        public static string JoinAndQuota(IEnumerable objenum, char divChar, string leftquota, string rightquota)
        {
            string str = string.Empty;
            foreach (object obj2 in objenum)
            {
                if (!((obj2 == null) || string.IsNullOrEmpty(obj2.ToString().Trim())))
                {
                    str = str + string.Format("{0}{1}{2}{3}", new object[] { leftquota, obj2.ToString(), rightquota, divChar });
                }
            }
            return str.TrimEnd(new char[] { divChar });
        }

        /// <summary>
        /// 默认以逗号分割进行包裹
        /// </summary>
        public static string JoinAndQuota(IEnumerable objenum, string leftquota, string rightquota)
        {
            return JoinAndQuota(objenum, ',', leftquota, rightquota);
        }

        /// <summary>
        /// JoinAndQuota方法的双引号包裹形式.
        /// </summary>
        public static string JoinAndDblQuota(IEnumerable objenum, char divChar)
        {
            return JoinAndQuota(objenum, divChar, "\"", "\"");
        }

        /// <summary>
        /// JoinAndQuota方法的SQL字符串包裹形式,常用于SQL中的IN.
        /// </summary>
        public static string JoinAndSQLQuota(IEnumerable objenum)
        {
            return JoinAndQuota(objenum, ',', "'", "'");
        }

        /// <summary>
        /// 将汉字装换成拼音
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ConvertChineseToPY(string input)
        {
            return ChsToPY.Convert(input);
        }

        /// <summary>
        /// 查看数组中是否包含指定的字符串
        /// </summary>
        public static bool Contains(IEnumerable objenum, string val, bool ignoreCase)
        {
            foreach (object obj2 in objenum)
            {
                if (string.Compare(obj2.ToString(), val, ignoreCase) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 查看数组中是否包含指定的字符串,忽略大小写
        /// </summary>
        public static bool Contains(IEnumerable objenum, string val)
        {
            return Contains(objenum, val, true);
        }

        /// <summary>
        /// 获取字节长度
        /// </summary>
        public static int ByteLen(string str)
        {
            char[] chArray = str.ToCharArray();
            int num = 0;
            for (int i = 0; i < chArray.Length; i++)
            {
                if (chArray[i] > 'Ā')
                {
                    num += 2;
                }
                else
                {
                    num++;
                }
            }
            return num;
        }

        #region Base64编码
        /// <summary>
        /// Base64转码
        /// </summary>
        /// <param name="encode"></param>
        /// <param name="source"></param>
        public static string EncodeBase64(Encoding encode, string source)
        {
            byte[] bytes = encode.GetBytes(source);
            try
            {
                return Convert.ToBase64String(bytes);
            }
            catch (Exception exception)
            {
                throw new Exception("Have error on EncodeBase64\n" + exception.Message);
            }
        }

        /// <summary>
        /// Base64转码(UTF8)
        /// </summary>
        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64 解码
        /// </summary>
        public static string DecodeBase64(Encoding encode, string result)
        {
            byte[] bytes = Convert.FromBase64String(result);
            try
            {
                return encode.GetString(bytes);
            }
            catch (Exception exception)
            {
                throw new Exception("Have error on DecodeBase64\n" + exception.Message);
            }
        }

        /// <summary>
        /// Base64(UTF8)解码
        /// </summary>
        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
        #endregion

        #region 中文数值转换

        private static char NtcToNum(char x)
        {
            string str = "零一二三四五六七八九";
            string str2 = "0123456789";
            return str[str2.IndexOf(x)];
        }

        private static string NtcChangeInt(string x)
        {
            string[] strArray = new string[] { "", "十", "百", "千" };
            string str = "";
            int startIndex = x.Length - 1;
            while (startIndex >= 0)
            {
                if (x[startIndex] == '0')
                {
                    str = NtcToNum(x[startIndex]) + str;
                }
                else
                {
                    str = NtcToNum(x[startIndex]) + strArray[(x.Length - 1) - startIndex] + str;
                }
                startIndex--;
            }
            while ((startIndex = str.IndexOf("零零")) != -1)
            {
                str = str.Remove(startIndex, 1);
            }
            if ((str[str.Length - 1] == 0x96f6) && (str.Length > 1))
            {
                str = str.Remove(str.Length - 1, 1);
            }
            if ((str.Length >= 2) && (str.Substring(0, 2) == "一十"))
            {
                str = str.Remove(0, 1);
            }
            return str;
        }

        private static string NtcToInt(string x)
        {
            string str;
            int length = x.Length;
            if (length <= 4)
            {
                str = NtcChangeInt(x);
            }
            else
            {
                string str2;
                if (length <= 8)
                {
                    str = NtcChangeInt(x.Substring(0, length - 4)) + "万";
                    str2 = NtcChangeInt(x.Substring(length - 4, 4));
                    if ((str2.IndexOf("千") == -1) && (str2 != ""))
                    {
                        str = str + "零" + str2;
                    }
                    else
                    {
                        str = str + str2;
                    }
                }
                else
                {
                    str = NtcChangeInt(x.Substring(0, length - 8)) + "亿";
                    str2 = NtcChangeInt(x.Substring(length - 8, 4));
                    if ((str2.IndexOf("千") == -1) && (str2 != ""))
                    {
                        str = str + "零" + str2;
                    }
                    else
                    {
                        str = str + str2;
                    }
                    str = str + "万";
                    str2 = NtcChangeInt(x.Substring(length - 4, 4));
                    if ((str2.IndexOf("千") == -1) && (str2 != ""))
                    {
                        str = str + "零" + str2;
                    }
                    else
                    {
                        str = str + str2;
                    }
                }
            }
            int index = str.IndexOf("零万");
            if (index != -1)
            {
                str = str.Remove(index + 1, 1);
            }
            while ((index = str.IndexOf("零零")) != -1)
            {
                str = str.Remove(index, 1);
            }
            if ((str[str.Length - 1] == 0x96f6) && (str.Length > 1))
            {
                str = str.Remove(str.Length - 1, 1);
            }
            return str;
        }
        private static string NtcToDecimal(string x)
        {
            string str = "";
            for (int i = 0; i < x.Length; i++)
            {
                str = str + NtcToNum(x[i]);
            }
            return str;
        }

        public static string NumberToChina(string x)
        {
            if (x.Length == 0)
            {
                return "";
            }
            string str = "";
            if (x[0] == '-')
            {
                str = "负";
                x = x.Remove(0, 1);
            }
            char ch = x[0];
            if (ch.ToString() == ".")
            {
                x = "0" + x;
            }
            ch = x[x.Length - 1];
            if (ch.ToString() == ".")
            {
                x = x.Remove(x.Length - 1, 1);
            }
            if (x.IndexOf(".") > -1)
            {
                str = str + NtcToInt(x.Substring(0, x.IndexOf("."))) + "点" + NtcToDecimal(x.Substring(x.IndexOf(".") + 1));
            }
            else
            {
                str = str + NtcToInt(x);
            }
            return str;
        }

        /// <summary>
        /// 日期装换成汉字(yyyy-MM-dd) 
        /// </summary>
        public static string DateToHanzi(string date)
        {
            string[] strArray = date.Split(new char[] { '-' });
            return (NumberToChina(strArray[0]) + "年" + NumberToChina(strArray[1]) + "月" + NumberToChina(strArray[2]) + "日");
        }

        public static string DateToHanzi(DateTime dt)
        {
            return DateToHanzi(dt.ToString("yyyy-MM-dd"));
        }
        #endregion

    }
}
