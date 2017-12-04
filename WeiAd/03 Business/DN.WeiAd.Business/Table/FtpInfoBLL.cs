
/*

skey edit by 2017-05-01 15:15:01

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
    public partial class FtpInfoBLL : IBusiness<FtpInfoVO, FtpInfoPara>
    {
        #region 实例

        static FtpInfoBLL m_proxy = null;
        static FtpInfoInterface acc = null;
        public static FtpInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<FtpInfoInterface>();
                    m_proxy = new FtpInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(FtpInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(FtpInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(FtpInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(FtpInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public FtpInfoVO GetSingle(FtpInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<FtpInfoVO> GetModels(FtpInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<FtpInfoVO> GetModels(ref FtpInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(FtpInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
