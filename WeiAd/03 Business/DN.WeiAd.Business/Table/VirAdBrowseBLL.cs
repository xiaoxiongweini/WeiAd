
/*

skey edit by 2017/9/21 10:02:13

mail:skey111@foxmail.com

version edit by v1.0.3

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
    public partial class VirAdBrowseBLL : IBusiness<VirAdBrowseVO, VirAdBrowsePara>
    {
        #region 实例

        static VirAdBrowseBLL m_proxy = null;
        static VirAdBrowseInterface acc = null;
        public static VirAdBrowseBLL Instance
        {
            get
            {
                if (m_proxy == null)
                {
                    acc = AccessFactory.CreatedObject<VirAdBrowseInterface>();
                    m_proxy = new VirAdBrowseBLL();
                }

                return m_proxy;
            }
        }

        #endregion

        public int AddIdentity(VirAdBrowseVO m)
        {
            return acc.InsertIdentityId(m);
        }

        public bool Add(VirAdBrowseVO m)
        {
            return acc.Insert(m);
        }

        public bool Edit(VirAdBrowseVO m)
        {
            return acc.Edit(m);
        }

        public bool Delete(VirAdBrowsePara mp)
        {
            return acc.Delete(mp);
        }

        public VirAdBrowseVO GetSingle(VirAdBrowsePara mp)
        {
            return acc.GetSingle(mp);
        }

        public List<VirAdBrowseVO> GetModels(VirAdBrowsePara mp)
        {
            return acc.GetModels(mp);
        }

        public List<VirAdBrowseVO> GetModels(ref VirAdBrowsePara mp)
        {
            return acc.GetModels(ref mp);
        }

        public int GetRecords(VirAdBrowsePara mp)
        {
            return acc.GetRecords(mp);
        }
    }
}
