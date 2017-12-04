
/*

skey edit by 2017-03-29 20:00:21

*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DN.WeiAd.Models;
using DN.WeiAd.Interface;
using DN.Framework.Core;

namespace DN.WeiAd.Business
{
    public partial class AdQcodeInfoBLL : IBusiness<AdQcodeInfoVO, AdQcodeInfoPara>
    {
        #region 实例

        static AdQcodeInfoBLL m_proxy = null;
        static AdQcodeInfoInterface acc = null;
        public static AdQcodeInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<AdQcodeInfoInterface>();
                    m_proxy = new AdQcodeInfoBLL();
                    m_proxy.Refresh();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(AdQcodeInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(AdQcodeInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(AdQcodeInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(AdQcodeInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public AdQcodeInfoVO GetSingle(AdQcodeInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<AdQcodeInfoVO> GetModels(AdQcodeInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<AdQcodeInfoVO> GetModels(ref AdQcodeInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(AdQcodeInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
