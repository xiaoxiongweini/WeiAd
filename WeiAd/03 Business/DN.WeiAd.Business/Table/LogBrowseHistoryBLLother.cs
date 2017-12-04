using DN.WeiAd.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DN.WeiAd.Models;
using System.Data;
using DN.WeiAd.Business;

namespace DN.WeiAd.Business
{
    public partial class LogBrowseHistoryBLL
    {
        static ChartInterface m_acc = null;

        /// <summary>
        /// 数据迁移功能
        /// </summary>
        /// <param name="time">时间</param>
        public void TransferDay(DateTime time)
        {
            if(time.ToString("yyyyMMdd") == DateTime.Now.ToString("yyyyMMdd"))
            {
                //如果是当前时间，不允许转入数据
                return;
            }

            string cmd = string.Format("insert into  LogBrowseHistory select [Url],[ClientIp],[BrowseType],[CreateDate],[AdId],[AdUserId],[FlowUserId],[AdUrl],[Money],[IsMoney],[Time],[ClientId],[IsMobile],[ReferrerUrl],[BrowseName],[BrowseVersion],[OsName],[Country],[Area],[Region],[City],[County],[Isp],[IpSource] from LogBrowse where Time={0}", time.ToString("yyyyMMdd"));
            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            var rowscount = m_acc.InsertInto(cp);

            LogBrowseBLL.Instance.Delete(new LogBrowsePara() { Time = int.Parse(time.ToString("yyyyMMdd")) });

            //迁移完成之后，更新汇总信息
            SummaryHistoryUserLogBrowse(time);
        }

        /// <summary>
        /// 汇总相关数据
        /// </summary>
        /// <param name="time"></param>
        public void SummaryHistoryUserLogBrowse(DateTime time)
        {
            string timeid = time.ToString("yyyyMMdd");

            string cmd = @"select  time,adid,aduserid,count(*) pvcount,count(distinct(clientid)) uvcount,count(distinct(clientip)) ipcount
                            from LogBrowseHistory 
                            where Time=$TIME$
                            group by time,adid,aduserid
                            order by adid";
            //替换汇总时间
            cmd = cmd.Replace("$TIME$", timeid);

            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            DataTable table = m_acc.GetTable(cp);

            //获取所有的广告信息，获取相关的价格信息
            var list = AdPageInfoBLL.Instance.GetModels(new AdPageInfoPara());

            for (int i = 0; i < table.Rows.Count; i++)
            {
                HistoryUserLogBrowseVO his = new HistoryUserLogBrowseVO();
                his.AdId = int.Parse(table.Rows[i]["adid"].ToString());
                his.CreateUserId = 0;
                his.CreateDate = DateTime.Now;
                his.IpCount = int.Parse(table.Rows[i]["ipcount"].ToString());
                his.UvCount = int.Parse(table.Rows[i]["uvcount"].ToString());
                his.PvCount= int.Parse(table.Rows[i]["pvcount"].ToString());
                his.UserId = int.Parse(table.Rows[i]["aduserid"].ToString());
                his.Time = int.Parse(timeid);

                var adinfo = list.SingleOrDefault(p => p.Id == his.AdId);
                if (adinfo != null)
                {
                    his.Price = adinfo.Money;
                    his.Money = his.Price * his.IpCount;                    
                }

                HistoryUserLogBrowseBLL.Instance.Add(his);
            }
        }
    }
}
