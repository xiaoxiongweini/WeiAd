using DN.Framework.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DN.WeiAd.Business
{
    /// <summary>
    /// 通用数据
    /// </summary>
    public class CommonBLL
    {
        /// <summary>
        /// 获取当前天的小时列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetHourTable(int hour = 0)
        {
            List<string> list = new List<string>();

            int max = int.Parse(DateTime.Now.ToString("HH"));
            if(hour!=0)
            {
                max = hour;
            }

            for (int i = 0; i < max; i++)
            {
                list.Add(i.ToString().PadLeft(2, '0'));
            }

            return list;
        }

        /// <summary>
        /// 获取月中天
        /// </summary>
        /// <param name="month">年月份，如：201702，代表2017年2月</param>
        /// <returns></returns>
        public static List<string> GetDayTable(int month = 0)
        {
            List<string> list = new List<string>();

            DateTime time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM") + "-01");
            DateTime maxday = DateTime.Now;
            if (month != 0)
            {
                time = Convert.ToDateTime(month.ToString().Insert(4, "-") + "-01");
                maxday = time.AddMonths(1).AddDays(-1);
            }

            int max = int.Parse(maxday.ToString("dd"));
            for (int i = 0; i < max; i++)
            {
                list.Add(time.AddDays(i).ToString("yyyyMMdd"));
            }

            return list;
        }

        static List<TypeItem> platform_list = new List<TypeItem>();

        /// <summary>
        /// 系统定义的平台类型
        /// </summary>
        /// <returns></returns>
        public static List<TypeItem> GetPlatform()
        {
            if (platform_list.Count == 0)
            {
                platform_list = ConfigJsonHelper.GetTypes("PlatformType");
            }

            //list.Add(new TypeItem() { Name = "不限", Id = 0 });
            //list.Add(new TypeItem() { Name = "APP平台", Id = 1 });
            //list.Add(new TypeItem() { Name = "微信平台", Id = 2 });

            return platform_list;
        }
    }
}
