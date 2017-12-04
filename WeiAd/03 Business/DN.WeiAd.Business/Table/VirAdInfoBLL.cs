
/*

skey edit by 2017/7/17 16:02:28

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
    public partial class VirAdInfoBLL : IBusiness<VirAdInfoVO, VirAdInfoPara>
    {
        #region 实例

        static VirAdInfoBLL m_proxy = null;
        static VirAdInfoInterface acc = null;
        public static VirAdInfoBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<VirAdInfoInterface>();
                    m_proxy = new VirAdInfoBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(VirAdInfoVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(VirAdInfoVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(VirAdInfoVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(VirAdInfoPara mp)
        {
            return acc.Delete(mp);
        }

        public VirAdInfoVO GetSingle(VirAdInfoPara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<VirAdInfoVO> GetModels(VirAdInfoPara mp)
        {
            return acc.GetModels(mp);
        }

        public List<VirAdInfoVO> GetModels(ref VirAdInfoPara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(VirAdInfoPara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
