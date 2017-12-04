using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Framework
{
    /// <summary>
    /// 时间帮助工具
    /// </summary>
    public class TimeHelper
    {
        /// <summary>
        /// INT时间转换成DateTime
        /// </summary>
        /// <param name="time">yyyyMMdd或yyyy-MM-dd</param>
        /// <returns></returns>
        public static DateTime ConverTimeByString(string time)
        {
            string stime = time;
            if (stime.IndexOf("-") == -1)
            {
                stime = stime.Insert(4, "-").Insert(7, "-");
            }

            DateTime ctime = DateTime.Parse(stime);

            return ctime;
        }


    }
}
