using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Utility.Extensions
{
    static public partial class Extensions
    {
        /// <summary>
        /// 对action进行for循环count次
        /// </summary>
        /// <param name="count">循环次数</param>
        /// <param name="action">目标函数</param>
        static public void ForEach(this int count, Action<int> action)
        {
            for(int i=0;i<count;++i)
            {
                action(i);
            }
        }
    }
}
