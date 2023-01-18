using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.Extensions
{
    static public partial class Extension
    {
        static public string RandDictionary 
            => "abcdefghijklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// 生成随机字典随机长度字符串
        /// </summary>
        /// <param name="random">使用的随机变量</param>
        /// <param name="length">长度</param>
        /// <param name="dict">字典</param>
        /// <returns>随机字符串</returns>
        static public string RandString(this Random random, int length, string? dict=null) 
        {
            if(dict is null) dict = RandDictionary;
            var builder = new StringBuilder();
            for (int i = 0; i < length; ++i) builder.Append(dict[random.Next(dict.Length)]);
            return builder.ToString();
        }

        /// <summary>
        /// 生成指定长度的随机数字串
        /// </summary>
        /// <param name="random">使用的随机变量</param>
        /// <param name="length">长度</param>
        /// <returns>随机字符串</returns>
        static public string RandDigit(this Random random, int length) 
            => RandString(random, length, "0123456789");

        /// <summary>
        /// 生成指定长度的随机小写字母串
        /// </summary>
        /// <param name="random">使用的随机变量</param>
        /// <param name="length">长度</param>
        /// <returns>随机字符串</returns>
        static public string RandLower(this Random random, int length)
            => RandString(random, length, "qwertyuiopasdfghjklzxcvbnm");

        /// <summary>
        /// 生成指定长度的随机大写字母串
        /// </summary>
        /// <param name="random">使用的随机变量</param>
        /// <param name="length">长度</param>
        /// <returns>随机字符串</returns>
        static public string RandUpper(this Random random, int length)
            => RandString(random, length, "QWERTYUIOPASADFGHJKLZXCVBNM");

    }
}
