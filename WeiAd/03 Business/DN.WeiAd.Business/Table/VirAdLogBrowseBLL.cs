
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
    public partial class VirAdLogBrowseBLL : IBusiness<VirAdLogBrowseVO, VirAdLogBrowsePara>
    {
        #region 实例

        static VirAdLogBrowseBLL m_proxy = null;
        static VirAdLogBrowseInterface acc = null;
        public static VirAdLogBrowseBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<VirAdLogBrowseInterface>();
                    m_proxy = new VirAdLogBrowseBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(VirAdLogBrowseVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(VirAdLogBrowseVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(VirAdLogBrowseVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(VirAdLogBrowsePara mp)
        {
            return acc.Delete(mp);
        }

        public VirAdLogBrowseVO GetSingle(VirAdLogBrowsePara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<VirAdLogBrowseVO> GetModels(VirAdLogBrowsePara mp)
        {
            return acc.GetModels(mp);
        }

        public List<VirAdLogBrowseVO> GetModels(ref VirAdLogBrowsePara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(VirAdLogBrowsePara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
