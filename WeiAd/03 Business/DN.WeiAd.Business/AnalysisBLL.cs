using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DN.WeiAd.Interface;
using DN.Framework.Core;
using DN.WeiAd.Models;
using DN.WeiAd.Business.Entity;
using DN.WeiAd.Business.Entity.Analysis;

namespace DN.WeiAd.Business
{
    public class AnalysisBLL
    {
        #region 实例

        static AnalysisBLL m_proxy = null;

        static ChartInterface acc = null;
        public static AnalysisBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<ChartInterface>();
                    m_proxy = new AnalysisBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        /// <summary>
        /// 通用汇总，groupby必须填写
        /// </summary>
        /// <param name="flow"></param>
        /// <returns></returns>
        public DataTable GetAnalysis(QueryGroupInfo flow)
        {
            StringBuilder sb = new StringBuilder();

            if (flow.AdId.HasValue)
            {
                sb.AppendFormat(" and AdId = {0} ", flow.AdId);
            }
            if (flow.FlowUserId.HasValue)
            {
                sb.AppendFormat(" and FlowUserId = {0} ", flow.FlowUserId);
            }
            if (flow.AdUserID.HasValue)
            {
                sb.AppendFormat(" and AdUserId = {0} ", flow.AdUserID);
            }
            if (flow.Time.HasValue)
            {
                sb.AppendFormat(" and time = {0} ", flow.Time.Value.ToString("yyyyMMdd"));
            }
            
            string cmd = string.Format(@"
select 
{1}
,count(*) as pvcount
,count(distinct(clientid)) as uvcount
,count(distinct(clientip)) as ipcount  
,count(distinct(clientid)) /count(*) as useravg 
from  [AdBrowse]
where 1=1 {0}
group by {1}", sb, flow.GroupBy);

            ChartPara cp = new ChartPara();
            cp.CommandText = cmd;
            DataTable table = acc.GetTable(cp);

            return table;
        }
        
     
    }
}
