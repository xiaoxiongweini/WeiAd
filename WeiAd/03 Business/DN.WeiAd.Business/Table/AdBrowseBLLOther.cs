using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;

namespace DN.WeiAd.Business
{
    public partial class AdBrowseBLL
    {
        /// <summary>
        /// 数据同步迁移
        /// </summary>
        /// <param name="time">默认是当前时间的前一天，格式：yyyyMMdd</param>
        public void Synchronization(int time = 0)
        {
            if(time == 0)
            {
                time = int.Parse(DateTime.Now.AddDays(-1).ToString("yyyyMMdd"));
            }

            AdBrowsePara ap = new AdBrowsePara();
            ap.IsNotDay = true;
            ap.PageSize = 1000;
            ap.PageIndex = 0;
            
            List<AdBrowseVO> list = new List<AdBrowseVO>();
            list = AdBrowseBLL.Instance.GetModels(ref ap);
            while (list.Count != 0)
            {
                List<int> ids = new List<int>();

                foreach (var item in list)
                {
                    AdBrowseHistoryVO info = new AdBrowseHistoryVO();
                    info.AdId = item.AdId;
                    info.AdUrl = item.AdUrl;
                    info.BrowseType = item.BrowseType;
                    info.ClientIp = item.ClientIp;
                    info.CreateDate = item.CreateDate;
                    info.IsMoney = item.IsMoney;
                    info.Money = item.Money;
                    info.Time = item.Time;
                    info.Url = item.Url;
                    info.AdUserId = item.AdUserId;

                    
                    AdBrowseHistoryBLL.Instance.Add(info);
                    ids.Add(item.Id);
                    //删除数据
                    //AdBrowseBLL.Instance.Delete(new AdBrowsePara() { Id = item.Id });
                }

                AdBrowseBLL.Instance.Delete(new AdBrowsePara() { Ids = ids });

                list = AdBrowseBLL.Instance.GetModels(ref ap);
            }
        }
    }
}
