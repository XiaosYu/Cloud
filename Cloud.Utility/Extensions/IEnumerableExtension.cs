using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.Extensions
{
    static public partial class Extension
    {
        /// <summary>
        /// 对所有的元素运行action函数
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="values">迭代源</param>
        /// <param name="action">方法</param>
        static public void Foreach<T>(this IEnumerable<T> values, Action<T> action)
        {
            foreach (var item in values) 
            {
                action(item);
            }
        }

        /// <summary>
        /// 将迭代数组中的字符串合成一个字符串
        /// </summary>
        /// <param name="values">源字符串</param>
        /// <param name="split">分解符号</param>
        /// <returns>合成的字符串</returns>
        static public string Synthesize(this IEnumerable<string> values, string split) 
        {
            var builder = new StringBuilder();
            foreach (var item in values) 
            {
                builder.Append(item);
                builder.Append(split);
            }
            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }

        /// <summary>
        /// 在sources中随机选择一个元素
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="sources">待选择集合</param>
        /// <returns>随机选择的元素</returns>
        static public T? RandomSelect<T>(this IEnumerable<T> sources)
            => sources.OrderBy(s => new Guid()).FirstOrDefault();

        /// <summary>
        /// 在sources中随机排序
        /// </summary>
        /// <typeparam name="T">元素类型</typeparam>
        /// <param name="sources">待随机排序的元素集合</param>
        /// <returns>随机排序后的元素集合</returns>
        static public IEnumerable<T> RandomOrdryBy<T>(this IEnumerable<T> sources)
            => sources.OrderBy(s => new Guid());
    }
}
